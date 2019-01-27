using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : Action
{
    public FadeInOut fader = null;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        if(fader == null)
        {
            Debug.LogError("No fader found for this Appear action");
        }
    }

    public override void Do()
    {
        fader.FadeIn();
    }
}
