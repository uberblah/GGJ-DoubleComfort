using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    public Activatable[] sequence;
    /*
     * object_0
     * object_1
     * object_2_0, object_2_1
     * 
     * check the tag up until the second underscore, then check after that and interpret it if there is anything
     * */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdvanceSequence()  //this changes the current state of the sequence to the next state, in order
    {
        if(false)//the current state is the last one, do not execute this function
        {

        }
    }

    public void OnActivated(Activatable newActivatable)
    {
        
    }
}
