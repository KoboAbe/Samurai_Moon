using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public bool isGrounded;

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
        HandleAttack();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;

        UpdateAnimator(horizontalInput);
        FlipSprite(horizontalInput);

        // Controlar el salto usando el eje vertical
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0f && isGrounded) // Verificar si se presiona hacia arriba y el jugador está en el suelo
        {
            Jump();
        }

        // Actualizar el parámetro "Vertical" en el Animator con la velocidad vertical actual
        animator.SetFloat("Vertical", rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        //animator.SetBool("Jump", true);
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void UpdateAnimator(float horizontalInput)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalInput)); // Usar valor absoluto del input horizontal
        //animator.SetBool("Running", Mathf.Abs(horizontalInput) > 0f);
    }

    private void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true; // Mirar hacia la izquierda
        }
        else if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false; // Mirar hacia la derecha
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Collected fire!");
            Destroy(other.gameObject);
        }
    }
}
