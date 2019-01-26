using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideAppear : MonoBehaviour
{
    private System.Guid id;
    private new Renderer renderer;
    public FadeInOut fader = null;
    
    public SneakyItem item;

    // Start is called before the first frame update
    void Start()
    {
        id = System.Guid.NewGuid();
        item.Register(id.ToString(), BeginFade);
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

    public void BeginFade()
    {
        fader.FadeIn();
    }
}
