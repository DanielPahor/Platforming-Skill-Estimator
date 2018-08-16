using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

	public static bool isBuilding; 

	public GameObject FoundationPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && !isBuilding) {
			isBuilding = true;
			Instantiate(FoundationPrefab, Vector3.zero, FoundationPrefab.transform.rotation);
		}
	}
}
