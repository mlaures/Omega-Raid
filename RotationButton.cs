using UnityEngine;
using System.Collections;

public class RotationButton : MonoBehaviour {

	public ManRotation donut1;
	public ManRotation donut2;
	public ManRotation donut3;
	public Transform button1;
	public Transform button2;
	public Transform button3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 hand = new Vector2 (transform.position.x, transform.position.z);
		Vector2 b1 = new Vector2 (button1.position.x, button1.position.z);
		Vector2 b2 = new Vector2 (button2.position.x, button2.position.z);
		Vector2 b3 = new Vector2 (button3.position.x, button3.position.z);
		Vector2 distance1 = hand - b1;
		Vector2 distance2 = hand - b2;
		Vector2 distance3 = hand - b3;
		if (distance1.magnitude < 0.5f && donut1.canMove == false) {
			donut1.Click ();
			donut1.canMove = true;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 1;
		} else if (distance1.magnitude > 0.5f && donut1.canMove == true) {
			donut1.Finish ();
			donut1.canMove = false;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 0;
		} else if (distance2.magnitude < 0.5f && donut2.canMove == false) {
			donut2.Click ();
			donut2.canMove = true;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 2;
		} else if (distance2.magnitude > 0.5f && donut2.canMove == true) {
			donut2.Finish ();
			donut2.canMove = false;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 0;
		} else if (distance3.magnitude < 0.5f && donut3.canMove == false) {
			donut3.Click ();
			donut3.canMove = true;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 3;
		} else if (distance3.magnitude > 0.5f && donut3.canMove == true) {
			donut3.Finish ();
			donut3.canMove = false;
			GameObject.Find("GameController").GetComponent<RotationPuzzleController>().button = 0;
		}
	}
}
