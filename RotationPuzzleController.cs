using UnityEngine;
using System.Collections;

public class RotationPuzzleController : MonoBehaviour {

	public int button = 0;
	public GameObject[] donuts;
	public Texture[] textures = new Texture[6];
	private int count;
	public int win = 0;
	public AudioSource victory;
	private float centre;
	private float first;
	private float second;
	public Animator anim;
	public AnimationClip time;
	float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (button != 0) {
			if (button == 1) {
				GameObject.Find ("PressMe").GetComponent<Renderer> ().material.mainTexture = textures [1];
			} else if (button == 2) {
				GameObject.Find ("PressMeToo").GetComponent<Renderer> ().material.mainTexture = textures [3];
			} else if (button == 3) {
				GameObject.Find ("PressMeThweeeeeeeeee").GetComponent<Renderer> ().material.mainTexture = textures [5];
			}
		} else {
			GameObject.Find ("PressMe").GetComponent<Renderer>().material.mainTexture = textures[0];
			GameObject.Find ("PressMeToo").GetComponent<Renderer>().material.mainTexture = textures[2];
			GameObject.Find ("PressMeThweeeeeeeeee").GetComponent<Renderer>().material.mainTexture = textures[4];
		}
		count = 0;
		if (win != 2) {
			centre = ((donuts[2].transform.rotation.y * Mathf.Rad2Deg)%360);
			first = ((donuts[0].transform.rotation.y * Mathf.Rad2Deg)%360) - centre;
			second = ((donuts[1].transform.rotation.y * Mathf.Rad2Deg)%360) - first;
//			Debug.Log (centre);
//			Debug.Log (first);
//			Debug.Log (second);
			if (Mathf.Abs(first) < 2 && Mathf.Abs(second) < 2) {
				win = 1;
			}

			/*foreach (GameObject g in donuts) {
				if (Mathf.Abs (g.transform.rotation.y * Mathf.Rad2Deg) < 5) {
					count += 1;
				}
			}
			if (count == 3) {
				win = 1;
			}*/
		}
		if (win == 1) {
			finish ();
		}
		if (win == 2) {
			timer += Time.deltaTime;
		}
		if (timer > time.length) {
			anim.gameObject.SetActive (false);
			CrossSceneScript.insertInventory("sandals");
		}
	}

	void finish () {

		foreach (GameObject r in donuts) {
			//r.GetComponent<ManRotation>().zoop.Stop();
			r.GetComponent<ManRotation>().enabled = false;
			r.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
		win = 2;
		victory.Play ();
		anim.SetBool ("won", true);
	}
}
