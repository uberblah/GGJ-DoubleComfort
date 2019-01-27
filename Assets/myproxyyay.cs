using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myproxyyay : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;
    public bool isWalking = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            isWalking = !isWalking;
            if(isWalking)
            {
                GetComponent<CharacterAnimatizer>().DoWalking();
            }
            else
            {
                GetComponent<CharacterAnimatizer>().DoIdle();
            }
        }
    }
}
