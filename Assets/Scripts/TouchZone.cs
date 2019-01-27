using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnTouch touchy = other.GetComponent<OnTouch>();
        if (touchy != null)
        {
            touchy.Touch();
        }
    }
}
