using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class DisableVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void disableVR(){
		
		VRSettings.enabled = false;
	}

	public void enableVR(){

		VRSettings.enabled = true;
	}
}
