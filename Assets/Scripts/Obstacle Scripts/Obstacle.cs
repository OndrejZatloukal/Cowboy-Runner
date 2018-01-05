using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
	public float speed = -3f;

	private Rigidbody2D myBody;


	void Start()
    {
		myBody = GetComponent <Rigidbody2D> ();
	}
	

	void Update()
    {
		myBody.velocity = new Vector2 (speed, 0f);
	}
}
