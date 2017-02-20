using UnityEngine;
using System.Collections;

public class MoveForce : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 curPosition;
	private Rigidbody myBody;
	public bool mouse;
	public int maxSpeed;
	
	// Use this for initialization
	void Start () {
		mouse = false;
		myBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
		Vector3 distance = curPosition - transform.position;
		float xDistance = Mathf.Abs (distance.x);
		float yDistance = Mathf.Abs (distance.y);
		if (mouse == true) {
			if (xDistance > yDistance) {
				if (transform.position.x > curPosition.x) {
					myBody.AddForce (new Vector3 (-.5f, 0, 0));
				} else if (transform.position.x < curPosition.x) {
					myBody.AddForce (new Vector3 (.5f, 0, 0));
				}
				myBody.velocity -= new Vector3(0, myBody.velocity.y, 0);
				if (myBody.velocity.x > maxSpeed) {
					myBody.velocity = new Vector3(maxSpeed, 0, 0);
				}
			} else if (yDistance > xDistance) {
				if (transform.position.y > curPosition.y) {
					myBody.AddForce (new Vector3 (0, -.5f, 0));
				} else if (transform.position.y < curPosition.y) {
					myBody.AddForce (new Vector3 (0, .5f, 0));
				}
				myBody.velocity -= new Vector3(myBody.velocity.x, 0, 0);
				if (myBody.velocity.y > maxSpeed) {
					myBody.velocity = new Vector3(0, maxSpeed, 0);
				}
			}
		}
		//Vector3 vel = myBody.velocity;
		//if (Mathf.Abs(vel.x) > )

		if (mouse == false) {
			myBody.velocity = new Vector3(0, 0, 0);
		}
	}

	void OnMouseDown () {
		Debug.Log ("mousedown");
		if (mouse == false) {
			mouse = true;
			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			//Debug.Log ("true");
		} else if (mouse == true) {
			mouse = false;
			//Debug.Log ("false");
		}
	}

	void OnCollisionExit (Collision other) {
		myBody.velocity = Vector3.zero;
	}
}
