using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossSceneScript : MonoBehaviour {

	static public string[] inventory = new string[5];
	public Sprite[] sprites = new Sprite[5];
	public Image[] slots = new Image[4];
	static public bool mazeCompleted = false;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		int temp;
		foreach (string s in inventory) {
			if (s == null) {
				temp = i;
				for (int j = 0; j < inventory.Length - temp; j++) {
					inventory [temp] = inventory [j];
				}
			}
			i ++;
		}

		if (CrossSceneScript.contains ("jewel")) {
			slots [0].color = new Color (255, 255, 255, 255);
			slots [0].sprite = sprites [0];
		} else {
			slots [0].sprite = null;
			slots [0].color = new Color (255, 255, 255, 0);
		}
		if (CrossSceneScript.contains ("sandals")) {
			slots [1].color = new Color (255, 255, 255, 255);
			slots [1].sprite = sprites [1];
		} else {
			slots [1].sprite = null;
			slots [1].color = new Color (255, 255, 255, 0);
		}
		if (CrossSceneScript.contains ("helmet")) {
			slots [2].color = new Color (255, 255, 255, 255);
			slots [2].sprite = sprites [2];
		} else {
			slots [2].sprite = null;
			slots [2].color = new Color (255, 255, 255, 0);
		}
		if (CrossSceneScript.contains ("sword")) {
			slots [3].color = new Color (255, 255, 255, 255);
			slots [3].sprite = sprites [3];
		} else {
			slots [3].sprite = null;
			slots [3].color = new Color (255, 255, 255, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel ("Starting room2.0");
		} else if (Input.GetKeyDown (KeyCode.Keypad1)) {
			Application.LoadLevel ("Maze1.0");
		} else if (Input.GetKeyDown (KeyCode.Keypad2)) {
			Application.LoadLevel ("Rotation1.0");
		} else if (Input.GetKeyDown (KeyCode.Keypad3)) {
			Application.LoadLevel ("Combination1.0");
		} else if (Input.GetKeyDown (KeyCode.Keypad4)) {
			Application.LoadLevel ("OwlCloseup");
		}
	}

	public static void insertInventory (string item) {
		for (int i = 0; i < inventory.Length; i++){
			if (inventory[i] == null) {
				inventory [i] = item;
				break;
			}
		}

	}

	public static bool contains(string item){
		foreach (string s in inventory) {
			if (s == item){
				return true;
			}
		}
		return false;
	}

	public static void remove (string item) {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory[i] == item) {
				inventory[i] = null;
			}
		}
	}
}
