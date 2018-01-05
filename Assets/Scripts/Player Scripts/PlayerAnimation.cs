using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
	private Animator anim;

	// Use this for initialization
	void Awake()
    {
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D target)
    {
        switch (target.gameObject.tag)
        {
            case "Obstacle":
                anim.Play("Idle");
                break;
            case "Zombie":
                anim.Play("Death");
                break;
        }
    }

    
	void OnCollisionExit2D(Collision2D target)
    {
		if (target.gameObject.tag == "Obstacle")
        {
			anim.Play ("Run");
		}
	}
} // PlayerAnimation