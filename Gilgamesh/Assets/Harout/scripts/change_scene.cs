using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    public GameObject fadein;
    public GameObject fadeout;
    public float fadeWait;
    public string sceneToLoad;



    private void Awake()
    {
        if (fadein != null)
        {
            GameObject panel = Instantiate(fadein, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("house");
        StartCoroutine(FadeControl());
    }


    public IEnumerator FadeControl()

    {
        if (fadeout != null)
        {
            Instantiate(fadeout, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

    }



}
