using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public GameController gameController;
	public int score = 0;
	public bool scoreCount;

	void Update(){

		if (score == 11) {
			gameController.GameEnd ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){

			Destroy (other.gameObject);
			score++;
			scoreCount = true;
	}
}
