using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D _rigidbody;

	private bool moveForward;

	public float rotationSpeed, moveForce;

	void Start(){

		_rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		float rotation = Input.GetAxis("Rotation");
		moveForward = Input.GetButton ("Forward");

		transform.Rotate (0, 0, rotation * rotationSpeed);
	}

	void FixedUpdate(){

		if (moveForward) {
			_rigidbody.AddForce (transform.up * moveForce);
		}
	}

}
