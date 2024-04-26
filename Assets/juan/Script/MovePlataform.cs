using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class MovePlataform : MonoBehaviour
{

    [SerializeField] private float speed, limit;
    public float speedRun;
    [SerializeField] private bool moveRight;
    [SerializeField] private Transform groundController;

    public Animator ani;

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundController.position, Vector2.down, limit);
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (groundInfo == false)
        {
            //Girar
            Girar();
        }

        ani.SetBool("walk", true);

    }

    private void Girar()
    {
        moveRight = !moveRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * limit);
    }


}
