using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : Action
{
    void Start()
    {
        InitAction();
    }
    
    public override void Do()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if(renderer == null)
        {
            Debug.LogError("Couldn't find a renderer for this Disappear component");
            return;
        }
        renderer.enabled = false;
    }
}
