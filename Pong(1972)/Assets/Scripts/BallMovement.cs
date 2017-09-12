using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float speed = 5;
	public Vector2 dir = new Vector2 (1, -1);
	public bool demo;

	//Una lista con dos números(positivo y negativo), para establecer la dirección en 'X' o 'Y'
	private int[] _random = {-1,1};
	private AudioSource _audio;

	void Start(){

		_audio = GetComponent<AudioSource> ();
		/*Si la bola es sólo para demostración(pantalla de espera), creamos direcciones aleatorias(-1,1) para las coordenadas 'X' y 'Y' */
		if (demo) {
			//usamos índices aleatorios(0,1) para la lista _random y usarlos en la nueva dirección
			int x = Random.Range (0, 2);
			int y = Random.Range (0, 2);
			dir = new Vector2 (_random [x], _random [y]);
		}
		GetComponent<Rigidbody2D> ().velocity = dir * speed;
		Debug.Log (dir);
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Si la bola(que no es demo) colisiona con algo, se reproduce el sonido "BallHitSound"
		if (!demo) {
			_audio.Play ();
		}
	}
}
