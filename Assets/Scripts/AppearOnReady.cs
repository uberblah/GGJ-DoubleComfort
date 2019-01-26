using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnReady : MonoBehaviour
{
    private System.Guid id = System.Guid.NewGuid();
    private new Renderer renderer;
    public FadeInOut fader = null;
    
    public Activatable activatable;

    // Start is called before the first frame update
    void Start()
    {
        activatable.Register(id.ToString(), BeginFade);
        if(fader == null)
        {
            fader = GetComponent<FadeInOut>();
        }
        if(fader == null)
        {
            Debug.LogError("Couldn't find a FadeInOut component on this object");
            return;
        }
    }

    public void BeginFade(Activatable.EventType evt)
    {
        if(evt == Activatable.EventType.Ready)
        {
            fader.FadeIn();
        }
    }
}
