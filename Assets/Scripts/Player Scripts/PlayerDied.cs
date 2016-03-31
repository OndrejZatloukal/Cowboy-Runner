using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour {

	public delegate void Endgame ();
	public static event Endgame endGame;



	void PlayerDiedEndGame () {
		if (endGame != null)
			endGame ();

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Collector") {
			PlayerDiedEndGame ();
		}
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Zombie") {
			PlayerDiedEndGame ();
		}
	} 


} //Playerdied