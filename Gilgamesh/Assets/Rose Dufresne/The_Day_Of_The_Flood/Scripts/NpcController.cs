using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Rose.Characters
{
    using Rose.Utilities;

    public class NpcController : MonoBehaviour
    {
        [SerializeField] bool isHuman;

        private Transform child;
        private Transform emotes;

        [SerializeField] private float speed = 0.75f;
        [SerializeField] private float rotationSpeed;

        private Rigidbody2D rb;
        private GameObject player;
        private GameObject previousNpc;
        public int index { get; set; }
        private GameObject boat;
        private bool goToBoat;

        private Vector2 newPoint;
        private Vector2 direction;
        private Vector2 smoothMoveVelocity;
        [SerializeField] private float distanceBetween;
        [SerializeField] private float nextWayPointDistance = 3f;
        private Path path;
        private int currentWaypoint = 0;
        private bool reachedEnOfPath = false;

        private Seeker seeker;

        private bool isRoaming;
        private bool isMoving;

        private float time;
        [SerializeField] private float timeUntilNextPoint;

        private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject deathSprite;
        [SerializeField] private CharacterData[] npcDataArray;
        CharacterData npcData;

        //animations
        private Animator anim;
        private int colorIndex;
        
        public bool isConfused { get; set; }
        public bool isAlarmed { get; set; }
        public bool isNormal { get; set; }
        public bool isTalking { get; set; }
        private float emoteTimer;
        private float emoteTimerInterval;

        //audio sources
        private AudioSource sound;

        private bool destroy;

        private void Awake()
        {
            player = null;
            previousNpc = null;
            rb = GetComponent<Rigidbody2D>();
            newPoint = new Vector3(0f, 0f, 0f);
            isRoaming = true;
            isMoving = false;
            time = timeUntilNextPoint;
        }

        void Start()
        {
            seeker = GetComponent<Seeker>();
            InvokeRepeating("UpdatePath", 0f, 0.5f);

            child = transform.GetChild(1);
            colorIndex = Random.Range(0, npcDataArray.Length);
            child.GetComponent<SpriteRenderer>().sprite = npcDataArray[colorIndex].sprite;

            npcData = npcDataArray[colorIndex];

            boat = GameObject.FindGameObjectWithTag("Target");
            goToBoat = false;
            
            child.GetComponent<Animator>().runtimeAnimatorController = npcDataArray[colorIndex].animatorController;

            emotes = transform.GetChild(0);
            isConfused = false;
            isAlarmed = false;
            isNormal = false;
            isTalking = false;
            emoteTimer = 0;
            emoteTimerInterval = Random.Range(5, 10);

            sound = GetComponent<AudioSource>();

            destroy = false;
        }
        
        private void FixedUpdate()
        {
            Movement();
        }

        void Update()
        {
            FaceDirection();
            Animate();
        }

        private float inputH;
        private float inputV;
        
        void Movement()
        {
            if (isRoaming)
            {
                time += Time.deltaTime;
                if (time >= timeUntilNextPoint)
                {
                    timeUntilNextPoint = Random.Range(1, timeUntilNextPoint);
                    newPoint = GenerateNewPoint();
                    direction = -(transform.position - new Vector3(newPoint.x, newPoint.y, 0f)).normalized;
                    time = 0;
                }

                //check if it's not going towards a wall
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 3, 1 << LayerMask.NameToLayer("obstacle"));
                if (hit.collider != null)
                {
                    direction = -direction;
                }
                rb.velocity = direction * speed/2 * Time.deltaTime;
            }
            else
            {
                if (player == null)
                {
                    isRoaming = true;
                    return;
                }

                else
                {
                    if (player.GetComponent<PlayerController>().surroundingNpcs.Count > 1 && index > 0 && !goToBoat)
                    {
                        previousNpc = player.GetComponent<PlayerController>().surroundingNpcs[index - 1];
                    }

                    if (!goToBoat)
                    {
                        if (player.GetComponent<PlayerController>().safeZone)
                        {
                            goToBoat = true;
                        }
                    }

                    if (path == null)
                    {
                        return;
                    }

                    if (currentWaypoint >= path.vectorPath.Count)
                    {
                        reachedEnOfPath = true;
                        return;
                    }
                    else
                    {
                        reachedEnOfPath = false;
                    }
                    
                    direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                }

                rb.velocity = direction * speed * Time.deltaTime;
                
                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
                if (distance < nextWayPointDistance)
                {
                    currentWaypoint++;
                }

                if (!goToBoat)
                {
                    if (Vector2.Distance(player.transform.position, rb.position) <= distanceBetween)
                        rb.velocity = new Vector2(0f, 0f);
                    if (previousNpc != null && Vector2.Distance(previousNpc.transform.position, transform.position) <= distanceBetween)
                        rb.velocity = new Vector2(0f, 0f);
                }
            }
            
            isMoving = rb.velocity != new Vector2(0f, 0f) ? true : false;
        }

        private void UpdatePath()
        {
            if (seeker.IsDone() && player != null && previousNpc == null && !goToBoat)
                seeker.StartPath(rb.position, player.transform.position, OnPathComplete);
            else if (seeker.IsDone() && previousNpc != null)
                seeker.StartPath(rb.position, previousNpc.transform.position, OnPathComplete);
            else if (goToBoat)
                seeker.StartPath(rb.position, boat.transform.position, OnPathComplete);
        }

        void FaceDirection()
        {
            if (isMoving)
                child.rotation = Quaternion.Slerp(child.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);
        }
        
        void OnPathComplete(Path p)
        {
            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
        }

        private Vector2 GenerateNewPoint()
        {
            Vector2 point = new Vector2(0f, 0f);

            float height = 2f * Camera.main.orthographicSize;
            float width = height * Camera.main.aspect;

            point = new Vector2(Random.Range(transform.position.x-1, transform.position.x + 1), Random.Range(transform.position.y - 1, transform.position.y + 1));
            //Debug.DrawLine(transform.position, point, Color.black, 10);

            return point;
        }

        void Animate()
        {
            child.GetComponent<Animator>().SetBool("isMoving", isMoving);
            
            if (isRoaming)
            {
                emotes.GetComponent<Animator>().SetBool("isNormal", isNormal);
                isNormal = false;
                emoteTimer += Time.deltaTime;
                if (emoteTimer >= emoteTimerInterval)
                {
                    emoteTimerInterval = Random.Range(5, 10);
                    emoteTimer = 0;
                    isNormal = true;
                }
            }

            if (isAlarmed)
            {
                sound.clip = npcData.alarm;
                sound.Play();
            }
            if (!isConfused)
            {
                emotes.GetComponent<Animator>().SetBool("isAlarmed", isAlarmed);
                isAlarmed = false;
            }

            if (isTalking)
            {
                int randomVoiceLine = Random.Range(0, npcData.voiceLines.Length);

                sound.clip = npcData.voiceLines[randomVoiceLine];
                sound.Play();
            }
            emotes.GetComponent<Animator>().SetBool("isTalking", isTalking);
            isTalking = false;

            emotes.GetComponent<Animator>().SetBool("isConfused", isConfused);
            isConfused = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Player" && player == null && previousNpc == null && !goToBoat)
            {
                player = other.gameObject;
                index = player.GetComponent<PlayerController>().surroundingNpcs.Count;
                player.GetComponent<PlayerController>().surroundingNpcs.Add(gameObject);
                Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), player.GetComponent<CircleCollider2D>(), true);
                isRoaming = false;

                isAlarmed = true;
            }
            
            if (other.collider.tag == "Target")
            {
                goToBoat = false;
                boat.GetComponent<Boat>().isHappy = true;

                if (isHuman)
                    Score.peopleScore += 1;
                else
                    Score.animalScore += 1;
                if (gameObject != null)
                {
                    destroy = true;
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Enemy" && !destroy)
            {
                if (player != null && !goToBoat)
                {
                    for (int i=index; i < player.GetComponent<PlayerController>().surroundingNpcs.Count; i++)
                    {
                        player.GetComponent<PlayerController>().surroundingNpcs[i].GetComponent<NpcController>().index -= 1;
                    }
                    player.GetComponent<PlayerController>().surroundingNpcs.Remove(gameObject);
                }
                if (gameObject != null)
                {
                    Vector3 deathPosition = new Vector3(transform.position.x, transform.position.y, -100f);
                    Instantiate(deathSprite, deathPosition, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }
}
