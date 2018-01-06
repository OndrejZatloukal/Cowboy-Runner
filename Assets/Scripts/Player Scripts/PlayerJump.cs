using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
	[SerializeField] private AudioClip jumpClip;

    private Animator anim;

    private Rigidbody2D myBody;

    private Button jumpBtn;

    private float jumpForce = 12f, forwardForce = 0f;
    private bool isAlive = true;
	private bool canJump;

	void Awake()
    {
		myBody = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();

		jumpBtn = GameObject.Find("Jump Button").GetComponent<Button> ();

		jumpBtn.onClick.AddListener (() => RespondToJumpInput());
	}

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Zombie")
        {
            isAlive = false;
        }
    }

    void Update()
    {
        CheckIfNotStuckAndAlive();
    }

    private void CheckIfNotStuckAndAlive()
    {
        if (Mathf.Abs(myBody.velocity.y) == 0 && isAlive == true)
        {
            canJump = true;
        }
    }

    public void RespondToJumpInput()
    {

		if (canJump)
        {
			canJump = false;

			AudioSource.PlayClipAtPoint(jumpClip, transform.position);
			anim.Play ("Jump");

			if(transform.position.x < 0)
            {
				forwardForce = 1f;
			}
            else
            {
				forwardForce = 0f;
			}

			myBody.velocity = new Vector2(forwardForce, jumpForce);
		}
    }
} //PlayerJump































































