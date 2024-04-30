using UnityEngine;

public class PlayerJoystick : MonoBehaviour
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
        // Obtener la posición del joystick virtual en pantalla
        Vector2 joystickPosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Mover al jugador horizontalmente y verticalmente
        rb.velocity = new Vector2(joystickPosition.x * speed, rb.velocity.y);

        // Actualizar el Animator
        UpdateAnimator(joystickPosition.x, joystickPosition.y);

        // Voltear el sprite según la dirección horizontal
        FlipSprite(joystickPosition.x);
    }

    private void HandleJump()
    {
        // Saltar si el joystick está arriba y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
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
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
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
        float speedMagnitude = Mathf.Abs(horizontalInput);
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

    // Función para atacar
    public void Attack()
    {
        // Implementa la lógica de ataque aquí
        Debug.Log("Attacking!");
    }
}
