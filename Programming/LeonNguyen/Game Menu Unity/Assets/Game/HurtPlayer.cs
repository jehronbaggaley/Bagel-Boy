using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageDeal = 1;

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.name == "PlayerController") {
			FindObjectOfType<HealthManager>().HurtPlayer(damageDeal);
		}
	}
}