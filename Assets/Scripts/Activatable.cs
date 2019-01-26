using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public enum EventType
    {
        Activated,
        Ready
    }
    public delegate void OnReadyDelegate(EventType et);

    private Dictionary<string, OnReadyDelegate> listeners = new Dictionary<string, OnReadyDelegate>();

    public Sequencer sequencer = null;
    private bool ready = false;

    public void TryActivate()
    {
        if(ready)
        {
            foreach(var kv in listeners)
            {
                kv.Value(EventType.Activated);
            }
            sequencer.OnActivated(this);

        }
    }

    public void OnReady()
    {
        ready = true;
        foreach(var kv in listeners)
        {
            kv.Value(EventType.Ready);
        }
    }

    public void Register(string name, OnReadyDelegate cb)
    {
        listeners.Add(name, cb);
    }

    public void Deregister(string name)
    {
        listeners.Remove(name);
    }
}
