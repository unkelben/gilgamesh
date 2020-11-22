using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rose.Characters
{
    using Rose.Utilities;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        private Rigidbody2D rb;

        private Vector2 inputVector;
        private Vector2 moveAmount;
        private Vector2 smoothMoveVelocity;
        private bool isMoving;
        public bool safeZone { get; set; }
        public bool inBoat { get; set; }
        private float timeInBoat;

        public List<GameObject> surroundingNpcs { get; set; }

        private SpriteRenderer spriteRenderer;
        [SerializeField] private CharacterData characterData;

        private Animator anim;

        private bool npcIsTalking;
        private float talkTimer;

        private Score saved;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = inputVector * speed * Time.deltaTime;
        }

        void Start()
        {
            surroundingNpcs = new List<GameObject>();
            isMoving = false;
            safeZone = false;
            inBoat = false;
            timeInBoat = 0;

            anim = GetComponent<Animator>();
            anim.runtimeAnimatorController = characterData.animatorController;

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = characterData.sprite;

            saved = FindObjectOfType<Score>();

            talkTimer = 0;
        }

        private void FixedUpdate()
        {
            Movement();
        }

        void Update()
        {
            HandleInput();
            FaceDirection();
            Animate();
            NPCAnimations();
        }

        void HandleInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (inBoat)
            {
                timeInBoat += Time.deltaTime;
                horizontal = 0;

                if (timeInBoat <= 0.3f)
                {
                    vertical = 0;
                }
                else
                { 
                    if (vertical == 1)
                    {
                        transform.position += new Vector3(0, 10, 0);
                        inBoat = false;
                        transform.GetComponent<CircleCollider2D>().enabled = true;
                        timeInBoat = 0;
                    }
                    else if (vertical == -1)
                    {
                        transform.position -= new Vector3(0, 10, 0);
                        inBoat = false;
                        transform.GetComponent<CircleCollider2D>().enabled = true;
                        timeInBoat = 0;
                    }
                }
            }
            
            isMoving = horizontal != 0 | vertical != 0;

            inputVector = new Vector2(horizontal, vertical).normalized;
            moveAmount = Vector2.SmoothDamp(moveAmount, inputVector, ref smoothMoveVelocity, 0.15f);
        }

        void Movement()
        {
            if (isMoving)
                rb.velocity = inputVector * speed * Time.deltaTime;
            else
                rb.velocity = new Vector2(0, 0);
        }

        void FaceDirection()
        {
            if (isMoving)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, moveAmount), rotationSpeed * Time.deltaTime);
        }

        void Animate()
        {
            anim.SetBool("isMoving", isMoving);
        }

        void NPCAnimations()
        {
            if (surroundingNpcs.Count != 0)
            {
                talkTimer += Time.deltaTime;

                if (talkTimer >= 5f)
                {
                    foreach (GameObject npc in surroundingNpcs)
                    {
                        if (npc.GetComponent<NpcController>().isTalking)
                        {
                            npcIsTalking = true;
                            talkTimer = 0;
                            break;
                        }
                    }

                    if (!npcIsTalking)
                    {
                        int index = Random.Range(0, surroundingNpcs.Count - 1);
                        surroundingNpcs[index].GetComponent<NpcController>().isTalking = true;
                        talkTimer = 0;
                    }
                }
            }
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "bubble")
            {
                safeZone = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "bubble")
            {
                surroundingNpcs.Clear();
                safeZone = false;
            }

            if (collision.tag == "Enemy" && !inBoat)
            {
                //if (saved.score < 25)
                //    SceneManager.LoadScene("Game_Over1");
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Target")
            {
                transform.position = collision.transform.position;
                transform.up = new Vector3(-1, 0, 0);
                inBoat = true;
                transform.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
}
