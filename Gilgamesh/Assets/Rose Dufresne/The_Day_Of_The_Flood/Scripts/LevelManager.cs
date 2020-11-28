using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rose.Utilities
{
    using Rose.Characters;

    public class LevelManager : MonoBehaviour
    {
        //MAIN MENU

        public static bool gameIsPaused = false;
        public static bool gameReplayed = false;
        public GameObject pauseMenuUI;

        private GameObject player;
        private TimerText timer;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            timer = FindObjectOfType<TimerText>();
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "End_Scene1" || sceneName == "End_Scene1_2" || sceneName == "End_Scene2" || sceneName == "End_Scene3" || sceneName == "Game_Over1" || sceneName == "Start_Scene")
            {
                Pause();
            }

            WinningLosingCondition();
        }

        void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void Replay()
        {
            gameReplayed = true;
            Resume();
            Score.score = 0;
            Score.animalScore = 0;
            Score.peopleScore = 0;
            SceneManager.LoadScene("The_Day_Of_The_Flood");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void WinningLosingCondition()
        {
            if (player != null && timer != null)
            {
                if (player.GetComponent<PlayerController>().inBoat && timer.timeLeft <= 0f && Score.peopleScore >= 12 && Score.animalScore >= 12)
                    SceneManager.LoadScene("End_Scene1");
                else if (!player.GetComponent<PlayerController>().inBoat && timer.timeLeft <= 0f && Score.peopleScore >= 12 && Score.animalScore >= 12)
                    SceneManager.LoadScene("End_Scene1_2");
                else if (timer.timeLeft <= 0f && Score.peopleScore >= 12 && Score.animalScore < 12)
                    SceneManager.LoadScene("End_Scene2");
                else if (timer.timeLeft <= 0f && Score.peopleScore < 12 && Score.animalScore >= 12)
                    SceneManager.LoadScene("End_Scene3");
                else if (timer.timeLeft <= 0f && Score.peopleScore < 12 && Score.animalScore < 12)
                    SceneManager.LoadScene("Game_Over1");
            }
        }
    }
}
