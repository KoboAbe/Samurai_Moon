using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;             // Velocidad de movimiento del enemigo
    public Vector2 moveAreaSize = new Vector2(5f, 3f); // Tamaño del área de movimiento (ancho, alto)
    public Vector2 moveAreaCenter = Vector2.zero;      // Centro del área de movimiento

    private bool movingRight = true;         // Dirección actual del movimiento
    private Animator animator;               // Referencia al componente Animator
    private Rigidbody2D rb;                  // Referencia al Rigidbody2D

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        rb = GetComponent<Rigidbody2D>();    // Obtener el componente Rigidbody2D
    }

    private void Update()
    {
        // Movimiento del enemigo dentro del área limitada
        MoveWithinArea();

        // Detectar suelo del jugador y cambiar dirección si es necesario
        DetectPlayerGround();
    }

    private void MoveWithinArea()
    {
        // Calcular los límites del área de movimiento
        float minX = moveAreaCenter.x - moveAreaSize.x / 2f;
        float maxX = moveAreaCenter.x + moveAreaSize.x / 2f;

        // Calcular la dirección de movimiento
        Vector2 movement = movingRight ? Vector2.right : Vector2.left;

        // Aplicar el movimiento al Rigidbody2D
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Limitar el movimiento dentro del área definida
        if ((movingRight && transform.position.x > maxX) || (!movingRight && transform.position.x < minX))
        {
            // Cambiar la dirección si alcanza los límites horizontales
            Flip();
        }

        // Actualizar la animación de movimiento
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); // Usamos Mathf.Abs para asegurarnos de que sea siempre positivo para la animación
    }

    private void DetectPlayerGround()
    {
        // Lanzar un raycast en la dirección actual de movimiento
        Vector2 raycastDirection = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, 0.5f);

        // Si se detecta el suelo del jugador, cambiar la dirección de movimiento
        if (hit.collider != null)
        {
            Flip();

            // Activar la animación de Flip (cambio de dirección)
            animator.SetTrigger("FlipTrigger");
        }
    }

    private void Flip()
    {
        // Cambiar la dirección del enemigo
        movingRight = !movingRight;

        // Girar el sprite en el eje X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar un rectángulo que representa el área de movimiento en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(moveAreaCenter, new Vector3(moveAreaSize.x, moveAreaSize.y, 0f));
    }
}
