using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    GameObject playerReference;
    Rigidbody playerRigidbody;
    GameObject cameraReference;
    CharacterAnimatizer anim;

    float xMotion = 0f;
    float zMotion = 0f;

    float horizontalRotation = 0f;
    float verticalRotation = 0f;

    public float motionSpeed;
    public float rotationSpeed;

    //public float 

    bool canInteract = true;

    void Start()
    {
        cameraReference = Camera.main.gameObject;
        playerReference = GameObject.Find("Player").gameObject;
        playerRigidbody = playerReference.GetComponent<Rigidbody>();
        anim = GetComponent<CharacterAnimatizer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = playerRigidbody.position;
        
        if ((Input.GetAxis("Horizontal") > 0.05f || Input.GetAxis("Horizontal") < -0.05f) || (Input.GetAxis("Vertical") > 0.05f || Input.GetAxis("Vertical") < -0.05f))
        {
            Vector3 newEulerAngles = new Vector3(playerReference.transform.eulerAngles.x, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg, playerReference.transform.eulerAngles.z);
            newEulerAngles.y += cameraReference.transform.eulerAngles.y;
            playerReference.transform.eulerAngles = newEulerAngles;
            playerRigidbody.transform.Translate(Vector3.forward * motionSpeed * Time.deltaTime);
            anim.DoWalking();
        }
        else
        {
            anim.DoIdle();
        }


        if (canInteract && Input.GetAxis("Fire2") < -0.95f) //Input.GetButtonDown("Fire1")
        {
            canInteract = false;
            //call interaction function here
            StartCoroutine("SetCanInteractToTrue");

        }

        if (Input.GetKey(key: KeyCode.Q) || Input.GetKey(key: KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    IEnumerator SetCanInteractToTrue()
    {
        yield return new WaitForSeconds(0.5f);
        canInteract = true;
    }
}
