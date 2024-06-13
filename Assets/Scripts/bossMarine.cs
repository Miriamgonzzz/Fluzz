using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMarine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform upBoundary; // Punto de referencia superior
    public Transform downBoundary; // Punto de referencia inferior
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public Transform respawnPoint;
    public float respawnTime = 3f;
    public GameObject enemyPrefab;
    private bool movingUp = true; // Indica si el enemigo se está moviendo hacia arriba
    Animator animator;
    private BoxCollider2D colliderPegar;
    [SerializeField] public int vida = 60;
    private BoxCollider2D colliderEnemigo;
    public AudioSource audioSource;
    public GameObject puertaMundoCentral;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        colliderEnemigo = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= upBoundary.position.y)
            {
                // Si alcanza el límite superior, cambia de dirección
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= downBoundary.position.y)
            {
                // Si alcanza el límite inferior, cambia de dirección
                movingUp = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Le he dado al submarino");
        if (collision.tag == "Bola")
        {
            Debug.Log("chupate esa");

            vida -= 10;
            animator.SetBool("danioBossMarine", true);

            if (vida <= 0)
            {

                colliderEnemigo.enabled = false;
                Destroy(gameObject);
                puertaMundoCentral.SetActive(true);
            }
        }


    }

    private void deshacerDanio()
    {
        animator.SetBool("danioBossMarine", false);
    }
}
