using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMats : Action
{
    public Material[] mats1;
    public Material[] mats2;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
    }

    public override void Do()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Material[] imats1 = renderer.materials;
        if(imats1[0] == mats1[0])
        {
            renderer.materials = mats2;
        }
        else
        {
            renderer.materials = mats1;
        }
    }
}
