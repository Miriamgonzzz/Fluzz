using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FluzzMinotauro : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;

    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizador;
    [SerializeField] private float fuerzaSalto; // Variable para ajustar la fuerza del salto desde el Inspector
    [SerializeField] private float velocidadYDuranteSalto;

    private bool mirada = true;
    private bool enElAire = false;
    private BoxCollider2D colliderPegar;
    public float vida;
    public barraVida barraVida;
    public Transform puntoDeInicio;
    public float tiempoDeRespawn = 5.0f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        vida = 10;
        barraVida.InicializarBarraVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Caminar", movimientoHorizontal != 0f);

        if (Input.GetKeyDown(KeyCode.UpArrow) && !enElAire)
        {
            animator.SetBool("Saltar", true);
        }

        if (vida <= 1)
        {
            muerte();
        }

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
    }

    private void FixedUpdate()
    {
        Mover(movimientoHorizontal * Time.fixedDeltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidad = new Vector2(mover, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidad, ref velocidad, suavizador);

        if ((mover > 0 && !mirada) || (mover < 0 && mirada))
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirada = !mirada;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    // Función para restablecer la animación de salto
    public void ResetSaltoAnimation()
    {
        animator.SetBool("Saltar", false);
    }
    public void ResetAtaqueAnimation()
    {
        animator.SetBool("Ataque", false);
    }

    public void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        enElAire = true;
        animator.SetBool("Saltar", true);
        audioSource.Play();
    }

    public void ResetToqueAnimation()
    {
        Debug.Log("Toque");
        animator.SetBool("Toque", false);
    }

    public void ActivarCollider()
    {
        colliderPegar.enabled = true;
    }

    // Método para desactivar el BoxCollider
    public void DesactivarCollider()
    {
        colliderPegar.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElAire = false; // El personaje ya no está en el aire
            //animator.Play("CaerSuelo");
            animator.SetBool("Saltar", false);
            animator.SetBool("Toque", true);
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vida -= 1;
            barraVida.CambiarVidaActual(vida);
            Debug.Log("Vida Fluzz: " + vida);
        }
    }

    public void muerte()
    {
        // Desactivar el jugador y llamar al respawn
        gameObject.SetActive(false);
        GameController.instance.RespawnPlayer(this, puntoDeInicio, 10, tiempoDeRespawn);
    }
}
