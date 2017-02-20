using UnityEngine;
using System.Collections;

public class StatueManager : MonoBehaviour {

	bool[] items = new bool[3];
	public Animator anim;
	public AnimationClip time;
	private float timer = 0f;
	bool done = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Sandals").activeSelf) {
			items[0] = true;
		}
		if (GameObject.Find ("HelmOfInvisibility").activeSelf) {
			items[1] = true;
		}
		if (GameObject.Find ("sWOOOORD").activeSelf) {
			items[2] = true;
		}
		if (checkVictory () && !done) {
			anim.SetBool("won", true);

			done = true;
		}
		if (done) {
			timer += Time.deltaTime;
		}
		if (timer > time.length)
			Application.LoadLevel ("Final Scene1.0");
	}

	bool checkVictory() {
		foreach (bool b in items) {
			if (!b) {
				return false;
			}
		}
		return true;
	}
}
