using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateCharacter : MonoBehaviour
{
  public GameObject gilgamesh;
  public GameObject enkidu;

  private mainMenu character;

    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<mainMenu>();

        if (character.isGilgamesh)
        {
          Instantiate(gilgamesh, new Vector3(-1.17f, 4.75f, 0f), Quaternion.identity);
        }
        else
        {
          Instantiate(enkidu, new Vector3(-1.17f, 4.75f, 0f), Quaternion.identity);
        }
    }
}
