using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public Image[] lives;
	public int life = 3;
	private int currentLife;
	private int livesIndex = 2;

	void Start(){
		_rigidbody = GetComponent<Rigidbody2D> ();
		currentLife = life;
	}

	void Update(){
		//Si perdemos una vida, la imagen de la vida se desactiva y se cambia al siguiente índice de la vida 
		if (life < currentLife) {
			lives [livesIndex].enabled = false;
			currentLife = life;
			livesIndex--;
			//El player resetea su posición inicial y su velocidad es cero
			transform.position = Vector3.zero;
			_rigidbody.velocity = Vector3.zero;
		}
		//Si se adquiere una vida, se activa la imagen de la vida del siguiente índice
		if (life > currentLife) {
			++livesIndex;
			lives [livesIndex].enabled = true;
			currentLife = life;
		}
	}
}
