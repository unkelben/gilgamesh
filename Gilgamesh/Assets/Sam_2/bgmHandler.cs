using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmHandler : MonoBehaviour
{
    AudioSource guit;
    AudioSource drum;
    AudioSource synth;

    float targetSynthVol = 0f;
    float targetDrumVol = 0f;
    float targetGuitVol = 0f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sources = gameObject.GetComponents<AudioSource>();
        drum = sources[0];
        synth = sources[1];
        guit = sources[2];

        drum.volume = 0f;
        synth.volume = 0f;
        guit.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        updateVol(synth, targetSynthVol);
        updateVol(drum, targetDrumVol);
        updateVol(guit, targetGuitVol);

    }

    public void SetSynthVol(float input)
    {
        targetSynthVol = input;
    }

    public void SetDrumVol(float input)
    {
        targetDrumVol = input;
    }

    public void SetGuitVol(float input)
    {
        targetGuitVol = input;
    }

    void updateVol(AudioSource source, float target)
    {
        if (source.volume + 0.001f < target) source.volume += 0.001f;
        else if (source.volume - 0.001f > target) source.volume -= 0.001f;
    }

    public void StartBGM()
    {
        drum.Play();
        synth.Play();
        guit.Play();
    }
}
