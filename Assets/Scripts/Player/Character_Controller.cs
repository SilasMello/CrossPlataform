using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour {

	Rigidbody2D rb;			// or you can use: public Rigidbody2D rb2; (don't do it)

	[Range(1,25)]
	public float speed;
	[Range(1,25)]
	public float jumpForce;
	public bool isGrounded;
	public LayerMask isGroundLayer;
	public Transform groundCheck;
	public float groundCheckRadius;

	SpriteRenderer spriteRen;

	public AudioClip jump;
    public AudioClip fireball;

	Animator anim;

	// Variables to handle projectile firing
	public Transform projectileSpawnPoint;
	public Projectile projectilePrefab;
	public float projectileSpeed;
	public bool isFacingLeft;

	int _lives;

	Vector3 startPosition;


	// Use this for initialization
	void Start () 
	{
		spriteRen = GetComponent<SpriteRenderer>();

		// Method 1: Save a reference of Component in Scripit
		// - Component must be added in Inspector
		rb = GetComponent<Rigidbody2D>();

		// Check if the Component exist
		if(!rb)		// or if(rb == null)
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("Rigidbody2D not found on " + name);
		}

		if(speed <= 0)
		{
			speed = 5.0f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("Speed not set on " + name + ". Defaulting to " + speed);
		}

		if(jumpForce <= 0)
		{
			jumpForce = 5.0f;
			
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("JumpForce not set on " + name + ". Defaulting to " + jumpForce);
		}

		if(!groundCheck)		
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("GroundCheck not found on " + name);
		}

		if(groundCheckRadius <= 0)
		{
			groundCheckRadius = 0.2f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("GroundCheckRadius not set on " + name + ". Defaulting to " + groundCheckRadius);
		}

		anim = GetComponent<Animator>();
		if(!anim)	
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("Animator not found on " + name);
		}

		if(!projectilePrefab)		
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectilePrefab not found on " + name);
		}

		if(!projectileSpawnPoint)		
		{
			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectileSpawnPoint not found on " + name);
		}

		
		if(projectileSpeed <= 0)		
		{
			projectileSpeed = 7.0f;

			// Prints a message to Console (Shortcut: Control + Shift + C)
			Debug.LogWarning("ProjectileSpeed not found on " + name);
		}

		lives = 3;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float moveValue = Input.GetAxisRaw("Horizontal");			// Or you can use Input.GetAxisRaw (it less smothy than GetAxis)

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

		if(Input.GetButtonDown("Jump") && isGrounded)
		{

			rb.velocity = Vector2.zero; 

			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

			 Sound_Manager.instance.PlaySingleSound(jump);
		
		}

		anim.SetBool("Jump", !isGrounded );

		if(Input.GetButtonDown("Fire1"))		// or if(Input.GetButtonDown("LeftControl")
		{
			anim.SetBool("FireBall", true );

				FireBall ();
				
		}else
			anim.SetBool("FireBall", false );
			Debug.Log("Pew Pew");

		

		rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(moveValue));

		if(Input.GetKey ("x") && Input.GetKey ("z"))
		{
			anim.SetBool("Piss", true );
		}else
			anim.SetBool("Piss", false );


		if((moveValue > 0 && isFacingLeft) ||  (moveValue <  0 && !isFacingLeft))
			flip();

				/*	OR
				if(moveValue > 0 && isFacingLeft)
				{
					flip();
				}else if(moveValue <  0 && !isFacingLeft)
					flip();
				*/		
	
	
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

			Sound_Manager.instance.PlaySingleSound(fireball);

		}else if (isFacingLeft)
		{	Projectile temp = Instantiate (projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

			temp.Speed = - projectileSpeed; 

			Sound_Manager.instance.PlaySingleSound(fireball);
		}			
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log(c.gameObject.tag);

		if(c.gameObject.tag == "Collectibles")
		{
			Destroy(c.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		Destroy(projectilePrefab); 
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

	public void Restart()
	{
		transform.position = startPosition;
	}

	public int lives
	{
		get { return _lives; }			// Needs a variable		// or get; (Doesn't need a variable)
		set { _lives = value;			// Needs a variable		// or set; (Doesn't need a variable)
			Debug.Log("Lives changed to " + _lives);
			
			if (_lives <= 0)
			{
				Destroy(gameObject); 
				SceneManager.LoadScene ("GameOver");
			}
		}			
	}
}


