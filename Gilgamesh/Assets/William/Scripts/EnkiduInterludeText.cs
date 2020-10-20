using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnkiduInterludeText : MonoBehaviour
{

    public TextMeshProUGUI enkiduText;

    void Start()
    {
        StartCoroutine(TextUpdate());
    }

    IEnumerator TextUpdate()
    {
        yield return new WaitForSeconds(17.5f);
        enkiduText.SetText("Woman, I promise you another destiny.");
        yield return new WaitForSeconds(4);
        enkiduText.SetText("The mouth which cursed you shall bless you!");
        yield return new WaitForSeconds(4);
        enkiduText.SetText("Kings, princes and nobles shall adore you.");
        yield return new WaitForSeconds(4);
        enkiduText.SetText(" A ring for your hand and a robe shall be yours. ");
        yield return new WaitForSeconds(4);
        enkiduText.SetText("The priest will lead you into the presence of the gods. ");
        yield return new WaitForSeconds(4);
        enkiduText.SetText("Be grateful! For on your account a wife, a mother of seven, was forsaken!");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Praise", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
