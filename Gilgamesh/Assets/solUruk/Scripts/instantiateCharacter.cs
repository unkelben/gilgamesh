using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(mainMenu))]
public class instantiateCharacter : MonoBehaviour
{
  public GameObject gilgamesh;
  public GameObject enkidu;
  public GameObject bartender;
  public GameObject bartender2;

  public readonly string selectedCharacter = "selectedCharacter";

    // Start is called before the first frame update
    void Start()
    {
      int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

      switch(getCharacter)
      {
        case 0:
          Instantiate(bartender, new Vector3(6.27f, 1.81f, 0f), Quaternion.identity);

          break;
        case 1:
          Instantiate(bartender2, new Vector3(6.27f, 1.81f, 0f), Quaternion.identity);
          break;
      }
    }
}
