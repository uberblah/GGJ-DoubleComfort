using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : Action
{
    public FadeInOut fader = null;

    void Start()
    {
        InitAction();
        if(fader == null)
        {
            Debug.LogError("You must specify a fader to use");
            return;
        }
    }
    
    public override void Do()
    {
        fader.FadeOut();
    }
}