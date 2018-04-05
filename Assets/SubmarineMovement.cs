using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour {

	public float speed;
	public int direction;
	public Transform camTransform;
	public Vector3 startPos;
	public GameObject missileObject;
	public Transform missileSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetControls ();
		Move ();
		camTransform.position = new Vector3 (transform.position.x + 12, transform.position.y, -10);
		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
		}
	}

	void GetControls(){
		if (Input.GetKey (KeyCode.S)) {
			direction = -1;
		} else if (Input.GetKey (KeyCode.W)) {
			direction = 1;
		} else {
			direction = 0;
		}
	}

	void Move(){
		Rigidbody2D myRigid = gameObject.GetComponent<Rigidbody2D> ();
		if (Input.GetKey (KeyCode.D)) {
			myRigid.velocity = new Vector2 (1 * speed, direction * speed);
		} else {
			myRigid.velocity = new Vector2 (0, 0);
		}
		Quaternion original = Quaternion.Euler (0, 0, 0);
		Quaternion newQ = Quaternion.Euler (0, 0, 30 * direction);
		transform.rotation = Quaternion.Lerp(original, newQ, Time.time * 1);
	}

	public void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Mine") {
			NewGame ();
		}
	}

	public void NewGame(){
		transform.position = startPos;
	}

	public void Shoot(){
		GameObject missile = (GameObject)Instantiate (missileObject, missileSpawn.position, transform.localRotation);
		missile.GetComponent<Rigidbody2D> ().velocity = missile.transform.right * 15;
	}
}
