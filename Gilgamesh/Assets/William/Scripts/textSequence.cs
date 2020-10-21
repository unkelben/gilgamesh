using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textSequence : MonoBehaviour
{

    public TextMeshProUGUI sequenceText;

    void Start()
    {
        StartCoroutine(TextUpdate());
    }

    IEnumerator TextUpdate()
    {
        yield return new WaitForSeconds(1);
        sequenceText.SetText("Woman, with a great curse I curse you!");
        yield return new WaitForSeconds(4);
        sequenceText.SetText("You shall be without a roof for your commerce!");
        yield return new WaitForSeconds(4);
        sequenceText.SetText("You shall do your business in places fouled by the vomit of the drunkard!");
        yield return new WaitForSeconds(4);
        sequenceText.SetText("Your hire will be potter’s earth, your thievings will be flung into the hovel!");
        yield return new WaitForSeconds(4);
        sequenceText.SetText("Brambles and thorns will tear your feet, the drunk and the dry will strike your cheek!");
        yield return new WaitForSeconds(4);
        sequenceText.SetText("And let you be stripped of your purple dyes!");
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Wrath", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
