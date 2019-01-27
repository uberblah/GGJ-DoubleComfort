using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Dialogue : Action
{


    //public string
    //public string blurb;

    public DialogueTrigger trigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //overide Do function of Action button to do custome action
    public void Do()
    {
        Debug.Log("You should override Action.Do in your subclass!");

        //
        trigger.TriggerDialogue();

    }
}
