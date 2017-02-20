using UnityEngine;
using System.Collections;

public class GameControllerCombination : MonoBehaviour {

	public CombinationPuzzle obj1;
	public CombinationPuzzle obj2;
	public CombinationPuzzle obj3;
	public GameObject[] buttons;
	private bool right;
	public AudioSource victory;
	public AudioSource lose;
	public float hint = 0;
	public GameObject hintText;
	public Animator anim;
	public AnimationClip time;
	float timer = 0;
	public bool won = false;

	// Use this for initialization
	void Start () {
		buttons = GameObject.FindGameObjectsWithTag ("symbol");
	}
	
	// Update is called once per frame
	void Update () {
		hint += Time.deltaTime;
		if (obj1.clicked == true && obj2.clicked == true && obj3.clicked == true) {
			right = true;
		} else {
			right = false;
		}

		if (CombinationPuzzle.num == 3 && right == false) {
			lose.Play ();
			StartCoroutine(reset ());
			CombinationPuzzle.num = 0;
		} else if (CombinationPuzzle.num == 3 && right == true) {
			anim.SetBool ("won", true);
			won = true;
			victory.Play ();
			CombinationPuzzle.num = 4;
		}
		if (won) {
			timer += Time.deltaTime;
		}
		if (timer > time.length) {
			CrossSceneScript.insertInventory ("sword");
			anim.gameObject.SetActive(false);
		}

		if (hint > 20) {
			hintText.SetActive (true);
		}
	}

	IEnumerator reset () {
		yield return new WaitForSeconds (lose.clip.length);
		foreach (GameObject s in buttons) {
			s.GetComponent<CombinationPuzzle> ().clicked = false;
			s.GetComponent<CombinationPuzzle> ().counter = 0;
		}
	}
}
