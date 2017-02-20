using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickKinect : MonoBehaviour {

	public GameObject hand_right;
	public GameObject hand_left;
	private Vector2 area2D;
	private float counter;
	public Image timer_r;
	public Image timer_l;
	
	void Start () {
		area2D = new Vector2 (transform.position.x, transform.position.y);
	}

	void Update () {
		Vector3 selection_right = Camera.main.WorldToScreenPoint (hand_right.GetComponent<Transform>().position);
		Vector2 cursor_right = new Vector2 (selection_right.x, selection_right.y);
		Vector2 distance_right = cursor_right - area2D;
		Vector3 selection_left = Camera.main.WorldToScreenPoint (hand_left.GetComponent<Transform>().position);
		Vector2 cursor_left = new Vector2 (selection_left.x, selection_left.y);
		Vector2 distance_left = cursor_left - area2D;
		if (distance_right.magnitude < 50 || distance_left.magnitude < 50) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 50) {
				//timer = hand_left.GetComponentInChildren<Image>();
				timer_l.fillAmount = (1 - counter/2);
			} else if (distance_right.magnitude < 50) {
				//timer = hand_right.GetComponentInChildren<Image>();
				timer_r.fillAmount = (1 - counter/2);
			}
		} else {
			counter = 0;
			timer_r.fillAmount = 0;
			timer_l.fillAmount = 0;
		}
		if (counter > 2) {
			Application.LoadLevel ("Starting room2.0");
		}
	}
}
