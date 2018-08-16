using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDataManager : MonoBehaviour {

	public float averageDistanceToSquare;
	private float totalDistanceToSquare;
	public float currentDistanceToSquare;
	public float collisionSuccessRate;

	public int numberOfFillers;

	void Start () {
		
	}

	void Update () {

	}

	public void updateDistanceToSquare(float distance) {
		updateNumberOfFillers();

		currentDistanceToSquare = distance;
		totalDistanceToSquare += distance;
		averageDistanceToSquare = totalDistanceToSquare/(float)numberOfFillers;
	}

	private void updateNumberOfFillers() {
		numberOfFillers++;
	}
}
