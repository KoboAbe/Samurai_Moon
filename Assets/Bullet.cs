using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SamuraiController samurai;
    private Rigidbody2D rb;
    public float force;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        samurai= GameObject.FindFirstObjectByType<SamuraiController>();

        Vector3 direction = samurai.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("PJ") )
         {
            collision.gameObject.GetComponent<LifeController>().TakeDamage(10);
            Destroy(gameObject);
        }
    }

    
}
