using UnityEngine;
using System.Collections;

namespace Rose.Characters
{
    using Rose.Utilities;

    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject npc;

        private Transform playerTransform;

        private NpcCounterText npcCounterText;

        [SerializeField] private float timeUntilNextSpawn;
        private float time;

        private void Start()
        {
            playerTransform = FindObjectOfType<PlayerController>().transform;
            npcCounterText = GetComponentInChildren<NpcCounterText>();
            time = 0;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player" && npcCounterText.counter > 0)
            {
                time += Time.deltaTime;
                if (time >= timeUntilNextSpawn)
                {
                    Vector2 spawnPosition = playerTransform.position - playerTransform.up * 4;
                    GameObject newNpc = Instantiate(npc, spawnPosition, Quaternion.identity) as GameObject;
                    npcCounterText.counter -= 1;
                    time = 0;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (transform.tag == "Flower" && collision.collider.tag == "Player" && npcCounterText.counter > 0)
            {
                time += Time.deltaTime;
                if (time >= timeUntilNextSpawn)
                {
                    Vector2 spawnPosition = playerTransform.position - playerTransform.up * 4;
                    GameObject newNpc = Instantiate(npc, spawnPosition, Quaternion.identity) as GameObject;
                    npcCounterText.counter -= 1;
                    time = 0;
                }
            }
        }
    }
}
