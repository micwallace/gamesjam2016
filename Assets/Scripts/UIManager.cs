using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void start(){

		SceneManager.LoadScene ("GameScene");
	}

	public void quit(){

		Application.Quit ();
	}
}
