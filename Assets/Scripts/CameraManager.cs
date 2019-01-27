using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;
    RaycastHit raycastHit;
    Vector3 dir;
    GameObject hitObject;
    GameObject translucentObject;

    void Awake()
    {
        playerTransform = player.transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = player.transform.position - transform.position;

        Debug.DrawRay(transform.position, dir * raycastHit.distance, Color.red);
        if (Physics.Raycast(transform.position, dir, out raycastHit, Mathf.Infinity))
        {
            hitObject = raycastHit.transform.gameObject;
            if (translucentObject != null && translucentObject != hitObject)
            {
                //have tranlucentObject fade back in
                print("Fading in " + translucentObject.name);
                translucentObject = null;
            }
            if (hitObject.name != "Player" && hitObject.name != "Floor")
            {
                translucentObject = hitObject;
                print("Fading out " + translucentObject.name);
            }
        }
    }

}
