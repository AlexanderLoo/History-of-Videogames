﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	private Rigidbody2D _rigidbody;

	public string axis;
	public float speed;
	private float moveY;

	void Start(){

		_rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		moveY = Input.GetAxisRaw (axis);
	}

	void FixedUpdate(){

		_rigidbody.velocity = new Vector2 (0, moveY) * speed;
	}
}
