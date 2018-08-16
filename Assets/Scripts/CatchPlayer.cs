using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchPlayer : MonoBehaviour {

	void Start() {

	}

	void OnTriggerEnter2D(Collider2D col) {
		SceneManager.LoadScene("Main");
	}
}
