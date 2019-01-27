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
    Material wallMaterialOpaque;
    Material wallMaterialTransparent;

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
                if (wallMaterialOpaque == null)
                {
                    wallMaterialOpaque = tempArray[i].transform.gameObject.GetComponent<Renderer>().material;
                    wallMaterialOpaque.name = wallMaterialOpaque.name.Substring(0, wallMaterialOpaque.name.IndexOf(' '));
                    print("Opaque Name is " + wallMaterialOpaque.name);
                    print("Searching for " + "Materials/" + wallMaterialOpaque.name + "Transparent");
                    wallMaterialTransparent = Resources.Load<Material>("Materials/"+ wallMaterialOpaque.name+"Transparent");
                    if(wallMaterialTransparent != null)
                    {
                        print("Transparent name is " + wallMaterialTransparent.name);
                    }
                }
                tempArray[i].transform.gameObject.GetComponent<Renderer>().material = wallMaterialTransparent;
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
                    transparentObjectsList[i].GetComponent<Renderer>().material = wallMaterialOpaque;
                }
            }
        }
        else
        {
            for (int j = 0; j < transparentObjectsList.Count; j++)
            {
                transparentObjectsList[j].GetComponent<Renderer>().material = wallMaterialOpaque;
            }
        }
    }
}
