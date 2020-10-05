using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public readonly string selectedCharacter = "selectedCharacter";

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
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    // Quit the game
    public void QuitGame()
    {
      Application.Quit();
    }
}
