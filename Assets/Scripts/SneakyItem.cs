using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakyItem : MonoBehaviour
{
    public delegate void UnhideListener();

    private System.Guid id;
    private Dictionary<string, UnhideListener> listeners = new Dictionary<string, UnhideListener>();
    
    public WeepingAngel angel;
    public bool myTurn = false;
    public bool beingWatched = false;

    // Start is called before the first frame update
    void Start()
    {
        id = System.Guid.NewGuid();
        angel.RegisterListener(id.ToString(), OnWatchEvent);
    }

    public void Register(string name, UnhideListener listener)
    {
        listeners.Add(name, listener);
    }

    public void Deregister(string name)
    {
        listeners.Remove(name);
    }

    private void TryUnhide()
    {
        if (myTurn && !beingWatched)
        {
            Unhide();
        }
    }

    private void Unhide()
    {
        foreach(var kv in listeners)
        {
            kv.Value();
        }
    }

    public void OnMyTurn()
    {
        myTurn = true;
        TryUnhide();
    }

    public void OnWatchEvent(WeepingAngel.EventType et, GameObject observer, GameObject observed)
    {
        switch(et)
        {
        case WeepingAngel.EventType.StartWatching:
            beingWatched = true;
            break;
        case WeepingAngel.EventType.StopWatching:
            beingWatched = false;
            TryUnhide();
            break;
        }
    }
}
