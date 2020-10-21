using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(mainMenu))]
public class instantiateCharacter : MonoBehaviour
{

  public GameObject bartender;
  public GameObject bartender2;

  public GameObject gilText;
  public GameObject enkText;

  public readonly string selectedCharacter = "selectedCharacter";
    void Start()
    {
      int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

      switch(getCharacter)
      {
        case 0:
          Instantiate(bartender, new Vector3(6.27f, 1.81f, 0f), Quaternion.identity);
          Destroy(enkText);
          break;
        case 1:
          Instantiate(bartender2, new Vector3(6.27f, 1.81f, 0f), Quaternion.identity);
          Destroy(gilText);
          break;
      }
    }
}
