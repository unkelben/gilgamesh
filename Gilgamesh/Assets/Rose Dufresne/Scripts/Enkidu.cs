using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Balance
{
    using Rose.Clay;

    public class Enkidu : MonoBehaviour
    {
        [SerializeField] GameObject enkidu;
        [SerializeField] ParticleSystem stars;
        [SerializeField] ParticleSystem winning;

        private SkinnedMeshRenderer blendshapes;
        private float weightToAdd;
        public float weightBalance { get; set; }
        public float interval { get; set; }
        private Vector3 initialScale;
        private Vector3 targetScale;
        public bool targetFormAchieved { get; set; }
        private float weightGained;
        private float timerForEquality;

        public Stack<float> clayWeights { get; set; }

        //private float oscillationTimer;

        //particle effects
        private float particleTimer;
        private bool clayAdded;

        //sounds
        AudioSource starSound;
        private float soundTimer;
        AudioSource choir;

        void Start()
        {
            clayWeights = new Stack<float>();

            targetScale = enkidu.transform.localScale;
            enkidu.transform.localScale = new Vector3(0, 0, 0);
            initialScale = enkidu.transform.localScale;
            weightToAdd = 0;
            weightBalance = -30f;
            interval = 0;
            targetFormAchieved = false;
            timerForEquality = 0;

            blendshapes = enkidu.GetComponent<SkinnedMeshRenderer>();
            blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f)); //body

            //particle effects
            if (stars.isPlaying) stars.Stop();
            particleTimer = 0;
            clayAdded = false;

            //sounds
            AudioSource[] audioSources = GetComponents<AudioSource>();
            starSound = audioSources[0];
            choir = audioSources[1];
        }
        
        void Update()
        {
            ParticleSystem();
            UpdateEnkidu();
            SoundSystem();
            CheckEquality();
        }

        private void Timer()
        {
            //wait 3 seconds before confirming that he is balanced/equal
            timerForEquality += Time.deltaTime;
            if (timerForEquality >= 3f)
            {
                targetFormAchieved = true;
            }
            if (blendshapes.GetBlendShapeWeight(3) > 0 || Mathf.Ceil(enkidu.transform.localScale.magnitude) != Mathf.Ceil(targetScale.magnitude))
            {
                timerForEquality = 0f;
            }
        }

        private void CheckEquality()
        {
            if (blendshapes.GetBlendShapeWeight(3) <= 0 && Mathf.Ceil(enkidu.transform.localScale.magnitude) == Mathf.Ceil(targetScale.magnitude))
            {
                Timer();
                if (!winning.isPlaying) winning.Play();
                if (!choir.isPlaying) choir.Play();
            }
            else
            {
                targetFormAchieved = false;
                if (winning.isPlaying) winning.Stop();
                if (choir.isPlaying) choir.Stop();
            }
        }

        private void UpdateEnkidu()
        {
            weightGained = (100 - weightBalance * (-100f / 30f));

            if ((int)weightGained > (int)interval) //remove weight
            {
                weightBalance -= weightToAdd / 10f * Time.deltaTime;
                if (weightGained <= 100)
                {
                    blendshapes.SetBlendShapeWeight(3, weightBalance * (-100f / 30f));
                }

                UpdateScale();
            }
            else if ((int)weightGained < (int)interval) //add weight
            {
                weightBalance += weightToAdd / 10f * Time.deltaTime;
                if (weightGained <= 100)
                {
                    blendshapes.SetBlendShapeWeight(3, (weightBalance * (-100f / 30f)));
                }
                UpdateScale();
            }
            else
            {
                //oscillationTimer += Time.deltaTime;
                //if (oscillationTimer <= 2f)
                //{
                //    weightBalance = ((interval - 100) / (100f) * 30f) * Mathf.Pow(Mathf.Epsilon,(-oscillationTimer)) * Mathf.Cos(2 * oscillationTimer) + Mathf.Sin(2 * oscillationTimer);
                //}
                weightBalance = ((int)interval - 100) / (100f) * 30f;
            }
        }

        private void UpdateScale()
        {
            enkidu.transform.localScale = new Vector3(initialScale.x + weightGained, initialScale.y + weightGained, initialScale.z + weightGained)*0.5f;
        }

        private void ParticleSystem()
        {
            if (clayAdded)
            {
                particleTimer += Time.deltaTime;
            }
            if (particleTimer <= 2f && clayAdded)
            {
                if (!stars.isPlaying) stars.Play();
            }
            else
            {
                if (stars.isPlaying) stars.Stop();
                particleTimer = 0f;
                clayAdded = false;
            }

            if (!clayAdded)
            {
                if (starSound.isPlaying) starSound.Stop();
            }
        }

        private void SoundSystem()
        {
            if (clayAdded)
            {
                soundTimer += Time.deltaTime;
            }
            if (particleTimer <= 2f && clayAdded)
            {
                if (!starSound.isPlaying) starSound.Play();
            }
            else
            {
                if (starSound.isPlaying) starSound.Stop();
                soundTimer = 0f;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Clay")
            {
                if (!other.GetComponent<Clay>().isInHand)
                {
                    weightToAdd = other.GetComponent<Clay>().weight;
                    interval += weightToAdd;
                    print(other.GetComponent<Clay>().weight);
                    clayWeights.Push(other.GetComponent<Clay>().weight);
                    Destroy(other.gameObject);
                    clayAdded = true;
                }
            }
        }
    }
}


//float headWeight = 0;
//float arm_R_Weight = 100;
//float arm_L_Weight = 100;

//set up blend shapes
//blendshapes.SetBlendShapeWeight(0, 0f); //arm_L
//blendshapes.SetBlendShapeWeight(1, 0f); //arm_R
//blendshapes.SetBlendShapeWeight(2, 0f); //head

//if (blendshapes.GetBlendShapeWeight(3) <= 50 && blendshapes.GetBlendShapeWeight(2) <= 100)
//{
//    blendshapes.SetBlendShapeWeight(2, headWeight+50);
//}
//if (blendshapes.GetBlendShapeWeight(1) > 0 && blendshapes.GetBlendShapeWeight(2) >= 100)
//{
//    blendshapes.SetBlendShapeWeight(1, arm_R_Weight-50);
//}
//if (blendshapes.GetBlendShapeWeight(0) > 0 && blendshapes.GetBlendShapeWeight(1) <= 0)
//{
//    blendshapes.SetBlendShapeWeight(0, arm_L_Weight-50);
//}
