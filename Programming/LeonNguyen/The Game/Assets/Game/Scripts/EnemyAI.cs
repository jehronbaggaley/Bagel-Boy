using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform player;
	public float xOff;
	public float zOff;

	public Vector3 moveDirection;

	public CharacterController controller;

	public float moveSpeed;
	public float gravityScale;
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Vector3.Distance(transform.position, player.position)) < 100f) {
			transform.LookAt (player);
			transform.rotation = Quaternion.Euler (xOff, transform.rotation.eulerAngles.y, zOff);

			float yStore = moveDirection.y;
			moveDirection = -transform.up;
			moveDirection.y = 0;
			moveDirection = moveDirection.normalized * moveSpeed;
			moveDirection.y = yStore;

			if (controller.isGrounded) {
				moveDirection.y = 0f;
			}

			moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
			controller.Move (moveDirection * Time.deltaTime);
		}
	}
}
