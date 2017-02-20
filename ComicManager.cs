using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComicManager : MonoBehaviour {

	public Sprite[] comics = new Sprite[6];
	public Image screen;
	public AudioSource source;
	public AudioClip[] dialog = new AudioClip[3];
	float timer = 0;

	// Use this for initialization
	void Start () {
		source.clip = dialog [0];
		source.Play ();
		//timer = 29;

	}

	void FixedUpdate () {
			timer += Time.deltaTime;
			if (timer > 57.1 && timer < 57.4f) {
				source.Stop();
				Application.LoadLevel("Starting room2.0");
			} else if (timer > 49.1 && timer < 49.4f) {
				source.Stop();
				screen.sprite = comics[5];
				source.clip = dialog[2];
				source.Play();
			} else if (timer > 45.5f && timer < 45.8f) {
				screen.sprite = comics[4];
			} else if (timer > 42.6 && timer < 42.9f) {
				screen.sprite = comics[3];
			} else if (timer > 31 && timer < 31.3f) {
				source.Stop();
				screen.sprite = comics[2];
				source.clip = dialog[1];
				source.Play();
			} else if (timer > 17 && timer < 17.3f) {
				screen.sprite = comics[1];
			}
	}
}
