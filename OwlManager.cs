using UnityEngine;
using System.Collections;

public class OwlManager : MonoBehaviour {

	public Animator anim;
	public AnimationClip time;
	public GameObject eye;
	float count = 0f;
	public AudioSource victory;
	public float hint = 0;
	public GameObject hintText;

	// Use this for initialization
	void Start () {
		CrossSceneScript.insertInventory("jewel");
	}
	
	// Update is called once per frame
	void Update () {
		hint += Time.deltaTime;
		if (eye.activeSelf) {
			anim.SetBool ("won", true);
			//Debug.Log ("hi");
		}
		if (anim.GetBool ("won")) {
			count += Time.deltaTime;
			//Debug.Log ("hi");
		}
		if (count > time.length - 0.1f) {
			anim.gameObject.SetActive(false);
			CrossSceneScript.insertInventory("helmet");
			victory.Play ();
		}
		if (hint > 20) {
			hintText.SetActive(true);
		}
	}
}
