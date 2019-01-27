using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogueManager : MonoBehaviour
{

    // create queue to manage the sentences
    private Queue<string> sentences;

    //create variables to store info
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    //create gameobject to control animation to open/close dialogue
    public Animator animator;

    //create reference to start button animation
    //public Animator startAnimator;

    //create reference for typing audio
    public AudioSource audio;

    //grab special audio source attached to object of Dialogue Trigger
    private AudioSource audioClip;


    // Use this for initialization
    void Start()
    {

        //Initialize queue of sentences
        sentences = new Queue<string>();

        
    }

    // function to initiate the start of a dialogue
    public void StartDialogue(Dialogue dialogue, AudioSource clip)
    {

        // debug print
        //Note: Error of "NullReferenceException: Object reference not set to an instance of an object"
        //Debug.Log("Starting Converstation with " + dialogue.title);


        // hide start button
        //startAnimator.SetBool("IsOpen", false);


        audioClip = clip;
        //audio sigh
        audioClip.Play();

        //set animation bool to open to show dialogue box
        animator.SetBool("IsOpen", true);

        //set title of Dialogue
        nameText.text = dialogue.name;

        //clear any previous sentences
        sentences.Clear();

        //iterate through each sentence from the dialogue object
        foreach (string sentence in dialogue.sentences)
        {
            //add the current sentence to the senteces array
            sentences.Enqueue(sentence);
        }

        //print next sentence
        DisplayNextSentence();

    }


    //function that prints next sentence if it exists in the queue
    public void DisplayNextSentence()
    {
        // terminates dialogue if there are no more sentences
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //prints the next sentence in the queue
        string sentence = sentences.Dequeue();

        //debug: print each sentence
        //Debug.Log(sentence);

        //change dialogue text that is show to next sentence
        //dialogueText.text = sentence;

        //Incase continue button is pressed before full print,
        //stop any current coroutine
        StopAllCoroutines();

        //for more style
        //start coroutine to print sentence letter by letter
        //param: sentence to be printed
        StartCoroutine(TypeSentence(sentence));


    }

    IEnumerator TypeSentence(string sentence)
    {
        //start with blank dialogue box
        dialogueText.text = "";

        //start typing audio
        audio.Play();

        //split sentence into idividual chars in arrays and print one by one
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        audio.Stop();
    }


    //function that terminates the dialogue
    void EndDialogue()
    {
        //debug statement to show end of convo
        //Debug.Log("End of Conversation is over");

        //set animation bool to false to dialogue box
        animator.SetBool("IsOpen", false);

        //show start button again
        //startAnimator.SetBool("IsOpen", true);

        //end audio clip
        audioClip.Stop();

        //set title of Dialogue
        nameText.text = "";

        dialogueText.text = "";
    }
}

