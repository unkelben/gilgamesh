using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
  public bool isGilgamesh = false;
    // Play as Gilgamesh
    public void Gilgamesh()
    {
      isGilgamesh = true;
      StartGame();
    }

    // Play as Enkidu
    public void Enkidu()
    {
      isGilgamesh = false;
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
