using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Text_Manager : MonoBehaviour
{
    public TextMeshProUGUI myText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextUpdate());
    }

    IEnumerator TextUpdate()
    {
        myText.SetText("HIS SOUL");
        yield return new WaitForSeconds(3);
        myText.SetText("WILL HAUNT YOU,");
        yield return new WaitForSeconds(4);
        myText.SetText("BUT ALSO HELP YOU.");
        yield return new WaitForSeconds(5);
        myText.SetText("FIND YOUR WAY OUT!");
        yield return new WaitForSeconds(5);
        myText.SetText("");
    }

    public void EndtheGame()
    {
        StartCoroutine(Endgame());
    }

    IEnumerator Endgame()
    {
        myText.SetText("YOU HAVE ESCAPED,");
        yield return new WaitForSeconds(5);
        myText.SetText("BUT NO ONE CAN ESCAPE THEIR FATE");
    }
}
