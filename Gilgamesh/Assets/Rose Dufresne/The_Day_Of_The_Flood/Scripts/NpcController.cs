using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Rose.Characters
{
    using Rose.Utilities;

    public class NpcController : MonoBehaviour
    {
        [SerializeField] private float speed = 0.75f;
        [SerializeField] private float rotationSpeed;

        private Rigidbody2D rb;
        private GameObject player;
        private GameObject previousNpc;
        private GameObject boat;

        private Vector2 newPoint;
        private Vector2 direction;
        private Vector2 smoothMoveVelocity;
        [SerializeField] private float distanceBetween;
        private List<Vector3> pathPoints;
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
        [SerializeField] private CharacterData[] npcData;

        private Animator anim;
        private int colorIndex;

        private Score score;

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
            pathPoints = new List<Vector3>();
        }

        void Start()
        {
            seeker = GetComponent<Seeker>();
            InvokeRepeating("UpdatePath", 0f, 0.5f);

            spriteRenderer = GetComponent<SpriteRenderer>();
            colorIndex = Random.Range(0, npcData.Length);
            spriteRenderer.sprite = npcData[colorIndex].sprite;
            boat = GameObject.FindGameObjectWithTag("Target");

            anim = GetComponent<Animator>();
            anim.runtimeAnimatorController = npcData[colorIndex].animatorController;

            score = FindObjectOfType<Score>();

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
                if (player != boat)
                {
                    if (player.GetComponent<PlayerController>().safeZone)
                    {
                        player = boat;
                    }
                }
                
                if (player != null)
                {
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
            }
            
            if (player != null && Vector2.Distance(player.transform.position, rb.position) <= distanceBetween)
                rb.velocity = new Vector2(0f, 0f);
            if (previousNpc != null && Vector2.Distance(previousNpc.transform.position, transform.position) <= distanceBetween)
                rb.velocity = new Vector2(0f, 0f);

            isMoving = rb.velocity != new Vector2(0f, 0f) ? true : false;
            FaceDirection();
        }

        private void UpdatePath()
        {
            if (seeker.IsDone() && player != null && previousNpc == null)
                seeker.StartPath(rb.position, player.transform.position, OnPathComplete);
            if (seeker.IsDone() && previousNpc != null)
                seeker.StartPath(rb.position, previousNpc.transform.position, OnPathComplete);
        }

        void FaceDirection()
        {
            if (isMoving)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);
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
            anim.SetBool("isMoving", isMoving);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Player" && player == null && previousNpc == null && player != boat)
            {
                player = other.gameObject;
                if (player.GetComponent<PlayerController>().surroundingNpcs.Count > 0)
                {
                    previousNpc = player.GetComponent<PlayerController>().surroundingNpcs[player.GetComponent<PlayerController>().surroundingNpcs.Count - 1];
                }
                player.GetComponent<PlayerController>().surroundingNpcs.Add(gameObject);
                Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), player.GetComponent<CircleCollider2D>(), true);
                isRoaming = false;
            }
            
            if (other.collider.tag == "Target")
            {
                
                score.score += 1;
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
                if (player != null && player != boat)
                {
                    player.GetComponent<PlayerController>().surroundingNpcs.Remove(gameObject);
                }
                if (gameObject != null)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
