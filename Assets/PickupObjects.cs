using UnityEngine;
using System.Collections;

public class PickupObjects : MonoBehaviour {

	Camera mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;

	// Use this for initialization
	void Start () {

		mainCamera = Camera.main;
	}

	// Update is called once per frame
	void Update () {

		if (carrying) {

			carry (carriedObject);
		} else {

			pickup();
		}
	}

	void carry(GameObject o){
		
		o.GetComponent<Rigidbody>().isKinematic = true;
		o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	void pickup(){

		if(Input.GetKeyDown(KeyCode.E)){

			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.ScreenPointToRay (new Vector3(x, y));
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)){

				Pickupable p = hit.collider.GetComponent<Pickupable>();

				if(p != null){

					carrying = true;
					carriedObject = p.gameObject;
				}
			}
		}
	}
}
