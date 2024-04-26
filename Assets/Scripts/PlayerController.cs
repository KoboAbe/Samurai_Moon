using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        ApplyGravity();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mover al jugador horizontalmente
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Actualizar el Animator
        UpdateAnimator(horizontalInput, verticalInput);

        // Voltear el sprite según la dirección horizontal
        FlipSprite(horizontalInput);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Aplicar el impulso de salto
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void ApplyGravity()
    {
        // Aplicar gravedad adicional durante la caída
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void UpdateAnimator(float horizontalInput, float verticalInput)
    {
        // Configurar parámetros en el Animator para controlar el Blend Tree
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);

        // Calcular la magnitud de la velocidad para determinar el parámetro "Speed"
        float speedMagnitude = new Vector2(horizontalInput, verticalInput).magnitude;
        animator.SetFloat("Speed", speedMagnitude);
    }

    private void FlipSprite(float horizontalInput)
    {
        // Voltear el sprite según la dirección horizontal del movimiento
        if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true; // Mirar hacia la izquierda
        }
        else if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false; // Mirar hacia la derecha
        }
    }

    private bool IsGrounded()
    {
        // Verificar si el jugador está en el suelo usando un Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }
}

