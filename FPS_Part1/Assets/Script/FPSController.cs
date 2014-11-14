using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float speed;
	public float axisCap;
	public float sensitivity;
	float yAxis = 0;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false; //Hide the cursor on the screen 
		Screen.lockCursor = true; //Lock the cursor inside the window
	}
	
	// Update is called once per frame
	void Update () {
	

		/*
		 * Movement code for WASD movement
		 */
		Vector3 sVec = new Vector2 ();
		if(Input.GetKey(KeyCode.W)){
			sVec += transform.forward*speed;
		}
		if(Input.GetKey(KeyCode.S)){
			sVec -= transform.forward*speed;
		}
		if(Input.GetKey(KeyCode.A)){
			sVec -= transform.right*speed;
		}
		if(Input.GetKey(KeyCode.D)){
			sVec += transform.right*speed;
		}

		CharacterController cc = GetComponent<CharacterController> ();
		cc.SimpleMove(sVec);

		//Handle player Yaw rotation

		transform.Rotate (
			new Vector3 (
			0.0f,
			sensitivity * Input.GetAxis ("Mouse X"),
			0.0f));
		
		//Handle camera pitch rotation
		yAxis = Mathf.Clamp(-Input.GetAxis("Mouse Y")*sensitivity+yAxis,-axisCap,axisCap);
		Camera.main.transform.rotation = transform.rotation* Quaternion.Euler
			(new Vector3(yAxis,0.0f,0.0f));
	}	
}
