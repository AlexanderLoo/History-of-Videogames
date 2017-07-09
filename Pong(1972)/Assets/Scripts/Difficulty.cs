using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

	public BallMovement ballScript;
	public float increaseSpeed;
	private float timeCount = 30;

	void Update(){

		if (timeCount > 0) {
			
			timeCount -= Time.deltaTime;
		} else {

			ballScript.speed += increaseSpeed;
			timeCount = 30;
		}
	}
}
