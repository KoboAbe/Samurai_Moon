using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float speed = 5f;
    public float jump;

    public bool isGrounded=true;


    private Rigidbody2D rb;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        MovePlayer(horizontalInput);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isGrounded = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
          
        }
    }



    private void MovePlayer(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }
}
