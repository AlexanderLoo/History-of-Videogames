using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour {

	public Image[] lives;

	private int life,previousLife, lifeIndex;

	void Start(){

		life = 5;
		previousLife = life;
		lifeIndex = life - 1;
	}

	void Update(){

		if (life < previousLife) {
			lives [lifeIndex].enabled = false;
			lifeIndex--;
			previousLife = life;
		}
	}

}
