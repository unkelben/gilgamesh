using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Game : MonoBehaviour
{
    GameObject player;
    GameObject textController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MyPlayer");
        textController = GameObject.FindGameObjectWithTag("Texts");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MyPlayer"))
        {
            StartCoroutine(GameEnd());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MyPlayer"))
        {
            player.GetComponent<Gil_Movement>().EndGameII();
        }
    }
    IEnumerator GameEnd()
    {
        player.GetComponent<Gil_Movement>().EndGame();
        yield return new WaitForSeconds(3);
        textController.GetComponent<Text_Manager>().EndtheGame();
    }
}
