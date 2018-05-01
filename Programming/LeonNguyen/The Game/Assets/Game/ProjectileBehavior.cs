using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

	public CharacterController controller;
	public float gravityScale'
	public int speed;

	public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		moveDirection = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);
	}
}
