using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Rose.Characters
{
    using Rose.Utilities;

    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject npc;

        private Transform playerTransform;

        private Transform npcCounterText;

        private Transform deathSprite;

        [SerializeField] private float timeUntilNextSpawn;
        private float time;

        private void Start()
        {
            playerTransform = FindObjectOfType<PlayerController>().transform;
            npcCounterText = transform.GetChild(0); 
            time = 0;

            deathSprite = transform.GetChild(1);
            deathSprite.GetComponent<Image>().enabled = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player" && npcCounterText.GetComponentInChildren<NpcCounterText>().counter > 0)
            {
                time += Time.deltaTime;
                if (time >= timeUntilNextSpawn)
                {
                    Vector2 spawnPosition = playerTransform.position - playerTransform.up * 4;
                    GameObject newNpc = Instantiate(npc, spawnPosition, Quaternion.identity) as GameObject;
                    newNpc.GetComponent<NpcController>().isConfused = true;
                    npcCounterText.GetComponentInChildren<NpcCounterText>().counter -= 1;
                    time = 0;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                if (npcCounterText.GetComponentInChildren<NpcCounterText>().counter > 0)
                {
                    npcCounterText.GetComponent<Text>().enabled = false;
                    deathSprite.GetComponent<Image>().enabled = true;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (transform.tag == "Flower" && collision.collider.tag == "Player" && npcCounterText.GetComponentInChildren<NpcCounterText>().counter > 0)
            {
                time += Time.deltaTime;
                if (time >= timeUntilNextSpawn)
                {
                    Vector2 spawnPosition = playerTransform.position - playerTransform.up * 4;
                    GameObject newNpc = Instantiate(npc, spawnPosition, Quaternion.identity) as GameObject;
                    npcCounterText.GetComponentInChildren<NpcCounterText>().counter -= 1;
                    time = 0;
                }
            }
        }
    }
}
