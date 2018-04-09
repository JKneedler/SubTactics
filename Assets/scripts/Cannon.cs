using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	private int rotationDirection = 0;
	//angle in degrees to linearly-interpolatedly rotate to
	float currentAngle = 0;
	//scale of rotation speed
	private float rotationSpeed = 200f;
	private float maxRotationAngle = 15f;

	private Vector3 cannonPositionRelToPlayer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetControls ();
		float angleDiff = rotationDirection * Time.deltaTime * rotationSpeed;
		currentAngle += angleDiff;
		transform.rotation = Quaternion.Euler(0,0 ,currentAngle);
	}

	void GetControls(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			rotationDirection = 1;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			rotationDirection = -1;
		} else {
			rotationDirection = 0;
		}
	}
}
