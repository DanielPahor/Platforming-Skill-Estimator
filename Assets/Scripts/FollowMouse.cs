using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	public int currentTile = 0;

	private float currentX;
	private float currentY;

	public Sprite sprite0, sprite1, sprite2;

	public ArrayList validPositions;

	BoxCollider2D collider;

	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));

		if (Input.GetMouseButtonDown(0)) {
			if (currentTile == 0) {
				currentTile = 1;
				gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
				collider = gameObject.GetComponent<BoxCollider2D>();
				collider.size = new Vector2(2,1);
			} else if (currentTile == 1) {
				currentTile = 2;
				gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
				collider = gameObject.GetComponent<BoxCollider2D>();
				collider.size = new Vector2(2,1);
			} else {
				currentTile = 0;
				gameObject.GetComponent<SpriteRenderer>().sprite = sprite0;
				collider = gameObject.GetComponent<BoxCollider2D>();
				collider.size = new Vector2(2,1);
			}
		}
	}
}
