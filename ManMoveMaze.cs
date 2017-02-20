using UnityEngine;
using System.Collections;

public class ManMoveMaze : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 curPosition;
	private Rigidbody myBody;
	public bool mouse;
	public int maxSpeed;
	public Transform hand;
	public Transform hand_right;
	public Transform hand_left;
	static public bool r_l;
	public AudioSource zwop;
	
	// Use this for initialization
	void Start () {
		mouse = false;
		myBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance_right = hand_right.position - transform.position;
		Vector3 distance_left = hand_left.position - transform.position;
		if (distance_right.magnitude > distance_left.magnitude) {
			hand = hand_left;
			r_l = true;
		} else {
			hand = hand_right;
			r_l = false;
		}

		if (mouse == true) {
			Vector3 distance = hand.position - transform.position;
			float xDistance = Mathf.Abs (distance.x);
			float yDistance = Mathf.Abs (distance.y);
			if (xDistance > yDistance) {
				if (transform.position.x > hand.position.x) {
					myBody.AddForce (new Vector3 (-1f, 0, 0));
				} else if (transform.position.x < hand.position.x) {
					myBody.AddForce (new Vector3 (1f, 0, 0));
				}
				myBody.velocity -= new Vector3(0, myBody.velocity.y, 0);
				if (myBody.velocity.x > maxSpeed) {
					myBody.velocity = new Vector3(maxSpeed, 0, 0);
				}
			} else if (yDistance > xDistance) {
				if (transform.position.y > hand.position.y) {
					myBody.AddForce (new Vector3 (0, -1f, 0));
				} else if (transform.position.y < hand.position.y) {
					myBody.AddForce (new Vector3 (0, 1f, 0));
				}
				myBody.velocity -= new Vector3(myBody.velocity.x, 0, 0);
				if (myBody.velocity.y > maxSpeed) {
					myBody.velocity = new Vector3(0, maxSpeed, 0);
				}
			}
		} else if (mouse == false) {
			Vector3 clickHand = Camera.main.WorldToScreenPoint (new Vector3 (hand.position.x, hand.position.y, transform.position.z));
			Vector3 clickObject = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 clickDistance = clickHand - clickObject;
			if (clickDistance.magnitude < 15) {
				mouse = true;
				zwop.Play ();
			}
		}
	}

	void OnCollisionExit (Collision other) {
		myBody.velocity = Vector3.zero;
	}
}
