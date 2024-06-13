using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoKitsune : MonoBehaviour
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
    //private bool iniciadoSalto = false; // Variable para controlar si el salto ha sido iniciado
    private bool animacionCaerSueloReproducida = false;
    private GameObject objetoConTagPegar;
    private BoxCollider2D colliderPegar;
    public AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        objetoConTagPegar = GameObject.FindGameObjectWithTag("Pegar");
        if (objetoConTagPegar != null)
        {
            colliderPegar = objetoConTagPegar.GetComponent<BoxCollider2D>();
            if (colliderPegar != null)
            {
                colliderPegar.enabled = false;
            }
            else
            {
                Debug.LogWarning("No se encontró un BoxCollider en el objeto con el tag 'Pegar'");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Pegar'");
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("Caminar", movimientoHorizontal != 0f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("Saltar", true);
            //rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto); // Detener cualquier velocidad vertical existente
            //enElAire = true;
            //iniciadoSalto = true;
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

    public void Saltar()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        audioSource.Play();
        enElAire = true;
        //iniciadoSalto = false;
        animacionCaerSueloReproducida = true;
    }

    public void ResetToqueAnimation()
    {
        Debug.Log("Toque");
        animator.SetBool("Toque", false);
        animacionCaerSueloReproducida = false;

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
        if (collision.gameObject.CompareTag("Suelo") && animacionCaerSueloReproducida)
        {

            enElAire = false; // El personaje ya no está en el aire
            //animator.Play("CaerSuelo");
            animator.SetBool("Saltar", false);
            animator.SetBool("Toque", true);
        }

    }
}
