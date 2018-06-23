using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (SceneManager.GetActiveScene().name == "GameOver")
			SceneManager.LoadScene ("Screem_Title");

		}
	}
}
