// Enemy2D.cs
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    // Referencia al jugador
    public SamuraiController player;

    // Logica del daño al jugador
    public BoxCollider2D boxAttack;

    private void Start()
    {
        boxAttack.enabled = false;
        // Encuentra automáticamente al jugador en la escena si no se asigna manualmente
        if (player == null)
        {
            player = FindObjectOfType<SamuraiController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador toma daño
            float damageAmount = 10f; // Define la cantidad de daño que el enemigo causa
            collision.gameObject.GetComponent<SamuraiController>().TakeDamage(damageAmount);
            player.TakeDamage(damageAmount);
        }
    }

    public void EnabledBox(bool isActive)
    {
        boxAttack.enabled = isActive;
    }
}
