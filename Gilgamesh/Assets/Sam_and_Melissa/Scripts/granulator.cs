using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granulator : MonoBehaviour
{
    /*
     best way I found of instantiating sounds is instantiating a gameobject with a sound component then
     deleting the gameobejct when i no longer need it to clear buffer space............ kinda weird tbh
     */
    public float minGrainLength = 0.3f;
    public float maxGrainLength = 0.8f;

    public float minTimeToNext = 0.1f;
    public float maxTimeToNext = 0.4f;

    float nextTrigger = 0f;

    float attackTime = 0.05f;
    float releaseTime = 0.2f;

    GameObject grainSource;
    AudioSource audioData;

    List<AudioSource> channels = new List<AudioSource>();

    List<GameObject> grains = new List<GameObject>();

    List<float> stopTimes = new List<float>();
    List<float> startTimes = new List<float>();

    int counter =0;
    // Start is called before the first frame update
    void Start()
    {
        grainSource = GameObject.Find("granuChild");
       // audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        // add sound if it's time to add
        if (t>nextTrigger)
        {

            GameObject buffer = Instantiate(grainSource);
            grains.Add(buffer);

            AudioSource audioData = buffer.GetComponent<AudioSource>();
            channels.Add(audioData);

            float startTime = Random.Range( 0f, audioData.clip.length - minGrainLength);
            float endTime = startTime + Mathf.Min(audioData.clip.length - startTime, Random.Range(minGrainLength, maxGrainLength));

            

            audioData.time = startTime;

            stopTimes.Add(endTime);
            startTimes.Add(startTime);

            audioData.Play();

            nextTrigger = t + Random.Range(minTimeToNext, maxTimeToNext);
           // Debug.Log("Added. Count: " + channels.Count);
        }
        counter++;


        // remove sound if it's time to remove:

        for(int i= grains.Count-1; i>=0; i--)
        {
            

            if (channels[i].time >= stopTimes[i])
            {
                channels[i].Stop();
                channels.RemoveAt(i);

                Destroy(grains[i]);
                grains.RemoveAt(i);
                stopTimes.RemoveAt(i);
              //  Debug.Log("Removed");
            }
        }



       // manage attack / release:

        for(int i=0; i<grains.Count; i++)
        {

            float timeToEnd = stopTimes[i] - channels[i].time;
            float timeFromStart = channels[i].time - startTimes[i];

            if (timeToEnd < releaseTime)
            {
                channels[i].volume = timeToEnd / releaseTime;
            }
            else if (timeFromStart < attackTime)
            {
                channels[i].volume = timeFromStart / attackTime;
            }
            else channels[i].volume = 1f;
        }
    }
}
