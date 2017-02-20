using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MazeGameManager : MonoBehaviour {

	public AudioSource victory;
	public Transform canvas;

	// Use this for initialization
	void Start () {
		if (CrossSceneScript.contains ("jewel")) {
			GameObject.Find ("Diamond").SetActive (false);
		} else {
			GameObject.Find ("Diamond").SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "jewel") {
			other.GetComponent<AudioSource>().Stop ();
			victory.Play ();
			CrossSceneScript.insertInventory("jewel");
			CrossSceneScript.mazeCompleted = true;
			Application.LoadLevel("Starting room2.0");
		}
	}
}
