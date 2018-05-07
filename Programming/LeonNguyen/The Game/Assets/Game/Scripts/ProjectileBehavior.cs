using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

	public CharacterController controller;
	public float gravityScale;
	public int speed;

	public float lifeTime;
	private float lifeCounter;

	public Vector3 moveDirection;

	public int damageDeal = 1;

	// Use this for initialization
	void Start () {
		moveDirection = transform.forward * speed;
		moveDirection.y += 15;
		lifeCounter = lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);

		lifeCounter -= Time.deltaTime;
		if (lifeCounter <= 0) {
			Destroy (this.gameObject);
		}
	}

	private void OnTriggerEnter (Collider other) {
		if (other.transform.parent.name == "EnemyController") {
			Debug.Log ("enemy");
			Vector3 hitDirection = other.transform.position - transform.position;
			hitDirection = hitDirection.normalized;

			EnemyHealth enemy = other.gameObject.GetComponent("EnemyHealth") as EnemyHealth;

			enemy.HurtPlayer(damageDeal, hitDirection);
		}
	}
}
