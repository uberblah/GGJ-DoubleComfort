using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    public Activatable activatable;
    public string tag;

    private void Start()
    {
        if(activatable == null)
        {
            Debug.LogError("Must specify an Activatable for OnTouch");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(tag))
        {
            activatable.TryActivate();
        }
    }
}
