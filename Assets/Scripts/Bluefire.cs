using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluefire : MonoBehaviour
{
    public float speed = 5f;            // Velocidad de movimiento del enemigo
    public float verticalSpeed = 3f;     // Velocidad de movimiento vertical
    public float upwardSpeed = 2f;      // Velocidad de movimiento hacia arriba al inicio
    public float minY = -5f;            // Límite inferior de movimiento
    public float maxY = 2f;             // Límite superior de movimiento
    private int direction = 1;
    private bool isOnGround = false;     // Indicador de si el enemigo está en el suelo
    private bool isMovingUp = true;     // Indicador de si el enemigo está en el estado inicial de moverse hacia arriba

    [SerializeField] public int vida = 10;
    private BoxCollider2D colliderEnemigo;
    public Animator animator;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Inicialmente, el enemigo se mueve hacia arriba
        transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        colliderEnemigo = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingUp)
        {
            // Mover el enemigo hacia la izquierda
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // Continuar moviendo el enemigo hacia arriba hasta que toque el suelo
            transform.Translate(Vector3.up * upwardSpeed * Time.deltaTime);
        }
        else if (isOnGround)
        {
            // Mover el enemigo hacia la izquierda
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Mover el enemigo en la dirección vertical actual (zigzag)
            transform.Translate(Vector3.down * verticalSpeed * direction * Time.deltaTime);

            // Si alcanza el límite superior, cambiar la dirección hacia abajo
            if (transform.position.y >= maxY)
            {
                direction = -1;
            }
            // Si alcanza el límite inferior, cambiar la dirección hacia arriba
            else if (transform.position.y <= minY)
            {
                direction = 1;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Detector"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Techo"))
        {
            isOnGround = true;   // Comenzar el movimiento en zigzag
            isMovingUp = false;  // Terminar el movimiento hacia arriba
        }
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isOnGround = false;   // Comenzar el movimiento en zigzag
            isMovingUp = true;  // Terminar el movimiento hacia arriba
        }


        if (collision.gameObject.CompareTag("Player"))
        {

            vida -= 10;

            if (vida <= 0)
            {
                audioSource.Play();
                colliderEnemigo.enabled = false;
                animator.SetBool("muerte", true);

            }
            StopAllCoroutines();
            StartCoroutine(Dano());

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bola")
        {
            audioSource.Play();
            vida -= 10;
            transform.localScale = new Vector3(-10, 1, 1);
            if (vida <= 0)
            {

                colliderEnemigo.enabled = false;
                animator.SetBool("muerte", true);

            }
            StopAllCoroutines();
            StartCoroutine(Dano());
        }


    }

    private void destruirEnemigo()
    {
        Destroy(gameObject);
    }


    IEnumerator Dano()
    {

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorDano;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;
    }

}
