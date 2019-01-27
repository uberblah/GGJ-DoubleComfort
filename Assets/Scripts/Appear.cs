using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : Action
{
    private new readonly Renderer renderer;
    public FadeInOut fader = null;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        if (fader == null)
        {
            Debug.LogError("You must specify a fader to use");
            return;
        }
    }

    public override void Do()
    {
        fader.FadeIn();
    }
}
