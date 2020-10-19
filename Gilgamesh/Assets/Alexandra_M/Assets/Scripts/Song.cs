using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Credits goes to elvirais, on Unity's forum
// https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html

public class Song : MonoBehaviour
{
    private static Song instance = null;

    public static Song Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }   
}