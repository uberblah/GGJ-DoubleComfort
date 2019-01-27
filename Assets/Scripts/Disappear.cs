using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : Action
{
    // Start is called before the first frame update
    void Start()
    {
        InitAction();
    }

    public override void Do()
    {
        foreach(var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
    }
}
