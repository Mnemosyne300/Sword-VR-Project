using UnityEngine;
using System.Collections;

public class SwordGunScript : MonoBehaviour {

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId touchPadButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }

	public GameObject Bullet;
	public Transform GunBarrel;
	public float Speed = 0.5f;

	public Color color;
	public float thickness = 0.002f;
	public GameObject holder;
	public GameObject pointer;
	public bool addRigidBody = false;

	private float Timer = 0;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponentInParent<SteamVR_TrackedObject> ();
		//InstantiateVRLazer ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (controller != null && controller.GetPressDown(triggerButton)) {
			Instantiate (Bullet, GunBarrel.position, GunBarrel.rotation);
		}
	}

	void InstantiateVRLazer()
	{
		holder = new GameObject();
		holder.transform.parent = GunBarrel.transform;
		holder.transform.localPosition = Vector3.zero;

		pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
		pointer.transform.parent = holder.transform;
		pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
		pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
		BoxCollider collider = pointer.GetComponent<BoxCollider>();
		if (addRigidBody)
		{
			if (collider)
			{
				collider.isTrigger = true;
			}
			Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
			rigidBody.isKinematic = true;
		}
		else
		{
			if(collider)
			{
				Object.Destroy(collider);
			}
		}
		Material newMaterial = new Material(Shader.Find("Unlit/Color"));
		newMaterial.SetColor("_Color", color);
		pointer.GetComponent<MeshRenderer>().material = newMaterial;
	}
}
