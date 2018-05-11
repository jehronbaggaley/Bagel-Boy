using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaguetteAI : MonoBehaviour {

	public Transform player;
	public float xOff;
	public float zOff;

	private Vector3 moveDirection;

	public CharacterController controller;

	public float moveSpeed;
	public float gravityScale;

	public float changeTime;
	private float changeCounter;

	public int aiMode;

	// Update is called once per frame
	void Start () {
		GameObject tempObj = GameObject.Find ("PlayerController");
		player = tempObj.transform;
		changeCounter = changeTime;
	}

	void Update () {
		changeCounter -= Time.deltaTime;
		if (changeCounter <= 0) {
			aiMode = Random.Range (0, 4);
			changeCounter = changeTime;
		}
		if (Mathf.Abs (Vector3.Distance(transform.position, player.position)) < 100f) {
			transform.LookAt (player);
			transform.rotation = Quaternion.Euler (xOff, transform.rotation.eulerAngles.y, zOff);

			float yStore = moveDirection.y;
			switch (aiMode) {
			case 0: 
				moveDirection = transform.forward;
				break;
			case 1: 
				moveDirection = -transform.forward;
				break;
			case 2: 
				moveDirection = transform.right;
				break;
			case 3: 
				moveDirection = -transform.right;
				break;
			default:
				moveDirection = transform.forward;
				break;
			}
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
