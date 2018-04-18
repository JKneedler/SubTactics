using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

	public GameObject minePrefab;
	public Camera mainCamera;

	//how often new mines are spawned (in units traveled)
	public float spawnEventFrequency = 30.00f;
	//approx. many mines are spawned every spawn event
	public int minesPerSpawnMin = 1;
	public int minesPerSpawnMax = 2;

	public int minYValue = 0;
	public int maxYValue = 0;

	//time since the mines were last spawned
	private float distanceSinceSpawnEvent = 0f;
	private float distanceAtLastFrame = 0f;
	// Use this for initialization
	void Start () {
		distanceAtLastFrame = transform.position.x;
		Debug.Log (distanceAtLastFrame);
	}
	
	// Update is called once per frame
	void Update () {
		distanceSinceSpawnEvent += Mathf.Abs(transform.position.x - distanceAtLastFrame);
		distanceAtLastFrame = transform.position.x;
		if (distanceSinceSpawnEvent >= spawnEventFrequency) {
			int numMinesToSpawn = (int) Mathf.Round(Random.Range (minesPerSpawnMin, minesPerSpawnMax));
			float yCoordinate = Random.Range (minYValue, maxYValue); 
			for (int i = 0; i < numMinesToSpawn; i++) {
				Instantiate (minePrefab, new Vector3( (float)(mainCamera.transform.position.x + mainCamera.orthographicSize * 2.5f), yCoordinate, 0f), Quaternion.identity);
			}
			distanceSinceSpawnEvent = 0;
		}
	}
}
