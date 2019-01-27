using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        audio = GetComponent<AudioSource>();
        if (audio == null)
        {
            Debug.LogError("Could not find an attached audio for the Audioplay component");
            return;
        }
        audio.Stop();
    }

    // Update is called once per frame
    public override void Do()
    {
        audio.Play();
    }
}
