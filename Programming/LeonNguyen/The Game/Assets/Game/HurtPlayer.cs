using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageDeal = 1;

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "PlayerController") {
			Debug.Log ("hit");
			Vector3 hitDirection = other.transform.position - transform.position;
			hitDirection = hitDirection.normalized;

			FindObjectOfType<HealthManager>().HurtPlayer(damageDeal, hitDirection);
		}
	}
}