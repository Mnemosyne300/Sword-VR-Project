using UnityEngine;
using System.Collections;

public class SwordSpawnManagerScript : MonoBehaviour {

	public float SpawnCooldown = 1f;
	public GameObject[] Enemies;

	private Transform[] SpawnLocations;
	private float Timer = 0f;

	private GameObject HMD;

	// Use this for initialization
	void Start () {
		HMD = GameObject.FindGameObjectWithTag ("MainCamera");
		SpawnLocations = GameObject.FindGameObjectWithTag ("SpawnPoints").GetComponentsInChildren<Transform> ();

		Vector3 playerToMouse = HMD.transform.position;
		Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
		Instantiate(Enemies[0], SpawnLocations[0].position, newRotation);
	}

	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		if (Timer > SpawnCooldown) {
			Vector3 playerToMouse = HMD.transform.position;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			Instantiate(Enemies[Random.Range(0 , Enemies.Length)], SpawnLocations[Random.Range(0, SpawnLocations.Length)].position, newRotation);
			Timer = 0;
		}
	}
}