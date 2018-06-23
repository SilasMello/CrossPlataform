using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {

	public int numberOfCollectibles;
	public GameObject[] allCollectibles;

	public GameObject player;
	public GameObject finishLine;

	// Use this for initialization
	void Start () {

		allCollectibles = GameObject.FindGameObjectsWithTag("Collectibles");
		numberOfCollectibles = allCollectibles.Length;

		if (numberOfCollectibles <= 0)
		{
			Debug.Log("Add Collectibles to Scene or tage Collectibles as Collectibles");
		}

		player = GameObject.Find("Character_Mario");
		player = GameObject.FindGameObjectWithTag("Player");
		player = GameObject.FindWithTag("Player");

		finishLine = GameObject.Find("FinishLine");

		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player && finishLine)
		{
			float distanceToFinish = Vector2.Distance(player.transform.position, finishLine.transform.position);

			// or distanceToFinish = (player.transform.position - finishLine.transform.position).magnitude;

			Debug.Log(distanceToFinish); 
		}

		
	}
}
