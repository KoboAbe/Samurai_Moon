using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGolem2 : MonoBehaviour
{
    [SerializeField] private float speed, limit;
    public float speedRun;
    [SerializeField] private bool moveRight;
    [SerializeField] private Transform groundController;
    [SerializeField] private RangoEnemy rangoVision;
    [SerializeField] private HitEnemy2D hit;

    public Enemy2D damage;

    public Animator ani;

    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!rangoVision.visto) 
        {

    
            rb.velocity = new Vector2(speed, rb.velocity.y);
            ani.SetBool("walk", true);
            ani.SetBool("run", false);
            ani.SetBool("attack", false);

        }else if (rangoVision.visto)
        {
            rb.velocity = new Vector2(speedRun, rb.velocity.y);
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            ani.SetBool("attack", false);

        }
        
       if (hit.hit)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
        }
        else
        {
            ani.SetBool("attack", false);
        }




        RaycastHit2D groundInfo = Physics2D.Raycast(groundController.position, Vector2.down, limit, LayerMask.NameToLayer("suelo"));
        Debug.Log(groundInfo.collider.name);
        if (groundInfo == false)
        {
            //Girar
            Girar();

        }



    }

    private void Girar()
    {
        moveRight = !moveRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
        speedRun*=-1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * limit);
    }

    public void StartAttack()
    {
        damage.EnabledBox(true);
    }

    public void EndedAttack()
    {
        damage.EnabledBox(false);
    }
}
