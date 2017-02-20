using UnityEngine;
using System.Collections;

public class StartingScreenManager : MonoBehaviour {

	public int load;
	public bool test = false;

	// Use this for initialization
	void Start () {
		//CrossSceneScript.insertInventory("sandals");
		//CrossSceneScript.insertInventory("helmet");
		if (CrossSceneScript.mazeCompleted) {
			GameObject.Find ("Maze/Diamond (1)").SetActive (false);
		} else {
			GameObject.Find ("Maze/Diamond (1)").SetActive (true);
		}
		if (CrossSceneScript.contains ("helmet")) {
			GameObject.Find ("Diamond (1)").SetActive (true);
		} else {
			GameObject.Find ("Diamond (1)").SetActive (false);
		}
		if (CrossSceneScript.contains ("sandals")) {
			GameObject.Find ("PegasusCompleted").SetActive (true);
			GameObject.Find ("PegasusScrambled").SetActive (false);
		} else {
			GameObject.Find ("PegasusCompleted").SetActive (false);
			GameObject.Find ("PegasusScrambled").SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (load == 1) {
			Application.LoadLevel ("Maze1.0");
		} else if (load == 2) {
			Application.LoadLevel ("Rotation1.0");
		}
		//Debug.Log (CrossSceneScript.inventory[0]);
		//Debug.Log (CrossSceneScript.inventory [1]);
		//Debug.Log (CrossSceneScript.inventory [2]);
	}

	void setLoad (int l) {
		load = l;
	}
}
