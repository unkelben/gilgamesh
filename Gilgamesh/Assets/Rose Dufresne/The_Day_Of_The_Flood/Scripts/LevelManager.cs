using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rose.Utilities
{
    using Rose.Characters;
    using Rose.Utilities;

    public class LevelManager : MonoBehaviour
    {
        //MAIN MENU

        public static bool gameIsPaused = false;
        public static bool gameReplayed = false;
        public GameObject pauseMenuUI;

        private GameObject player;
        private TimerText timer;
        private Score saved;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            timer = FindObjectOfType<TimerText>();
            saved = FindObjectOfType<Score>();
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
            if (sceneName == "End_Scene1" || sceneName == "End_Scene2" || sceneName == "Game_Over1" || sceneName == "Start_Scene")
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
            SceneManager.LoadScene("The_Day_Of_The_Flood");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void WinningLosingCondition()
        {
            if (player != null && timer != null && saved != null)
            {
                if (player.GetComponent<PlayerController>().inBoat && timer.timeLeft <= 0f && saved.score >= 25)
                    SceneManager.LoadScene("End_Scene1");
                if (!player.GetComponent<PlayerController>().inBoat && timer.timeLeft <= 0f && saved.score >= 25)
                    SceneManager.LoadScene("End_Scene2");
                if (timer.timeLeft <= 0f && saved.score < 25)
                    SceneManager.LoadScene("Game_Over1");
            }
        }
    }
}
