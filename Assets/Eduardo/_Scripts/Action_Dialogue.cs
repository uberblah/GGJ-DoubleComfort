using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Dialogue : Action
{
    public DialogueTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
    }

    //overide Do function of Action button to do custome action
    public override void Do()
    {
        trigger.TriggerDialogue();
    }
}