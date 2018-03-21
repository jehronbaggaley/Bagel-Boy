using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	public bool useOffsetValues;

	public float rotateSpeed;

	public Transform pivot;

	public float maxViewAngle;
	public float minViewAngle;

	// Use this for initialization
	void Start () {
		if (!useOffsetValues) {
			offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.Rotate (0, horizontal, 0);

		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		pivot.Rotate (-vertical, 0, 0);

		if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
			pivot.rotation = Quaternion.Euler (maxViewAngle, 0, 0);
		}
		if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < minViewAngle) {
			pivot.rotation = Quaternion.Euler (minViewAngle, 0, 0);
		}

		float desiredYAngle = target.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;

		Quaternion rotation = Quaternion.Euler (desiredXAngle, desiredYAngle, 0);
		transform.position = target.position - (rotation * offset);

		if (transform.position.y < (target.position.y - 0.5f)) {
			transform.position = new Vector3 (transform.position.x, target.position.y - 0.5f, transform.position.z);
		}

		transform.LookAt (target);
	}
}
