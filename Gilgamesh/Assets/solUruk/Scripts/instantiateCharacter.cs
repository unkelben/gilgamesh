using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(mainMenu))]
public class instantiateCharacter : MonoBehaviour
{
  public GameObject gilgamesh;
  public GameObject enkidu;

  public readonly string selectedCharacter = "selectedCharacter";

    // Start is called before the first frame update
    void Start()
    {
        int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch(getCharacter)
        {
          case 0:
            Instantiate(gilgamesh, new Vector3(-1.17f, 4.75f, 0f), Quaternion.identity);
            break;
          case 1:
            Instantiate(enkidu, new Vector3(-1.17f, 4.75f, 0f), Quaternion.identity);
            break;
          default:
            Application.Quit();
            break;
        }
    }
}
