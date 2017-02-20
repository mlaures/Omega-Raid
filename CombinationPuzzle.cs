using UnityEngine;
using System.Collections;

public class CombinationPuzzle : MonoBehaviour {

	static public int num;
	public bool clicked;
	public float counter;
	public Transform hand_right;
	public Transform hand_left;
	private Vector3 start;
	private Vector3 end;
	public AudioSource click;
	public Texture[] textures = new Texture[2];

	// Use this for initialization
	void Start () {
		start = transform.position;
		end = transform.position - new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 mouse_right = new Vector2 (hand_right.position.x, hand_right.position.y);
		Vector2 mouse_left = new Vector2 (hand_left.position.x, hand_left.position.y);
		Vector2 area = new Vector2 (transform.position.x, transform.position.y);
		Vector2 distance_right = mouse_right - area;
		Vector2 distance_left = mouse_left - area;
		if (clicked == false) {
			if (distance_right.magnitude < 1 || distance_left.magnitude < 1) {
				counter += Time.deltaTime;
				GetComponent<Renderer>().material.mainTexture = textures[1];
			} else {
				counter = 0;
				GetComponent<Renderer>().material.mainTexture = textures[0];
			}
		}
		if (counter > 1.5f && clicked == false) {
			clicked = true;
			num += 1;
			click.Play();
		}

		if (clicked == true) {
			transform.position = end;
		} else if (clicked == false) {
			transform.position = start;
		}
	}
}
	