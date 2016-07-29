using UnityEngine;
using System.Collections;

public class EnemySwordScript : MonoBehaviour {

	public float DeathTimer = 5.0f;
	public int Lives = 5;
	public float Speed;

	GameObject HMD;
	void Start()
	{
		Destroy (gameObject, DeathTimer);
		HMD = GameObject.FindGameObjectWithTag ("MainCamera");

		if (HMD == null) {
			Debug.Log ("HMD NOT initialized in EnemySwordScript");
		}
		Movement ();
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.collider.CompareTag("PlayerSword")) {
			Lives -= other.gameObject.GetComponent<SwordScript> ().Damage;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<SwordTextManagerScript> ().AddHitCount ();
			if (Lives <= 0) {
				Destroy (gameObject);
			} 
		}
	}

	void Movement()
	{
		GetComponent<Rigidbody> ().AddForce ((HMD.transform.position - transform.position) * (Speed * 100));
	}
}
