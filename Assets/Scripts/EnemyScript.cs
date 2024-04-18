using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public float leftLimit = -5f; // Límite izquierdo de la plataforma
    public float rightLimit = 5f; // Límite derecho de la plataforma

    private Animator animator; // Referencia al componente Animator
    private bool isIdle; // Estado de Idle del enemigo

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator al inicio
    }

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

            // Actualizar el estado Idle en el Animator
            UpdateIdleAnimation(direction);
        }
    }

    void UpdateIdleAnimation(Vector3 direction)
    {
        // Si la magnitud de la dirección es menor a un umbral (ejemplo: el enemigo está cerca del jugador)
        if (direction.magnitude < 0.1f)
        {
            // Activar el estado de Idle en el Animator
            isIdle = true;
        }
        else
        {
            // Desactivar el estado de Idle en el Animator
            isIdle = false;
        }

        // Actualizar el parámetro "Idle" en el Animator
        animator.SetBool("Idle", isIdle);
    }
}
