using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text txt;
    public GameObject theFish = null;
    //[SerializeField] private Sprite[] Fishes;
    //private string[] fishes = { "Giant Squid", "Dark Stingray", "Glowing Eel", "Evil Salmon", "Sand Tiger Shark", "A group of small fishes", "A group of Strange Squids", "Sparkling Scorpion Fish", "Freckled Evilfish" };
    // Start is called before the first frame update
    void Start()
    {
        theFish = GameObject.Find(PlayerPrefs.GetString("lastBounty"));
        //var theFish = GameObject.Find("Giant Squid");
        theFish.GetComponent<Image>().enabled = true;
        txt.text = PlayerPrefs.GetString("lastBounty");
        if (txt.text == "Nothing")
        {
            txt.text += "...";
        }
    }

    public void RestartGame()
    {
        theFish.GetComponent<Image>().enabled = false;
        SceneManager.LoadScene("MainDiving");
    }
}
