using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoreDisplay;
	public Life playerLives;
	[System.NonSerialized]
	public int totalScore;
	//Cada # de puntos se agrega una vida más
	private int addLife = 1000;

	void Start(){
		scoreDisplay = GetComponent<Text> ();
		scoreDisplay.text = "00";
	}

	void Update(){
		//Si el score total sobrepasa un número, se agrega una vida más
		if(totalScore >= addLife){
			playerLives.life++;
			addLife += 1000;
		}
	}

	public void AddScore(int score){
		//función para agregar el score al score total,se llama desde el script "Enemy"
		totalScore += score;
		scoreDisplay.text = totalScore.ToString ();
	}
}
