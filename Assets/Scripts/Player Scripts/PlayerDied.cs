using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour
{
	public delegate void Endgame();
	public static event Endgame endGame;

	public AudioClip deathClip;

	void OnTriggerEnter2D(Collider2D target)
    {
		if (target.tag == "Collector")
        {
            StartCoroutine(PlayerDiedEndGame());
        }
	}

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Zombie")
        {
            StartCoroutine(PlayerDiedEndGame());
        }
    }

    IEnumerator PlayerDiedEndGame()
    {
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        if (endGame != null)
            endGame();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
} // PlayerDied