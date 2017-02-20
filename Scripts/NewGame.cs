using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {

	public Transform hand_right;
	public Transform hand_left;
	private Vector3 areaButton;
	private Vector2 area2D;
	private float counter;
	public Image timer_r;
	public Image timer_l;	
	
	// Use this for initialization
	void Start () {
		area2D = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 selection_right = Camera.main.WorldToScreenPoint (hand_right.position);
		Vector2 cursor_right = new Vector2 (selection_right.x, selection_right.y);
		Vector2 distance_right = cursor_right - area2D;
		Vector3 selection_left = Camera.main.WorldToScreenPoint (hand_left.position);
		Vector2 cursor_left = new Vector2 (selection_left.x, selection_left.y);
		Vector2 distance_left = cursor_left - area2D;
		if (distance_right.magnitude < 45 || distance_left.magnitude < 45) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 45) {
				timer_l.fillAmount = (1 - counter/2);
			} else if (distance_right.magnitude < 45) {
				timer_r.fillAmount = (1 - counter/2);
			}
		}
		if (Input.GetKeyDown("p"))
			Application.LoadLevel("Combination1.0");
		if (counter > 2) {
			if (this.gameObject.tag == "start") {
				Application.LoadLevel ("Comic1");
			} else if (this.gameObject.tag == "quit") {
				Application.Quit();
			}
		}
	}
}
