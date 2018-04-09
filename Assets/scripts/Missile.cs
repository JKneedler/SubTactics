using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Mine") {
			Destroy (collider.gameObject);
			Destroy (gameObject);
		}
	}
}
