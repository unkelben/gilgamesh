using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Play as Gilgamesh
    public void Gilgamesh()
    {
        SceneManager.LoadScene(1);
    }
    // Play as Enkidu
    public void Enkidu()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
      Application.Quit();
    }
}
