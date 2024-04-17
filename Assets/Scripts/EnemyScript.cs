using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public float leftLimit = -5f; // Límite izquierdo de la plataforma
    public float rightLimit = 5f; // Límite derecho de la plataforma

    void Update()
    {
        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = player.position - transform.position;
            direction.Normalize(); // Normalizar la dirección para mantener una velocidad constante

            // Calcular la posición siguiente del enemigo
            Vector3 nextPosition = transform.position + direction * moveSpeed * Time.deltaTime;

            // Limitar la posición del enemigo dentro de los límites de la plataforma
            float clampedX = Mathf.Clamp(nextPosition.x, leftLimit, rightLimit);
            nextPosition.x = clampedX;

            // Mover el enemigo a la posición calculada
            transform.position = nextPosition;

            // Rotar el enemigo para que siempre mire hacia el jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
