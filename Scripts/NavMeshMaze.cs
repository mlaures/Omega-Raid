using UnityEngine;
using System.Collections;

public class NavMeshMaze : MonoBehaviour {

	public Transform hand;
	public Transform hand_right;
	public Transform hand_left;
	static public bool r_l;
	public bool mouse;
	public NavMeshAgent diamond;

	// Use this for initialization
	void Start () {
	
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
			if (distance.magnitude < 10) {
				diamond.SetDestination (hand.position);
			}
		} else if (mouse == false) {
			Vector3 clickHand = Camera.main.WorldToScreenPoint (new Vector3 (hand.position.x, hand.position.y, transform.position.z));
			Vector3 clickObject = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 clickDistance = clickHand - clickObject;
			if (clickDistance.magnitude < 15) {
				mouse = true;
			}
		}

	}
}
