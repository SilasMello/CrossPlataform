using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	static GameManager _instance = null;
	int _score;
	public Text scoreText;

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () 
	{
		if (instance)
			Destroy (gameObject);

		else
		{
			instance = this;

			DontDestroyOnLoad (this);
		}

		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (SceneManager.GetActiveScene().name == "Screem_Title")
			SceneManager.LoadScene ("Level1");

			if (SceneManager.GetActiveScene().name == "Level1")
			SceneManager.LoadScene ("Screem_Title");
		}
	}

	public void spawnPlayer(int spawnLocation)		// can use (Transform/Vector3/GameObject spawnLocation)
	{
		string spawnPointName = SceneManager.GetActiveScene().name
			+ "_" + spawnLocation;

		Transform spawnPointTransform = GameObject.Find (spawnPointName).GetComponent<Transform>();

		if (playerPrefab && spawnPointTransform)
		{
			Instantiate (playerPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
		}
	}

	public static GameManager instance
	{
		get { return _instance; }			
		set { _instance = value; }		
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void QuitGame()
	{
		Debug.Log("Quitting...");
		Application.Quit();
	}

	public int score
	{
		get { return _score; }			// or just use get; (don't need the variable on the top)
		set { _score = value;		// or just use set; (don't need the variable on the top)
			if (scoreText)
			{
				scoreText.text = "Score: " + score;	
			}
		}	
	}
}
