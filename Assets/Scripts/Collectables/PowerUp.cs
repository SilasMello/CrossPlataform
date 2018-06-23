using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	
	public float powerUpTimer;
	public float jumpStrength;

	Character_Controller cc;

	// Use this for initialization
	void Start () {
		
		if (powerUpTimer <= 0)
		{
			powerUpTimer = 2.0f;
			
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("JumpForce not set on " + name + ". Defaulting to " + powerUpTimer);
		}

		if (jumpStrength <= 0)
		{
			jumpStrength = 5.0f;
			
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("JumpForce not set on " + name + ". Defaulting to " + jumpStrength);
		}

		if (!GetComponent<BoxCollider2D>())
		{
			gameObject.AddComponent<BoxCollider2D>();

			GetComponent<BoxCollider2D>().isTrigger = true;
		}
	}
	
	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			Character_Controller cc = c.GetComponent<Character_Controller>();
			if (cc)
			{
				cc.jumpForce += jumpStrength;

				StartCoroutine("stopPowerUp", cc);
			}

			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	IEnumerator stopPowerUp (Character_Controller c)
	{
		yield return new WaitForSeconds(powerUpTimer);

		cc.jumpForce -= jumpStrength;

		Destroy(gameObject);
	}
}
