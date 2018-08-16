using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	private int distanceBetween;

	private float platformWidth;

	public int distanceBetweenMin;
	public int distanceBetweenMax;

	public GameObject[] platforms;
	private int platformSelector;
	private float[] platformWidths;

	private float currentWidth = 7;

	private BoxCollider2D childrenCollider;
	private GameObject child;
	private DifficultyManager difficultyManager;

	private int rand;

	// Use this for initialization
	void Start () {
		platformWidths = new float[platforms.Length];

		for (int i = 0; i < platforms.Length; i++) {
			platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
		}

		platform = GameObject.Find("start");
		currentWidth = 15;

		difficultyManager = GameObject.Find ("DifficultyManager").GetComponent<DifficultyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {

			if (difficultyManager.difficultyDifference == 0.008f || difficultyManager.difficultyDifference == 0.006f || difficultyManager.difficultyDifference == 0.004f) {
				distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax - 1);
			} else {
				distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			}

			platformSelector = Random.Range(0, platforms.Length);

			transform.position = new Vector3(transform.position.x + currentWidth/2 + distanceBetween + platformWidths[platformSelector]/2, transform.position.y, transform.position.z);

			platform.GetComponent<PlatformDistance>().distanceToNextBlock = distanceBetween;

//			childrenCollider = platform.transform.Find("Collider/EastCollider").GetComponent<BoxCollider2D>();
//			childrenCollider.size = new Vector2(distanceBetween, 1);

			platform = (GameObject)Instantiate(platforms[platformSelector], transform.position, transform.rotation);
				
			currentWidth = platformWidths[platformSelector];
		}
	}
}
