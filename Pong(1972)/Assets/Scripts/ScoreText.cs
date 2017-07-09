using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	private Text scoreText;
	public ScoreManager score;

	void Start(){

		scoreText = GetComponent<Text> ();
	}

	void Update(){

		if (score.score == 10) {
			scoreText.text = "1 0";
		}
		else if (score.score == 11) {
			scoreText.text = "1 1";
		} else {
			scoreText.text = score.score.ToString ();
		}
	}
}
