using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	public GameObject[] tileTypes;

	private int currentTile;
	private float currentTileSize;

	private bool hasSnapped;
	private int distanceToNextBlock;

	private float fillerX;
	private float fillerY;
	private float fillerZ;

	private GameObject platform;
	private GameObject player;

	private PlayerDataManager playerStats; 
	private CollisionDataManager collisionStats;
	private DifficultyManager difficultyManager;

	private float scoreAmount;

	private bool isCorrectFiller;

	private float collisionSuccessRate;
	private float collisionSuccessCount;
	private float collisionFailureCount;

	void Start() {
		playerStats = GameObject.Find("Player").GetComponent<PlayerDataManager>();
		collisionStats = GameObject.Find ("CollisionDataManager").GetComponent<CollisionDataManager>(); 
		player = GameObject.Find("Player");
		difficultyManager = GameObject.Find ("DifficultyManager").GetComponent<DifficultyManager> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		getCollisionData();

		if (!hasSnapped && distanceToNextBlock != currentTileSize) {
			collisionFailureCount++;
		}

		if (!hasSnapped && distanceToNextBlock == currentTileSize) {
			collisionSuccessCount++;
			snapToPlatform();
			updateDistanceToSquareAverage();
			hasSnapped = true;
			playerStats.addScore();
			difficultyManager.speed += 0.1f;
		}

		calculateCollisionSuccessRate();
	}

	void getCollisionData() {
		currentTile = GameObject.Find("Clicker").GetComponent<FollowMouse>().currentTile;
		currentTileSize = tileTypes[currentTile].GetComponent<BoxCollider2D>().size.x;

		platform = gameObject.transform.parent.transform.parent.gameObject;
		distanceToNextBlock = platform.GetComponent<PlatformDistance>().distanceToNextBlock;
	}

	void snapToPlatform() {
		fillerX = platform.transform.position.x + platform.GetComponent<BoxCollider2D>().size.x/2 + currentTileSize/2;
		fillerY = platform.transform.position.y;
		fillerZ = platform.transform.position.z;
		Vector3 snapTo = new Vector3(fillerX, fillerY, fillerZ);

		Instantiate(tileTypes[currentTile], snapTo, transform.rotation);

		playerStats.score += playerStats.scoreAmount * playerStats.scoreMultiplier;
	}

	void updateDistanceToSquareAverage() {
		collisionStats.updateDistanceToSquare(transform.position.x - player.transform.position.x);
	}

	void calculateCollisionSuccessRate() {
		collisionSuccessRate = collisionSuccessCount / collisionFailureCount;
	}
}