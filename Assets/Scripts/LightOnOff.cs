using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : Action
{
    public enum Mode
    {
        On,
        Off
    }

    private new Light light;

    public Mode mode = Mode.On;

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
    }

    // Update is called once per frame
    public override void Do()
    {
        switch(mode)
        {
        case Mode.On:
            light.enabled = true;
            break;
        case Mode.Off:
            light.enabled = false;
            break;
        }
    }
}
