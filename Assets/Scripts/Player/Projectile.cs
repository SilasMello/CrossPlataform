using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float Speed;

	public float LifeTime; 

	// Use this for initialization
	void Start () {

		if(LifeTime <= 0)		
		{
			LifeTime = 2.0f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("LifeTime not found on " + name + ". Defaulting to " + LifeTime);
		}
		
		GetComponent <Rigidbody2D> ().velocity = new Vector2 (Speed, 0);	

		Destroy(gameObject, LifeTime);

		if (Speed > 0)
		{
			transform.localScale = new Vector3 (-1,1,1);
		}
		else
		{
			transform.localScale = Vector3.one;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Destroy(gameObject); 

		if (c.gameObject.tag == "Player")
		{
			Character_Controller cc = c.gameObject.GetComponent<Character_Controller>();
			if (cc)
			{
				cc.lives--;
			}
		}
	}
	
}
