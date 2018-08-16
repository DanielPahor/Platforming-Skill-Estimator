using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUIManager : MonoBehaviour {

	private PlayerDataManager playerStats;
	private float score;
	private float scoreMultiplier;

	// Use this for initialization
	void Start () {
		playerStats = GameObject.Find("Player").GetComponent<PlayerDataManager>();
	}
	
	// Update is called once per frame
	void Update () {
		fetchData();
	}

	void OnGUI() {
		displayData();
	}

	void fetchData() {
		score = playerStats.score;
		scoreMultiplier = playerStats.scoreMultiplier;
	}

	void displayData() {
		GUI.Label(new Rect(600, 10, 100, 200), "User Data");
		GUI.Label(new Rect(600, 30, 100, 200), "Score: " + score);
		GUI.Label(new Rect(600, 50, 100, 200), "Speed: " + playerStats.speed);
	}
}
