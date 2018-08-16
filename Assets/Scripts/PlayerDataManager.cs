using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour {

	private PlayerController player;

	public float averageDistanceFromLeft;

	public float speed; 

	public float averageGapSize;
	public float averagePlatformSize;

	public float difficulty;

	public float score; 
	public float scoreMultiplier;
	public float scoreAmount;

	void Start () {
		score = 0;
		scoreMultiplier = 1;
		difficulty = 1;
		speed = 4f;
		scoreAmount = 10;
	}

	void Update () {
		Debug.Log(difficulty);
	}

	public void addScore() {
		score += (scoreAmount * scoreMultiplier);
	}
}
