using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	public float knockBackForce;
	public float knockBackTime;
	private float knockBackCounter;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (knockBackCounter <= 0) {
			float yStore = moveDirection.y;
			moveDirection.y = 0;
			moveDirection = (transform.forward * Input.GetAxisRaw ("Vertical")) + (transform.right * Input.GetAxisRaw ("Horizontal"));
			moveDirection = moveDirection.normalized * moveSpeed;
			moveDirection.y = yStore;

			if (controller.isGrounded) {
				moveDirection.y = 0f;
				if (Input.GetButtonDown ("Jump")) {
					moveDirection.y = jumpForce;
				}
			}
		} else {
			knockBackCounter -= Time.deltaTime;
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);
	}

	public void Knockback(Vector3 direction) {
		knockBackCounter = knockBackTime;

		moveDirection = direction * knockBackForce;
		moveDirection.y = knockBackForce;
	}
}
