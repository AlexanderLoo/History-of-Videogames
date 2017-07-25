﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){

		if (other.CompareTag ("Bullet")) {
			Destroy (other.gameObject);
		}
	}
}
