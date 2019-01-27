using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // initialize instance of dialogue bod
    public Dialogue dialogue;

    public AudioSource audioClip;

    public void TriggerDialogue()
    {

        //tell the dialogue manager what dialogue to start
        // passes dialogue gameobject as a parameter
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, audioClip);
    }


}
