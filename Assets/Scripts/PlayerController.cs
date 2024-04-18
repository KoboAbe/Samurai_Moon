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
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);
        bool attackInput = Input.GetKeyDown(KeyCode.E);

        MovePlayer(horizontalInput);
        UpdateAnimator(horizontalInput);

        if (horizontalInput != 0)
        {
            FlipSprite(horizontalInput);
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
        animator.SetBool("Running", horizontalInput != 0);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
        animator.SetBool("Jump", true);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
        }
    }

    private void FlipSprite(float horizontalInput)
    {
        spriteRenderer.flipX = horizontalInput < 0;
    }
}
