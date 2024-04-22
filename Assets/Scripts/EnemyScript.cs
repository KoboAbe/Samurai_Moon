using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f;
    public Transform PlayerGround; // Punto desde donde se lanza el raycast para detectar el suelo del jugador

    private bool movingRight = true;

    private void Update()
    {
        // Mover al enemigo en la dirección actual
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Lanzar un raycast hacia abajo desde el punto de detección del suelo del jugador
        RaycastHit2D groundInfo = Physics2D.Raycast(PlayerGround.position, Vector2.down, 1f);

        // Si no se detecta el suelo del jugador, cambiar de dirección
        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Cambiar la dirección del enemigo
        movingRight = !movingRight;

        // Girar el sprite en el eje X
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}

