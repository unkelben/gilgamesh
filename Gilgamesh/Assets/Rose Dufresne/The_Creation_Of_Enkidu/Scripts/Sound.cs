using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Level
{
    using Rose.Balance;

    public class Sound : MonoBehaviour
    {
        AudioSource music;
        AudioSource wind;
        AudioSource god;
        AudioSource god2;
        [SerializeField] Enkidu enkidu;

        private bool soundPlayed1;
        private bool soundPlayed2;

        // Start is called before the first frame update
        void Start()
        {
            //sounds
            AudioSource[] audioSources = GetComponents<AudioSource>();
            music = audioSources[0];
            wind = audioSources[1];
            god = audioSources[2];
            god2 = audioSources[3];

            soundPlayed1 = false;
            if (!soundPlayed1)
            {
                if (!god.isPlaying && !LevelManager.gameReplayed) god.Play();
                soundPlayed1 = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (LevelManager.gameIsPaused)
            {
                if(god.isPlaying) god.Pause();
            }
            else
            {
                if(!god.isPlaying && !LevelManager.gameReplayed && !soundPlayed1) god.Play();
            }

            if (enkidu.targetFormAchieved && !soundPlayed2)
            {
                if (!god2.isPlaying) god2.Play();
                soundPlayed2 = true;
            }
        }
    }
}
