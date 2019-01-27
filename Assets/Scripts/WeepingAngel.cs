using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public Activatable activatable;
    
    public void StartWatching(GameObject observer) {}

    public void StopWatching(GameObject observer)
    {
        activatable.TryActivate();
    }
}
