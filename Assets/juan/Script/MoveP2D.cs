using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP2D : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speedWalk;
    public float speedRun;
    public LayerMask capaabajo;
    public LayerMask capaEnfrente;
    public float distanciaAbajo;
    public float distanciaEnfrente;
    public Transform controladorAbajo;
    public Transform controladorEnfrente;
    public bool informacioAbajo;
    public bool informacioEnfrente;
    private bool mirandoAlaDerecha = true;

    private void Update()
    {
        rb2D.velocity = new Vector2(speedWalk, rb2D.velocity.y);
        informacioEnfrente = Physics2D.Raycast(controladorEnfrente.position, transform.right, distanciaEnfrente, capaEnfrente);
        informacioAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaabajo);

        if (informacioEnfrente || !informacioAbajo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoAlaDerecha = !mirandoAlaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speedWalk *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up* -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnfrente.transform.position, controladorEnfrente.transform.position + transform.right * distanciaEnfrente);
    }
}


