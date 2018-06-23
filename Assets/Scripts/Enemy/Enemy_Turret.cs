using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour {

	public Transform projectileSpawnPoint;
	public Projectile projectilePrefab;
	public float projectileSpeed;
	public float projectileFireRate;
	float timeSinceLastFire = 0.0f;
	public bool isFacingLeft;
	public int health; 
	public GameObject player;
	public float minDistance;

	// Use this for initialization
	void Start () {

		if(!projectileSpawnPoint)		
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectileSpawnPoint not found on " + name);
		}

		if(!projectilePrefab)		
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectilePrefab not found on " + name);
		}

		if(projectileSpeed <= 0)		
		{
			projectileSpeed = 7.0f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectileSpeed not found on " + name);
		}

		if (health == 5)
		{
			health = 5;
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		
	}

	void FixedUpdate ()
	{
		if (player)
		{
			float distanceToFinish = Vector2.Distance(player.transform.position, transform.position);

			// or distanceToFinish = (player.transform.position - finishLine.transform.position).magnitude;

			if (distanceToFinish > minDistance)
			{
				return;
			}

			if (Time.time > timeSinceLastFire + projectileFireRate)
			{
				isFacingLeft = player.transform.position.x < transform.position.x;

				FireBall();

				timeSinceLastFire = Time.time;	
			}
		}
	}

	void FireBall ()
	{

		if (!isFacingLeft)
		{
			Projectile temp = Instantiate (projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

			// temp.GetComponent <Rigidbody2D> ().velocity = new Vector2 (projectileSpeed, 0);	
			// temp.GetComponent <Rigidbody2D> ().velocity = Vector2.right * projectileSpeed;
			// temp.GetComponent <Rigidbody2D> ().velocity = projectileSpawnPoint.right * projectileSpeed;

			temp.Speed = projectileSpeed; 
			temp.tag = "Enemy_Projectile"; 

		}else if (isFacingLeft)
		{	Projectile temp = Instantiate (projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

			temp.Speed = - projectileSpeed; 
			temp.tag = "Enemy_Projectile"; 

		}			
	}

	void OnCollisionEnter2D (Collision2D c)
	{
		if (c.gameObject.tag == "Player_Projectile")
		{
			health--;

			if (health <0)
			{
				Destroy(gameObject);
			}
		}
	}
}
