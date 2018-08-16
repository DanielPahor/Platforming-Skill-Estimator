using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidBody;
	private PlayerDataManager playerStats;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		playerStats = gameObject.GetComponent("PlayerDataManager") as PlayerDataManager;

		Physics2D.IgnoreCollision(GameObject.Find("Clicker").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
	}

	// Update is called once per frame
	void Update () {
		myRigidBody.velocity = new Vector2(playerStats.speed, myRigidBody.velocity.y);
	}
}
