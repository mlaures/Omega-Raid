using UnityEngine;
using System.Collections;

public class InventoryTransfer : MonoBehaviour {

	public Transform hand_right;
	public Transform hand_left;
	public Transform[] sceneObjects = new Transform[3];
	public Transform[] inventoryObject = new Transform[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "OwlCloseup") {
			Vector3 hand_l_screen = Camera.main.WorldToScreenPoint (hand_left.position);
			Vector3 hand_r_screen = Camera.main.WorldToScreenPoint (hand_right.position);
			Vector3 thing_screen = Camera.main.WorldToScreenPoint (sceneObjects [0].position);
			Vector2 r_distance = new Vector2 (hand_r_screen.x, hand_r_screen.y) - new Vector2 (thing_screen.x, thing_screen.y);
			Vector2 l_distance = new Vector2 (hand_l_screen.x, hand_l_screen.y) - new Vector2 (inventoryObject [0].position.x, inventoryObject [0].position.y);

			if (r_distance.magnitude < 10 || l_distance.magnitude < 25) {
				CrossSceneScript.remove ("jewel");
				sceneObjects[0].gameObject.SetActive(true);
			}
		} else if (Application.loadedLevelName == "Statue_thing") {
			Vector3 hand_l_screen = Camera.main.WorldToScreenPoint (hand_left.position);
			Vector3 hand_r_screen = Camera.main.WorldToScreenPoint (hand_right.position);

			Vector3 sandals_screen = Camera.main.WorldToScreenPoint (sceneObjects [0].position);
			Vector2 r_distance_sandals = new Vector2 (hand_r_screen.x, hand_r_screen.y) - new Vector2 (sandals_screen.x, sandals_screen.y);
			Vector2 l_distance_sandals = new Vector2 (hand_l_screen.x, hand_l_screen.y) - new Vector2 (inventoryObject [0].position.x, inventoryObject [0].position.y);
			if (r_distance_sandals.magnitude < 30 || l_distance_sandals.magnitude < 25) {
				CrossSceneScript.remove ("sandals");
				sceneObjects[0].gameObject.SetActive(true);
			}

			Vector3 helmet_screen = Camera.main.WorldToScreenPoint (sceneObjects [1].position);
			Vector2 r_distance_helmet = new Vector2 (hand_r_screen.x, hand_r_screen.y) - new Vector2 (helmet_screen.x, helmet_screen.y);
			Vector2 l_distance_helmet = new Vector2 (hand_l_screen.x, hand_l_screen.y) - new Vector2 (inventoryObject [1].position.x, inventoryObject [1].position.y);
			if (r_distance_helmet.magnitude < 25 || l_distance_helmet.magnitude < 25) {
				CrossSceneScript.remove ("helmet");
				sceneObjects[1].gameObject.SetActive(true);
			}

			Vector3 sword_screen = Camera.main.WorldToScreenPoint (sceneObjects [2].position);
			Vector2 r_distance_sword = new Vector2 (hand_r_screen.x, hand_r_screen.y) - new Vector2 (sword_screen.x, sword_screen.y);
			Vector2 l_distance_sword = new Vector2 (hand_l_screen.x, hand_l_screen.y) - new Vector2 (inventoryObject [2].position.x, inventoryObject [2].position.y);
			if (r_distance_sword.magnitude < 50 || l_distance_sword.magnitude < 25) {
				CrossSceneScript.remove ("sword");
				sceneObjects[0].gameObject.SetActive(true);
			}
		}
	}
}
