using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_manager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        ///Debug.Log("Start convo with" + dialogue.name);
        ///

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

         public void  DisplayNextSentence ()
            {
            if (sentences.Count ==0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
        ///  Debug.Log(sentence);
        ///  
        dialogueText.text = sentence;
        }

        void EndDialogue()
        {

        }
    }

