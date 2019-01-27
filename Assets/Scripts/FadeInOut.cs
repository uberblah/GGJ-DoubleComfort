using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Renderer[] renderers = null;

    public AnimationCurve fadeInCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
    public AnimationCurve fadeOutCurve = AnimationCurve.EaseInOut(0.0f, 1.0f, 1.0f, 0.0f);
    public bool startVisible = true;
    
    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        if(!startVisible)
        {
            foreach(var rend in renderers)
            {
                rend.enabled = false;
            }

        }
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(fadeInCurve));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(fadeOutCurve));
    }

    private IEnumerator Fade(AnimationCurve curve)
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = true;
        }

        float startTime = Time.time;
        float endTime = startTime + curve.keys[curve.length - 1].time;
        for (float now = Time.time; now <= endTime; now = Time.time)
        {
            float curveValue = curve.Evaluate(now - startTime);
            foreach (var renderer in renderers)
            {
                Color color = renderer.material.color;
                color.a = curveValue;
                renderer.material.color = color;
            }
            yield return null;
        }

        foreach (var renderer in renderers)
        { 
            if (renderer.material.color.a <= 0.0f)
            {
                renderer.enabled = false;
            }
        }
    }
}
