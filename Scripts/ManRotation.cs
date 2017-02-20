using UnityEngine;
using System.Collections;

public class ManRotation : MonoBehaviour {
	
	private float baseAngle = 0.0f;
	private float startAngle = 0.0f;
	private float angle;
	private float ran;
	public Transform hand;
	public Vector3 pointer;
	public AudioSource zoop;
	public AudioSource zweep;
	public bool canMove;
	bool moving;

	void Start () {
		ran = Mathf.Round (Random.Range (0, 360)/30)*30;
		transform.Rotate (0,ran,0);
		startAngle = 360 - ran;
		canMove = false;
		moving = false;
	}

	void Update(){
		pointer = Camera.main.WorldToScreenPoint (hand.position);
		if (canMove) {
			Move ();
		}
	}
	
	public void Click() {
		Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Camera.main.WorldToScreenPoint(hand.position) - dir;
		baseAngle = Mathf.Round((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg)/30)*30 - startAngle;
		zoop.Play ();
	}

	void Move() {
		Vector3 dir = Camera.main.WorldToScreenPoint (transform.position);
		dir = pointer - dir;
		angle = Mathf.Round((Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg)/30)*30 - baseAngle;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.down);
		moving = true;
	}

	public void Finish() {
		startAngle = angle;
		zoop.Stop ();
		moving = false;
	}
}
