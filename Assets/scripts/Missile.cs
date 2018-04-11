using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	public Transform playerTransform;

	private int maxDistanceFromPlayer = 600;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//remove missile to free resources when it is too far from the player to impact the game
		if (Vector3.Distance (playerTransform.position, transform.position) > maxDistanceFromPlayer) {
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Mine") {
			Destroy (collider.gameObject);
			Destroy (gameObject);
		}
	}
}
