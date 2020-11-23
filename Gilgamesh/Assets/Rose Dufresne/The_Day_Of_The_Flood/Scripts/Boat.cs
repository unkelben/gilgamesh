using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Characters
{
    public class Boat : MonoBehaviour
    {
        private Transform emotes;
        public bool isHappy { get; set; }

        private AudioSource sound;

        // Start is called before the first frame update
        void Start()
        {
            emotes = transform.GetChild(0);
            isHappy = false;
            sound = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            Animate();
        }

        void Animate()
        {
            if (isHappy)
            {
                sound.Play();
            }
            emotes.GetComponent<Animator>().SetBool("isHappy", isHappy);
            isHappy = false;
        }
    }
}
