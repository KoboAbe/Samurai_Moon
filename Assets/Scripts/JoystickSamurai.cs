using UnityEngine;
using UnityEngine.UI;

public class JoystickSamurai : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private FixedJoystick fixedJoystick;
    private Rigidbody2D rigidbody;
    public Button attackButton;
    public Button jumpButton; // Nuevo botón para controlar el salto
    private Animator animator; // Referencia al componente Animator
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private bool isGrounded; // Variable para verificar si el jugador está en el suelo
    

    private void Start()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtener el componente Animator del mismo objeto
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer del mismo objeto
        attackButton.onClick.AddListener(Attack);
        jumpButton.onClick.AddListener(Jump); // Agregar un listener para el botón de salto
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector2 movement = new Vector2(xVal, yVal);
        rigidbody.velocity = new Vector2(movement.x * speed, rigidbody.velocity.y);

        // Configurar los parámetros de animación
        animator.SetFloat("yVelocity", rigidbody.velocity.y); // Establecer la velocidad vertical
        animator.SetBool("isRunning", movement.magnitude > 0); // Establecer si el jugador está corriendo

        // Voltear el sprite según la dirección horizontal
        FlipSprite(xVal);
    }

    private void Attack()
    {
        Debug.Log("Attacking!");
        animator.SetTrigger("isAttacking"); // Activar el trigger de la animación de ataque
    }

    private void Jump()
    {
        if (isGrounded) // Verificar si el jugador está en el suelo antes de saltar
        {
            Debug.Log("Jumping!");
            animator.SetTrigger("isJumping"); // Activar el trigger de la animación de salto
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            isGrounded = false;
        }
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

    // Método para detectar cuando el jugador entra en contacto con un objeto con el tag "Ground"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true; // Establecer la variable isGrounded a true cuando el jugador toca el suelo
            Debug.Log("Player is grounded");
        }
    }

    // Método para detectar cuando el jugador deja de estar en contacto con un objeto con el tag "Ground"
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            //CollectFire(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy: " + collision.gameObject.name);
            //TakeDamage(10f);
        }
    }
}
