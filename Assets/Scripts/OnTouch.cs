using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour
{
    public Activatable activatable;
    public readonly string matchedTag;
    public readonly GameObject targetObject;

    void Start()
    {
        if(activatable == null)
        {
            Debug.LogError("Must specify an Activatable for OnTouch");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I'm COLLIDING");
        foreach(var point in collision.contacts)
        {
            if (point.otherCollider.gameObject.GetComponent<Player>() != null)
            {
                Debug.Log("I'm COLLIDING with a PLAYER");
                activatable.TryActivate();
            }
        }
    }
}
