using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnTouch angel = other.GetComponent<OnTouch>();
        if (angel != null)
        {
            angel.Touch();
        }
    }
}
