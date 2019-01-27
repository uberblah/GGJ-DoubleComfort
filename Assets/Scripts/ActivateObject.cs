using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : Action
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        if (obj == null)
        {
            Debug.LogError("You must specify a GameObject for the ActivateObject to activate!");
            return;
        }
        obj.SetActive(false);
    }

    // Update is called once per frame
    public override void Do()
    {
        obj.SetActive(true);
    }
}
