using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    public Activatable activatable;
    public readonly string matchedTag;
    public readonly GameObject targetObject;

    void Start()
    {
        if(activatable == null)
        {
            Debug.LogError("Must specify an Activatable for OnTouch");
        }
    }

    public void Touch()
    {
        activatable.TryActivate();
    }
}
