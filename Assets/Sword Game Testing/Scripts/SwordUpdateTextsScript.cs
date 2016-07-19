using UnityEngine;
using System.Collections;

public class SwordUpdateTextsScript : MonoBehaviour {


	public TextMesh HitCount;
	//public TextMesh AxeText;
	//public TextMesh SwordText;

	//public GameObject Axe;
	//public GameObject Sword;

	private int HitCounts = 0;

	// Use this for initialization
	void Start () {
		HitCount.text = "Hits : " + HitCounts.ToString ();
	}

	void FixedUpdate()
	{
		//AxeText.text = "Axe Velocity : " + Axe.GetComponent<Rigidbody>().velocity.ToString();
		//SwordText.text = "Swords Angular Velocity : " + Sword.GetComponent<Rigidbody> ().angularVelocity.ToString ();
	}
	
	public void AddHitCount()
	{
		HitCounts++;
		UpdateText();
	}

	void UpdateText()
	{
		HitCount.text = "Hits : " + HitCounts.ToString ();
	}
}
