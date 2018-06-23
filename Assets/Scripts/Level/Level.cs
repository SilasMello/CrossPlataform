using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public int spawnLocation;		// can be used public Transform/Vector3/GameObject spawnLocation; if it was used on GameManager.



	// Use this for initialization
	void Awake () 
	{
		if (spawnLocation < 0)
			spawnLocation = 0;

		GameManager.instance.spawnPlayer (spawnLocation);

		GameManager.instance.scoreText = GameObject.Find("Score_Text").GetComponent<Text>();

		GameManager.instance.score = 0;

			
		Debug.Log ("Where is the player");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
