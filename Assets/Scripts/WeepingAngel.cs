using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeepingAngel : MonoBehaviour
{
    public enum EventType
    {
        StartWatching,
        StopWatching
    }
    public delegate void EventDelegate(EventType et, GameObject observer, GameObject angel);

    private Dictionary<string, EventDelegate> listeners = new Dictionary<string, EventDelegate>();

    public void RegisterListener(string name, EventDelegate ed)
    {
        listeners.Add(name, ed);
    }

    public void DeregisterListener(string name)
    {
        listeners.Remove(name);
    }

    public void StartWatching(GameObject observer)
    {
        SendEvent(EventType.StartWatching, observer);
    }

    public void StopWatching(GameObject observer)
    {
        SendEvent(EventType.StopWatching, observer);
    }

    private void SendEvent(EventType et, GameObject observer)
    {
        foreach(var kv in listeners)
        {
            kv.Value(et, observer, gameObject);
        }
    }
}
