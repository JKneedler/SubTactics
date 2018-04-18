using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructOffCamera : MonoBehaviour {

	private Camera mainCamera;
	private float maxDistanceFromCamera;
	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		maxDistanceFromCamera = mainCamera.orthographicSize*5;
	}
	
	// Update is called once per frame
	void Update () {
 		if ((transform.position - mainCamera.transform.position).magnitude > maxDistanceFromCamera) {
			Destroy (gameObject);
		}
	}
}
