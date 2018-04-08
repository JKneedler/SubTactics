using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour {

	public float speed;
	public float baseSpeed;
	public float fullSpeed;
	public int direction;
	public Transform camTransform;
	public Vector3 startPos;
	public GameObject missileObject;
	public Transform missileSpawn;
	public GameObject bombObject;
	public Transform bombSpawn;
	public Rigidbody2D myRigid;

	//angle in degrees to linearly-interpolatedly rotate to
	Quaternion targetRotation = Quaternion.Euler(0,0,0);
	//scale of rotation speed
	private float rotationSpeed = 10f;
	private float maxRotationAngle = 15f;

	// Use this for initialization
	void Start () {
		myRigid = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetControls ();
		Move ();
		camTransform.position = new Vector3 (transform.position.x + 15, transform.position.y, -10);
		if (Input.GetKeyDown (KeyCode.Space)) {
			ShootMissile ();
		} else if (Input.GetKeyDown (KeyCode.M)) {
			RaiseBomb ();
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
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
		if (Input.GetKey (KeyCode.D)) {
			myRigid.velocity = new Vector2 (1 * fullSpeed, direction * fullSpeed);
		} else {
			myRigid.velocity = new Vector2 (1 * baseSpeed, direction * baseSpeed);
		}
		targetRotation = Quaternion.Euler (0, 0, maxRotationAngle * direction);
	}

	public void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Mine") {
			NewGame ();
		}
	}

	public void NewGame(){
		transform.position = startPos;
	}

	public void ShootMissile(){
		GameObject missile = (GameObject)Instantiate (missileObject, missileSpawn.position, transform.localRotation);
		missile.GetComponent<Rigidbody2D> ().velocity = missile.transform.right * 15;
	}

	public void RaiseBomb(){
		GameObject bomb = (GameObject)Instantiate (bombObject, bombSpawn.position, bombObject.transform.rotation);
		bomb.GetComponent<Rigidbody2D> ().velocity = Vector2.up * 10;
	}
}
