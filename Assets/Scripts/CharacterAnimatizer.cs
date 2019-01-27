using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatizer : MonoBehaviour
{
    public Animator character;
    public Animator glasses;
    public string paramName = "Walking";

    private void Start()
    {
        if(character == null)
        {
            Debug.LogError("Need a character GameObject for this CharacterAnimatizer");
        }
        if(glasses == null)
        {
            Debug.LogError("Need a glasses GameObject for this CharacterAnimatizer");
        }
    }

    public void DoWalking()
    {
        character.SetBool(paramName, true);
        glasses.SetBool(paramName, true);
    }

    public void DoIdle()
    {
        character.SetBool(paramName, false);
        glasses.SetBool(paramName, false);
    }
}
