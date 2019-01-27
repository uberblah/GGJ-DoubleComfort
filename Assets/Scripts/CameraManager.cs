using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    Transform playerTransform;
    RaycastHit raycastHit;
    Vector3 dir;
    float distance = 0.0f;
    GameObject hitObject;
    GameObject translucentObject;

    List<GameObject> newRaycastHitList;
    List<GameObject> transparentObjectsList;

    void Awake()
    {
        playerTransform = player.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        newRaycastHitList = new List<GameObject>();
        transparentObjectsList = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = player.transform.position - transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        RaycastHit[] tempArray = Physics.RaycastAll(transform.position, dir, distance);
        
        for (int i = 0; i < tempArray.Length; i++)
        {
            if(tempArray[i].transform.gameObject.tag == "WallPiece")
            {
                Color tempColor = tempArray[i].transform.gameObject.GetComponent<Renderer>().material.color;
                tempColor.a = 0.5f;
                tempArray[i].transform.gameObject.GetComponent<Renderer>().material.color = tempColor;
                newRaycastHitList.Add(tempArray[i].transform.gameObject);
            }
        }//if the old list does NOT contain the current checked element of the new list, make it opaque
        
        CheckWhichToMakeOpaque();
        transparentObjectsList.Clear();
        for (int j = 0; j < newRaycastHitList.Count; j++)
        {
            transparentObjectsList.Add(newRaycastHitList[j]);
        }
        newRaycastHitList.Clear();
    }

    void CheckWhichToMakeOpaque()
    {
        if(newRaycastHitList.Count > 0)
        {
            for(int i = 0; i < transparentObjectsList.Count; i++)
            {
                if(newRaycastHitList.Contains(transparentObjectsList[i]) == false)
                {
                    Color tempColor = transparentObjectsList[i].GetComponent<Renderer>().material.color;
                    tempColor.a = 1.0f;
                    transparentObjectsList[i].GetComponent<Renderer>().material.color = tempColor;
                }
            }
        }
        else
        {
            for (int j = 0; j < transparentObjectsList.Count; j++)
            {
                Color tempColor = transparentObjectsList[j].GetComponent<Renderer>().material.color;
                tempColor.a = 1.0f;
                transparentObjectsList[j].GetComponent<Renderer>().material.color = tempColor;
            }
        }
    }
}
