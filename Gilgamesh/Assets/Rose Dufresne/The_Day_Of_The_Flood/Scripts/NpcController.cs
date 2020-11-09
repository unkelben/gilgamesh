using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

                if (((Input.GetAxisRaw("Horizontal") != inputH || Input.GetAxisRaw("Vertical") != inputV)) 
                    || player == boat)
                {
                    pathPoints.Add(player.transform.position);
                }

                pathPoints[pathPoints.Count - 1] = player.transform.position;
                
                if (player != null)
                {
                    direction = (pathPoints[0] - transform.position).normalized;
                    if (pathPoints.Count > 1 && Vector2.Distance(transform.position, pathPoints[0]) <= 0.5f)
                    {
                        pathPoints.Remove(pathPoints[0]);
                    }
                }

                rb.velocity = direction * speed * Time.deltaTime;
            }
            
            if (player != null && (player.transform.position - transform.position).magnitude <= distanceBetween)
                rb.velocity = new Vector2(0f, 0f);
            if (previousNpc != null && (previousNpc.transform.position - transform.position).magnitude <= distanceBetween)
                rb.velocity = new Vector2(0f, 0f);

            isMoving = rb.velocity != new Vector2(0f, 0f) ? true : false;
            FaceDirection();

            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");
        }

        void FaceDirection()
        {
            if (isMoving)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);
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
                pathPoints.Add(player.transform.position);
                if (player.GetComponent<PlayerController>().surroundingNpcs.Count > 0)
                {
                    previousNpc = player.GetComponent<PlayerController>().surroundingNpcs[player.GetComponent<PlayerController>().surroundingNpcs.Count - 1];
                    //pathPoints = previousNpc.GetComponent<NpcController>().pathPoints;
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
                    print(gameObject);
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
