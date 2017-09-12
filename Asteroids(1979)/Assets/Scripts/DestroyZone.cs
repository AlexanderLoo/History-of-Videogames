using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		//Para destruir los asteroides que salen de esta zona
		if (other.CompareTag ("Enemy")) {

			Destroy (other.gameObject);
		}
	}
}
