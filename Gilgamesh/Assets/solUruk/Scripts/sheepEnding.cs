using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(mainMenu))]
public class sheepEnding : MonoBehaviour
{
  public GameObject gilgamesh;
  public GameObject enkidu;

  public Rigidbody2D sheepRb1;
  public Rigidbody2D sheepRb2;
  public Rigidbody2D sheepRb3;

  public GameObject gilText;
  public GameObject enkText;

  public readonly string selectedCharacter = "selectedCharacter";
  public readonly string oncePlayedthrough = "oncePlayedthrough";

    void Start()
    {
      int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

      switch(getCharacter)
      {
        case 0:
          Destroy(enkText);
          Instantiate(gilgamesh, new Vector3(-7.5f, 2f, 0f), Quaternion.identity);
          break;
        case 1:
          Destroy(gilText);
          Instantiate(enkidu, new Vector3(-7.5f, 2f, 0f), Quaternion.identity);
          break;
      }
    }

    void FixedUpdate () {
      if (sheepRb1.position.y<0&&sheepRb2.position.y<0&&sheepRb3.position.y<0)
      {
        float isPlayedthrough = PlayerPrefs.GetFloat(oncePlayedthrough);
        if (isPlayedthrough==0)
        {
          PlayerPrefs.SetFloat(oncePlayedthrough, 1);
          SceneManager.LoadScene("titlescreen");
        }
        if (isPlayedthrough==1)
        {
          Application.Quit();
        }
      }
    }
}
