using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HandFollow : MonoBehaviour {

	public Transform hand_left;
	public Transform hand_right;
	Vector3 hand_left_pos;
	Vector3 hand_right_pos;
	public Image right;
	public Image left;
	//public Image right_select;
	//public Image left_select;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		hand_left_pos = Camera.main.WorldToScreenPoint (hand_left.position);
		hand_right_pos = Camera.main.WorldToScreenPoint (hand_right.position);
		right.transform.position = (hand_right_pos);
		left.transform.position = (hand_left_pos);

		if (Application.loadedLevelName == "Maze1.0") {
			if (ManMoveMaze.r_l == false) {
				left.rectTransform.sizeDelta = new Vector2 (80,80);
			} else if (ManMoveMaze.r_l == true) {
				right.rectTransform.sizeDelta = new Vector2 (80,80);
			}
		}
	}
}
