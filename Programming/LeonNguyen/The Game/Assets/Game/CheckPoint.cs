using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public HealthManager theHealthMan;

	public Renderer theRend;

	public Material cpOff;
	public Material cpOn;

	// Use this for initialization
	void Start () {
		theHealthMan = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckpointOn(){
		CheckPoint[] checkpoints = FindObjectsOfType<CheckPoint>();
		foreach (CheckPoint cp in checkpoints) {
			cp.CheckpointOff();
		}

		theRend.material = cpOn;
	}
	public void CheckpointOff(){
		theRend.material = cpOff;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "PlayerController") {
			theHealthMan.SetSpawnPoint (transform.position);
			CheckpointOn ();
		}
	}
}
