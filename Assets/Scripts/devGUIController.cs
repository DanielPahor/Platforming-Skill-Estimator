using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devGUIController : MonoBehaviour {

	private PlayerDataManager playerStats;
	private CollisionDataManager collisionStats;

	private float speed; 
	private float averageGapSize;
	private float averagePlatformSize;

	private float averageDistanceFromSquare;
	private float collisionSuccessRate;
	private int fillerBlocksPlaced;

	private float difficulty;

	void Start() {
		playerStats = GameObject.Find("Player").GetComponent<PlayerDataManager>();
		collisionStats = GameObject.Find("CollisionDataManager").GetComponent<CollisionDataManager>();
	}

	void Update() {
		fetchData();
	}

	void OnGUI() {
		displayData();
	}

	void fetchData() {
		speed = playerStats.speed;
		fillerBlocksPlaced = collisionStats.numberOfFillers;
		averageDistanceFromSquare = collisionStats.averageDistanceToSquare;
		collisionSuccessRate = collisionStats.collisionSuccessRate;
	}

	void displayData() {
		GUI.Label(new Rect(10, 10, 100, 200), "Dev Data");
		GUI.Label(new Rect(10, 30, 300, 20), "Difficulty measures");
		GUI.Label(new Rect(12, 50, 100, 20), "Speed: " + speed);
		GUI.Label(new Rect(10, 70, 300, 20), "Difficulty calculation data");
		GUI.Label(new Rect(12, 90, 300, 20), "Average distance from square: " + averageDistanceFromSquare);
		GUI.Label(new Rect(12, 110, 300, 20), "Filler blocks placed: " + fillerBlocksPlaced);
	}
}