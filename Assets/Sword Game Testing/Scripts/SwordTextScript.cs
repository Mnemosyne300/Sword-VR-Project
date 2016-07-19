using UnityEngine;
using System.Collections;

public class SwordTextScript : MonoBehaviour {

	GameObject HMD;

	// Use this for initialization
	void Start () {
		HMD = GameObject.FindGameObjectWithTag ("MainCamera");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt (HMD.transform.position);
	}
}
