using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour
{
	public delegate void Endgame();
	public static event Endgame endGame;

	public AudioClip deathClip;

	void OnTriggerEnter2D(Collider2D target)
    {
		if (target.tag == "Collector" || target.tag == "Zombie")
        {
			AudioSource.PlayClipAtPoint(deathClip, transform.position);
			PlayerDiedEndGame();
		}
	}

     IEnumerator PlayerDiedEndGame()
    {
        if (endGame != null)
            endGame();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
} // PlayerDied