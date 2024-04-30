using UnityEngine;

public class SamuraiController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Barravida barravida;

    private float movementInputDirection;
    private float movementSpeed = 10.0f;
    public float jumpForce = 16.0f;
    private bool isFacingRight = true;
    private bool isRunning;
    private bool isGrounded;
    private bool isAlive = true;

    private float tiempoUltimaRecarga;

    // Vida y energía
    public float vidaMaxima = 100f;
    public float energiaMaxima = 100f;
    public float vidaActual;
    public float energiaActual = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        barravida = FindObjectOfType<Barravida>();
        barravida.InicializarBarraDeVida(vidaMaxima);
        barravida.InicializarBarraDeEnergia(energiaMaxima);
    }

    void Update()
    {
        if (isAlive)
        {
            CheckInput();
            CheckMovementDirection();
            UpdateAnimations();
            IncrementarEnergiaEnIntervalos();
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
            TakeDamage(10f);
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
            barravida.RecargarEnergia(10f);
        }
    }

    private void Attack()
    {
        if (isAlive)
        {
            anim.SetTrigger("isAttacking");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isAlive)
        {
            anim.SetTrigger("Damage");
            Debug.Log("Player took damage!");
            vidaActual -= damageAmount;
            barravida.CambiarVidaActual(vidaActual);
            barravida.TakeDamage(damageAmount);
        }
    }

    private void IncrementarEnergiaEnIntervalos()
    {
        // Verificar si ha pasado suficiente tiempo desde la última recarga
        if (Time.time - tiempoUltimaRecarga >= 10f)
        {
            IncrementarEnergia(10f); // Incrementar la energía en intervalos de 10
            tiempoUltimaRecarga = Time.time; // Actualizar el tiempo de la última recarga
        }
    }

    private void IncrementarEnergia(float cantidad)
    {
        // Si la energía actual más la cantidad no excede el máximo, incrementarla
        if (energiaActual + cantidad < energiaMaxima)
        {
            energiaActual += cantidad;
        }
        else
        {
            energiaActual = energiaMaxima;
        }

        barravida.CambiarEnergiaActual(energiaActual);
    }

    public void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            anim.SetTrigger("isDead");
            Debug.Log("Player has died.");
            // Aquí puedes agregar más lógica si es necesario al morir el jugador
        }
    }
}
