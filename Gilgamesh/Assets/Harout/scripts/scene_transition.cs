using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_transition : MonoBehaviour
{
    [Header("New Scene variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public vector_value playerStorage;
    public Vector2 cameraNewMin;
    public Vector2 cameraNewMax;
    public vector_value cameraMin;
    public vector_value cameraMax;
   [Header("Transions")]
    public GameObject fadein;
    public GameObject fadeout;
    public float fadeWait;

    private void Awake()
    {
    if (fadein != null)
        {
            GameObject panel = Instantiate(fadein, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            ///  SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeControl());
        }
    }

    public IEnumerator FadeControl ()

    {
        if(fadeout != null)
        {
            Instantiate(fadeout, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }

    }




    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;

    }

}
