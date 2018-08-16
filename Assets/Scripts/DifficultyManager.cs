using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	private PlayerDataManager playerStats;
	private CollisionDataManager collisionStats;

	private float difficulty;

	private float powerMax;

	private float averageDistanceToSquare;
	private int numberOfFillers;
	public float speed;

	private float currentDistanceToSquare;
	public float difficultyDifference;

	void Start () {
		playerStats = GameObject.Find ("Player").GetComponent<PlayerDataManager> ();
		collisionStats = GameObject.Find ("CollisionDataManager").GetComponent<CollisionDataManager> ();
		difficulty = 1;
		difficultyDifference = 0;
		speed = 4.0f;
	}

	void Update () {
		averageDistanceToSquare = collisionStats.averageDistanceToSquare;
		currentDistanceToSquare = collisionStats.currentDistanceToSquare;
		numberOfFillers = collisionStats.numberOfFillers;

		calculateDifficulty();
		calculateSpeed();
		setSpeed();
	}

	void calculateDifficulty() {
		if (currentDistanceToSquare > 14) {
			difficultyDifference = 0.008f;
			playerStats.scoreMultiplier = 1.8f;
		} else if (currentDistanceToSquare > 12) {
			difficultyDifference = 0.006f;
			playerStats.scoreMultiplier = 1.6f;
		} else if (currentDistanceToSquare > 10) {
			difficultyDifference = 0.004f;
			playerStats.scoreMultiplier = 1.4f;
		} else if (currentDistanceToSquare > 8) {
			difficultyDifference = 0.002f;
			playerStats.scoreMultiplier = 1.2f;
		} else if (currentDistanceToSquare > 6) {
			difficultyDifference -= 0.004f;
			playerStats.scoreMultiplier = 0.8f;
		} else if (currentDistanceToSquare > 5) {
			difficultyDifference -= 0.006f;
			playerStats.scoreMultiplier = 0.8f;
		} else if (currentDistanceToSquare > 2 && currentDistanceToSquare > 0) {
			difficultyDifference -= 0.008f;
			playerStats.scoreMultiplier = 0.6f;
		}
	}

	void calculateSpeed() {
		speed += difficultyDifference;
		difficultyDifference = 0;
	}

	void setSpeed() {
		if (speed > 3.5) {
			playerStats.speed = speed;
		}
	}
}