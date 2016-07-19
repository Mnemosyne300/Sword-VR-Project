using UnityEngine;
using System.Collections;

public class SwordBulletScript : MonoBehaviour {

	public float FORCE = 400f;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody> ().AddForce (transform.forward * (FORCE * 100));
	
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy (gameObject, 0.5f);
	}
}
