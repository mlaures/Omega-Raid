using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	private float baseAngle = 0.0f;
	private float startAngle = 0.0f;
	private float angle;
	private float ran;
	private bool mouse;
	public AudioSource zoop;
	public AudioSource zweep;

	void Start () {
		ran = Random.Range (0, 360);
		transform.Rotate (0,ran,0);
		mouse = false;
		startAngle = 360 - ran;
		//Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
		//dir = Input.mousePosition - dir;
		//startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - ran;
	}
	
	void OnMouseDown() {
		mouse = true;
		Debug.Log ("mousedown");
		Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - startAngle;
		zoop.Play ();
	}
	
	void OnMouseDrag() {
		if (mouse == true) {
			Vector3 dir = Camera.main.WorldToScreenPoint (transform.position);
			dir = Input.mousePosition - dir;
			angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - baseAngle;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.down);
		}
	}

	void OnMouseUp() {
		mouse = false;
		startAngle = angle;
		zoop.Stop ();
		zweep.Play ();
	}
}
