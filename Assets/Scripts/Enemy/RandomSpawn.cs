using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
	GameObject[] powerUps;
	int numberOfPowerUps;

	void Start ()
	{
		powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
		numberOfPowerUps = powerUps.Length;
		Instantiate(powerUps[Random.Range(0, numberOfPowerUps)], this.transform.position,this.transform.rotation);
		
	}}

