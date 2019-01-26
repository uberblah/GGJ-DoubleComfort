using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    GameObject playerReference;
    Rigidbody playerRigidbody;
	//PlayerManager playerManagerScript;

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
		playerReference = GameObject.Find("Player").gameObject;
        playerRigidbody = playerReference.GetComponent<Rigidbody>();
		//playerManagerScript = playerReference.GetComponent<PlayerManager> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPosition = playerRigidbody.position;// playerReference.transform.position;

		xMotion = Input.GetAxis ("Horizontal") * motionSpeed * Time.deltaTime;
        //playerReference.transform.Translate (xMotion, 0f, 0f, Space.World);
        newPosition.x += xMotion;
        zMotion = Input.GetAxis ("Vertical") * motionSpeed * Time.deltaTime;
        //playerReference.transform.Translate (0f, 0f, zMotion, Space.World);
        newPosition.z += zMotion;
        //playerReference.transform.position = newPosition;
        playerRigidbody.position = newPosition;

        /*
		horizontalRotation = Input.GetAxis ("Mouse X") * rotationSpeed * Time.deltaTime;
		playerReference.transform.Rotate (0f, horizontalRotation, 0f, Space.World);

		verticalRotation = Input.GetAxis ("Mouse Y") * rotationSpeed * Time.deltaTime;
		playerReference.transform.Rotate (verticalRotation, 0f, 0f, Space.World);
        */

        playerReference.transform.eulerAngles = new Vector3(playerReference.transform.eulerAngles.x, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg, playerReference.transform.eulerAngles.z);


        if (Input.GetKey(key:KeyCode.UpArrow))
		{
			playerReference.transform.Translate (0f, 0f, 0.5f);
		}
		if(Input.GetKey(key:KeyCode.DownArrow))
		{
			playerReference.transform.Translate (0f, 0f, -0.5f);
		}
		if(Input.GetKey(key:KeyCode.RightArrow))
		{
			playerReference.transform.Translate (0.5f, 0f, 0f);
		}
		if(Input.GetKey(key:KeyCode.LeftArrow))
		{
			playerReference.transform.Translate (-0.5f, 0f, 0f);
		}
		

		if(canInteract && Input.GetAxis("Fire2") < -0.95f) //Input.GetButtonDown("Fire1")
		{
			canInteract = false;
			//call interaction function here
			StartCoroutine ("SetCanInteractToTrue");

		}

		if(Input.GetKey(key:KeyCode.Q)|| Input.GetKey(key:KeyCode.Escape))
		{
			Application.Quit ();
		}
	}

	IEnumerator SetCanInteractToTrue()
	{
		yield return new WaitForSeconds(0.5f);
		canInteract = true;
	}
}
