using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rose.Level
{
    using Rose.Balance;

    public class LevelManager : MonoBehaviour
    {
        //MAIN MENU

        public static bool gameIsPaused = false;
        public static bool gameReplayed = false;
        public GameObject pauseMenuUI;
        [SerializeField] Enkidu enkidu;

        private void Start()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !enkidu.targetFormAchieved)
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

            if (enkidu.targetFormAchieved)
            {
                Pause();
            }
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
            enkidu.targetFormAchieved = false;
            SceneManager.LoadScene("Creation_Of_Enkidu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}