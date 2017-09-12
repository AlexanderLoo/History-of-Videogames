using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

	public BallMovement ballScript;
	public float increaseSpeed;
	private float timeCount = 30;

	void Update(){

		//Reducimos timeCount en 1 por cada segundo que pasa hasta que llegue a cero
		if (timeCount > 0) {
			
			timeCount -= Time.deltaTime;
		} else {
			//Si timeCount llega a cero, aumentamos la velocidad de la bola y comenzamos otro nuevo conteo
			ballScript.speed += increaseSpeed;
			timeCount = 30;
		}
	}
}
