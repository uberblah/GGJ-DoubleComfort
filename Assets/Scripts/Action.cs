using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private System.Guid id = System.Guid.NewGuid();
    public Activatable activatable;
    public Activatable.EventType eventType;

    // Start is called before the first frame update
    protected void InitAction()
    {
        if (activatable == null)
        {
            Debug.LogError("You must specify an Activatable to use");
        }
        activatable.Register(id.ToString(), Callback);
    }

    public void Callback(Activatable.EventType evt)
    {
        if(evt == eventType)
        {
            Do();
        }
    }

    public virtual void Do()
    {
        Debug.Log("You should override Action.Do in your subclass!");
    }
}
