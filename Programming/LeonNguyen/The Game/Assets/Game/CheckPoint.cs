using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public HealthManager theHealthMan;

	// Use this for initialization
	void Start () {
		theHealthMan = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Hit");
		if (other.gameObject.name == "PlayerController") {
			Debug.Log("Player");
			theHealthMan.SetSpawnPoint (transform.position);
		}
	}
}
