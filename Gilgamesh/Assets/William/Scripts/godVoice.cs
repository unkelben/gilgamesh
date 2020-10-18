using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class godVoice : MonoBehaviour
{
    public TextMeshProUGUI sequenceText;

    void Start()
    {
        StartCoroutine(TextUpdate());
    }

    IEnumerator TextUpdate()
    {
        yield return new WaitForSeconds(2);
        sequenceText.SetText("Enkidu, why are you cursing the woman...?");
        yield return new WaitForSeconds(5);
        sequenceText.SetText("She, the mistress who taught you to eat bread fit for gods and drink wine of kings!");
        yield return new WaitForSeconds(5);
        sequenceText.SetText("She who put upon you a magnificent garment...");
        yield return new WaitForSeconds(5);
        sequenceText.SetText("Did she not give you glorious Gilgamesh for your companion!?");
        yield return new WaitForSeconds(5);
        sequenceText.SetText("");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
