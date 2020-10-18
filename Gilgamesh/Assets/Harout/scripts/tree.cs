using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree : MonoBehaviour
{

    private Animator anim;


    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialog;

  

    Text score;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Break()
    {
        anim.SetBool("break", true);
        tree_score.scoreValue += 1;
        StartCoroutine(breakCo());
        dialogueBox.SetActive(true);
        dialogueText.text = dialog;
        


    }


    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(2F);
        this.gameObject.SetActive(false);
        dialogueBox.SetActive(false);

    }

}
