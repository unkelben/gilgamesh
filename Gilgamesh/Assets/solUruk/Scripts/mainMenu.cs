using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public GameObject gilgamesh;
  public GameObject enkidu;

  public GameObject gButton;
  public GameObject eButton;
  public GameObject sidebars;

  public readonly string selectedCharacter = "selectedCharacter";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Play as Gilgamesh
    public void Gilgamesh()
    {
      PlayerPrefs.SetInt(selectedCharacter, 0);
      StartGame();
    }

    // Play as Enkidu
    public void Enkidu()
    {
      PlayerPrefs.SetInt(selectedCharacter, 1);
      StartGame();
    }
    // Start the Game
    private void StartGame()
    {
      Destroy(gButton);
      Destroy(eButton);
      Destroy(sidebars);

      int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

      switch(getCharacter)
      {
        case 0:
          Instantiate(gilgamesh, new Vector3(4.43f, -5.64f, 0f), Quaternion.identity);
          break;
        case 1:
          Instantiate(enkidu, new Vector3(4.43f, -5.64f, 0f), Quaternion.identity);
          break;
        default:
          Debug.Log("Error Loading Character");
          break;
      }
    }
}
