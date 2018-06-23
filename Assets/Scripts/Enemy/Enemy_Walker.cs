using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy_Walker : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public bool isFacingLeft;		
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		/* Apneas necessário se não possuir Require Component 
		if(!rb)
		{
			rb = gameObject.AddComponent<Rigidbody21D>();
		}
		*/
		if(speed <= 0)
		{
			speed = 7.0f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("Speed not set on " + name + ". Defaulting to " + speed);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{
		if (isFacingLeft)
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		else
			rb.velocity = new Vector2 (speed, rb.velocity.y);
	}	

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "Enemy_Barrier")
			flip();
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Enemy")
			flip();
	}


	void flip()
	{
		isFacingLeft = !isFacingLeft;

		/*  OR
		if (isFacingLeft)
			isFacingLeft = false;
		else
			isFacingLeft = true;
		 */

		Vector3 scaleFactor = transform.localScale;

		scaleFactor.x = -scaleFactor.x;

		transform.localScale = scaleFactor;
	}
}
