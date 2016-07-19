using UnityEngine;
using System.Collections;

public class SwordChangeWeaponScript : MonoBehaviour {

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId touchPadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }

	public GameObject[] Weapons;
	private int currWeapon = 0;

	private float Timer = 0;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponentInParent<SteamVR_TrackedObject> ();
		SwapWeapons ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (controller != null && controller.GetPressDown(touchPadButton)) {
			SwapWeapons();
		}
	}

	//void SwapWeapons()
	//{
	//	foreach (Transform child in transform) {
	//		GameObject.Destroy (child.gameObject);
	//	}
	//
	//	GameObject sword = (GameObject)Instantiate (Weapons [currWeapon], transform.position, new Quaternion(0,0,0,0));
	//	sword.transform.rotation = Weapons [currWeapon].transform.rotation;
	//	sword.transform.parent = this.transform;
	//	currWeapon++;
	//	if (currWeapon >= Weapons.Length) {
	//		currWeapon = 0;
	//	}
	//}


	void SwapWeapons()
	{
		if (Weapons[currWeapon].activeInHierarchy) {
			Weapons [currWeapon].SetActive (false);
			currWeapon++;
		}

		if (currWeapon >= Weapons.Length) {
			currWeapon = 0;
		}

		Weapons [currWeapon].SetActive (true);
	}
}
