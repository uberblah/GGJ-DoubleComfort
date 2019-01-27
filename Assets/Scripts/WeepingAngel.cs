using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public Activatable activatable;
    public WeepingAngelObserver observer;

    private float prevDistance = -1.0f;

    private void Start()
    {
        if(observer == null)
        {
            Debug.LogError("Cannot do WeepingAngel without an observer!");
        }
        if(activatable == null)
        {
            Debug.LogError("Cannot do WeepingAngel without an Activatable!");
        }
    }

    public void Update()
    {
        float dist = (observer.gameObject.transform.position - gameObject.transform.position).magnitude;
        if(prevDistance <= observer.distance && dist > observer.distance)
        {
            activatable.TryActivate();
        }
    }
}
