using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el SpriteRenderer
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        bool attackInput = Input.GetKeyDown(KeyCode.E); // Tecla "E" para atacar

        MovePlayer(horizontalInput);
        UpdateAnimator(horizontalInput);

        if (horizontalInput != 0)
        {
            FlipSprite(horizontalInput); // Girar el sprite según la dirección del movimiento
        }

        if (jumpInput && isGrounded)
        {
            Jump();
        }

        if (attackInput)
        {
            Attack();
        }
    }

    private void MovePlayer(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void UpdateAnimator(float horizontalInput)
    {
        float movementSpeed = Mathf.Abs(horizontalInput);
        animator.SetFloat("Speed", movementSpeed);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;

        Debug.Log("Jump!");

        // Trigger jump animation or other logic
        animator.SetTrigger("Jump");
    }

    private void Attack()
    {
        // Aquí puedes implementar la lógica de ataque
        Debug.Log("Attack!");

        // Trigger attack animation or other logic
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        // Implementar la lógica para recibir daño
        Debug.Log("Player takes damage!");
    }

    private void FlipSprite(float horizontalInput)
    {
        // Girar el sprite del jugador según la dirección del movimiento
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // No voltear (mirando a la derecha)
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Voltear horizontalmente (mirando a la izquierda)
        }
    }
}
