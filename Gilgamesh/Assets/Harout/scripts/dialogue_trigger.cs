using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_trigger : MonoBehaviour
{




    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<dialogue_manager>().StartDialogue(dialogue);
    }

}
