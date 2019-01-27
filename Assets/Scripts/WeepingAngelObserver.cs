using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngelObserver : MonoBehaviour
{
    public triggerTag;

    public void OnTriggerEnter(Collider other)
    {
        WeepingAngel angel = other.GetComponent<WeepingAngel>();
        if (angel != null)
        {
            angel.StartWatching(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        WeepingAngel angel = other.GetComponent<WeepingAngel>();
        if(angel != null)
        {
            angel.StopWatching(gameObject);
        }
    }
}
