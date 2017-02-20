using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewScenes : MonoBehaviour {

	public Transform hand_right;
	public Transform hand_left;
	public Vector3 areaButton;
	private Vector2 area2D;
	private float counter;
	public Image timer_r;
	public Image timer_l;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "comboportal")
			areaButton = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (300, 0, 0); 
		else if (gameObject.tag == "statueportal")
			areaButton = Camera.main.WorldToScreenPoint (transform.position) - new Vector3 (275, 0, 0); 
		else if (gameObject.tag == "mazeportal")
			areaButton = Camera.main.WorldToScreenPoint (transform.position) + new Vector3 (125, 0, 0);
		else if (gameObject.tag == "rotationportal")
			areaButton = Camera.main.WorldToScreenPoint (transform.position) - new Vector3 (100, 0, 0);
		else
			areaButton = Camera.main.WorldToScreenPoint (transform.position);
		area2D = new Vector2 (areaButton.x, areaButton.y);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 selection_right;
		Vector2 cursor_right;
		Vector2 distance_right;
		Vector3 selection_left;
		Vector2 cursor_left;
		Vector2 distance_left;
		selection_right = Camera.main.WorldToScreenPoint (hand_right.position);
		cursor_right = new Vector2 (selection_right.x, selection_right.y);
		distance_right = cursor_right - area2D;
		selection_left = Camera.main.WorldToScreenPoint (hand_left.position);
		cursor_left = new Vector2 (selection_left.x, selection_left.y);
		distance_left = cursor_left - area2D;
		
		if (gameObject.tag == "rotationportal" && (distance_right.magnitude < 50 || distance_left.magnitude < 50)) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 50) {
				timer_l.fillAmount = (1 - counter / 2);
			} else if (distance_right.magnitude < 50) {
				timer_r.fillAmount = (1 - counter / 2);
			}
			this.gameObject.GetComponentInChildren<Light> ().enabled = true;

		} else if (gameObject.tag == "mazeportal" && (distance_right.magnitude < 55 || distance_left.magnitude < 55)) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 55) {
				timer_l.fillAmount = (1 - counter / 2);
			} else if (distance_right.magnitude < 55) {
				timer_r.fillAmount = (1 - counter / 2);
			}
			this.gameObject.GetComponentInChildren<Light> ().enabled = true;

		} else if (gameObject.tag == "comboportal" && (distance_right.magnitude < 50 || distance_left.magnitude < 50)) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 50) {
				timer_l.fillAmount = (1 - counter / 2);
			} else if (distance_right.magnitude < 50) {
				timer_r.fillAmount = (1 - counter / 2);
			}
			this.gameObject.GetComponentInChildren<Light> ().enabled = true;

		} else if (gameObject.tag == "owlportal" && (distance_right.magnitude < 50 || distance_left.magnitude < 50)) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 50) {
				timer_l.fillAmount = (1 - counter / 2);
			} else if (distance_right.magnitude < 50) {
				timer_r.fillAmount = (1 - counter / 2);
			}
			this.gameObject.GetComponentInChildren<Light> ().enabled = true;

		} else if (gameObject.tag == "statueportal" && (distance_right.magnitude < 60 || distance_left.magnitude < 60)) {
			counter += Time.deltaTime;
			if (distance_left.magnitude < 50) {
				timer_l.fillAmount = (1 - counter / 2);
			} else if (distance_right.magnitude < 50) {
				timer_r.fillAmount = (1 - counter / 2);
			}
			this.gameObject.GetComponentInChildren<Light> ().enabled = true;

		} else {
			counter = 0;
			timer_l.fillAmount = 0;
			timer_r.fillAmount = 0;
			foreach(Light l in gameObject.GetComponentsInChildren<Light>()) {
				l.enabled = false;
			}
		}
		if (counter > 2) {
			select();
		}
	}

	void select () {

		if (gameObject.tag.ToLower () == "rotationportal") {
			Application.LoadLevel ("Rotation1.0");
		} else if (gameObject.tag.ToLower () == "mazeportal") {
			Application.LoadLevel ("Maze1.0");
		} else if (gameObject.tag.ToLower () == "comboportal") {
			Application.LoadLevel ("Combination1.0");
		} else if (gameObject.tag.ToLower () == "owlportal") {
			Application.LoadLevel ("OwlCloseup");
		} else if (gameObject.tag.ToLower () == "statueportal") {
			Application.LoadLevel ("Statue");
		}
	}
}
