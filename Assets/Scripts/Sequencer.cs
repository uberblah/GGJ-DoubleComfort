using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
    public Activatable[] sequenceArray;
    int currentIndex = 0;

    /*
     * make an array of objects
     * each object will be responsible for the one that comes before it
     * */


    // Start is called before the first frame update
    void Start()
    {
        if(sequenceArray[0] != null)
        {
            sequenceArray[0].OnReady();
        }
    }

    void AdvanceSequence()  //this changes the current state of the sequence to the next state, in order
    {
        if(currentIndex < sequenceArray.Length)
        {
            sequenceArray[currentIndex].OnReady();
        }
        else
        {
            //possibly start triggering win-game events
        }
    }

    public void OnActivated(Activatable newActivatable)
    {
        //close out the previous
        currentIndex++;
        AdvanceSequence();
    }
}
