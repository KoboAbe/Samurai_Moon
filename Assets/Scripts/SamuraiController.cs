using UnityEngine;

public class SamuraiController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float movementInputDirection;
    private float movementSpeed = 10.0f;
    public float jumpForce = 16.0f;
    private bool isFacingRight = true;
    private bool isRunning;
    private bool isGrounded;
    private bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAlive)
        {
            CheckInput();
            CheckMovementDirection();
            UpdateAnimations();
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            ApplyMovement();
        }
    }

    void CheckMovementDirection()
    {
        if ((isFacingRight && movementInputDirection < 0) || (!isFacingRight && movementInputDirection > 0))
        {
            Flip();
        }

        isRunning = Mathf.Abs(movementInputDirection) > 0.1f;
    }

    void UpdateAnimations()
    {
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        Debug.Log("Player jumped");
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player is grounded");
        }
        else if (collision.gameObject.CompareTag("Fire"))
        {
            CollectFire(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy: " + collision.gameObject.name);
            TakeDamage(); // Aplica daño al jugador al chocar con un enemigo
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire"))
        {
            CollectFire(other.gameObject);
        }
    }

    private void CollectFire(GameObject fireObject)
    {
        if (fireObject.CompareTag("Fire"))
        {
            Debug.Log("Fire Collected: " + fireObject.name);
            Destroy(fireObject);
            // Aquí puedes agregar más lógica si es necesario
        }
    }

    private void Attack()
    {
        if (isAlive)
        {
            anim.SetTrigger("isAttacking");
        }
    }

    public void TakeDamage()
    {
        if (isAlive)
        {
            anim.SetTrigger("Damage");
            Debug.Log("Player took damage!");
        }
    }

    public void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            anim.SetTrigger("Death");
            Debug.Log("Player has died.");
            // Aquí puedes agregar más lógica si es necesario al morir el jugador
        }
    }
}
