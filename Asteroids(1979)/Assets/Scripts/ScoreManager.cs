using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreDisplay;
	public Life playerLives;
	[System.NonSerialized]
	public int totalScore;
	private int addLife = 1000;

	void Start(){
		scoreDisplay = GetComponent<Text> ();
		scoreDisplay.text = "00";
	}

	void Update(){

		if(totalScore >= addLife){
			playerLives.life++;
			addLife += 1000;
		}
	}

	public void AddScore(int score){

		totalScore += score;
		scoreDisplay.text = totalScore.ToString ();
	}
}
