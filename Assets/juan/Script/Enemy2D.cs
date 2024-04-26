using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speedWalk;
    public float speedRun;
    public GameObject target;
    public bool atacando;

    public float rangoVision;
    public float rangoAtaque;
    public GameObject rango;
    public GameObject hit;


    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player 1");
    }

    public void FinalAni()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderAttackTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderAttackFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update()
    {
        Comportamiento();
    }

 

    public void Comportamiento()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rangoVision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:
                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            // transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
                            transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
            
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rangoAtaque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("attack", false);
                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }
        }

    }
        
}
