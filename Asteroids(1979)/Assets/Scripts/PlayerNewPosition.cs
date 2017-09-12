using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewPosition : MonoBehaviour {

	public Transform playerPosition;
	//Estos son los limites de la pantalla en 'X' y en 'Y' con un mínimo y un máximo(uso vector2 para almacenar los 2 valores)
	public Vector2 xLimits, yLimits;

	//La función de este script es que cada vez que el player se sale de la pantalla, aparece en la parate opuesta de esta(ver la versión original de Asteroids)
	void OnTriggerExit2D(Collider2D other){
		
		if (other.CompareTag ("Player")) {
			/*Si la posición del player en 'Y' sobrepasa los límites, seteamos la posición del player en 'Y' al signo opuesto; de esta forma si el player esta arriba
			termina abajo y visceversa*/
			if (playerPosition.position.y >= yLimits.y || playerPosition.position.y <= yLimits.x) {
				Vector3 newPositionY;
				newPositionY = playerPosition.position;
				//Uso 0.90 en vez de 1 para que no se esconda fuera de la pantalla
				newPositionY.y *= -0.90f;
				playerPosition.position = newPositionY;
			}
			//Lo mismo que el código anterior para el caso de la coordenada 'X'
			if (playerPosition.position.x >= xLimits.y || playerPosition.position.x <= xLimits.x) {
				Vector3 newPositionX;
				newPositionX = playerPosition.position;
				newPositionX.x *= -0.90f;
				playerPosition.position = newPositionX;
			}
		}
	}
}
