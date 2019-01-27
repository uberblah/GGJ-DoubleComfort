using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeInOut : Action
{
    public enum Mode
    {
        In,
        Out
    }

    public AnimationCurve fadeInCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 2.0f, 1.0f);
    public AnimationCurve fadeOutCurve = AnimationCurve.EaseInOut(0.0f, 1.0f, 2.0f, 0.0f);
    public AudioSource source;
    public Mode mode;

    // Start is called before the first frame update
    void Start()
    {
        InitAction();
        if(source == null)
        {
            Debug.LogWarning("An Audio Source was not specified, looking for one on the GameObject");
            source = GetComponent<AudioSource>();
        }
        if(source == null)
        {
            Debug.LogError("No Audio Source could be found for this MusicFadeOut");
        }
    }

    public override void Do()
    {
        switch(mode)
        {
        case Mode.In:
            StartCoroutine(Fade(fadeInCurve));
            break;
        case Mode.Out:
            StartCoroutine(Fade(fadeOutCurve));
            break;
        }
    }

    private IEnumerator Fade(AnimationCurve curve)
    {
        if(!source.isPlaying)
        {
            source.Play();
        }

        float startTime = Time.time;
        float endTime = startTime + curve.keys[curve.length - 1].time;
        for (float now = Time.time; now <= endTime; now = Time.time)
        {
            source.volume = curve.Evaluate(now - startTime);
            yield return null;
        }

        if(source.volume <= 0.0f)
        {
            source.Stop();
        }
    }
}
