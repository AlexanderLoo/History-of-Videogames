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
		//Inputs de rotación y movimiento hacia adelante previamente editados en Inputs
		//Teclas derecha e izquierda('A' y 'D')
		float rotation = Input.GetAxis("Rotation");
		//Tecla adelante('W')
		moveForward = Input.GetButton ("Forward");

		transform.Rotate (0, 0, rotation * rotationSpeed);
	}

	void FixedUpdate(){
		//Si se presiona la tecla de avanzar se agrega fuerza física hacia adelante
		if (moveForward) {
			_rigidbody.AddForce (transform.up * moveForce);
		}
	}

}
