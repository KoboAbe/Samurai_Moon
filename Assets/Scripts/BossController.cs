using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    public bool mirandoDerecha = true;
    private int toques = 0; // Contador de toques recibidos

    [Header("Vida")]
    [SerializeField] private float vida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    [Header("Persecución")]
    [SerializeField] private float velocidadPersecucion = 5f; // Velocidad de persecución del jefe

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        // Buscar el jugador solo una vez al inicio
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        // Mira al jugador solo si hay un jugador y el script no está desactivado
        if (jugador != null && enabled)
        {
            MirarJugador();

            // Perseguir al jugador
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb2D.MovePosition(rb2D.position + direccion * velocidadPersecucion * Time.deltaTime);
        }
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<PlayerFight>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Incrementa el contador de toques
            toques++;

            // Si el contador alcanza 3, destruye el enemigo
            if (toques >= 3)
            {
                Morir();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
