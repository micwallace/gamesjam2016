using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class DisableVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		VRSettings.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void disableVR(){
		
		VRSettings.enabled = false;
		SceneManager.LoadScene ("GameScene");
	}

	public void enableVR(){

		VRSettings.enabled = true;
		SceneManager.LoadScene ("GameScene");
	}
}
