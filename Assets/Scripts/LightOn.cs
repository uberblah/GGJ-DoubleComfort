using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : Action
{
    private new Light light;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        light = GetComponent<Light>();
        if(light == null)
        {
            Debug.LogError("Could not find an attached light for the LightOn component");
            return;
        }
        light.enabled = false;
    }

    // Update is called once per frame
    public override void Do()
    {
        light.enabled = true;
    }
}
