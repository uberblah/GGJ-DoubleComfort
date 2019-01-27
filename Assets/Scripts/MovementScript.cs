using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    GameObject playerReference;
    Rigidbody playerRigidbody;
    GameObject cameraReference;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = playerRigidbody.position;
        Vector3 newEulerAngles = new Vector3(playerReference.transform.eulerAngles.x, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg, playerReference.transform.eulerAngles.z);
        newEulerAngles.y += cameraReference.transform.eulerAngles.y;
        playerReference.transform.eulerAngles = newEulerAngles;
        if ((Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") < 0f) || (Input.GetAxis("Vertical") > 0f || Input.GetAxis("Vertical") < 0f))
        {
            playerRigidbody.transform.Translate(Vector3.forward * motionSpeed * Time.deltaTime);
        }


        if (canInteract && Input.GetAxis("Fire2") < -0.95f) //Input.GetButtonDown("Fire1")
        {
            canInteract = false;
            //call interaction function here
            StartCoroutine("SetCanInteractToTrue");

        }

        if (Input.GetKey(key: KeyCode.Q) || Input.GetKey(key: KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SetCanInteractToTrue()
    {
        yield return new WaitForSeconds(0.5f);
        canInteract = true;
    }
}
