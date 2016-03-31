using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour {

	public delegate void Endgame ();
	public static event Endgame endGame;

	private Animator anim;

	public AudioClip deathClip;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void PlayerDiedEndGame () {
		if (endGame != null)
			endGame ();

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Collector") {
			AudioSource.PlayClipAtPoint(deathClip, transform.position);
			PlayerDiedEndGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Zombie") {
			StartCoroutine(DiedAnim());
		}
	} 

	IEnumerator DiedAnim()
	{
		AudioSource.PlayClipAtPoint(deathClip, transform.position);
		anim.Play ("Death");
		yield return new WaitForSeconds(1);
		PlayerDiedEndGame ();

	}


} //Playerdied