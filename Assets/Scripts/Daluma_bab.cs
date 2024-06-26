using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daluma_bab : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float respawnTime = 3f;
    public Transform respawnPoint;
    private bool movingRight = true; // Indica si el enemigo se est� moviendo hacia la derecha
    Animator animator;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        FlipDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBoundary.position.x)
            {
                // Si alcanza el l�mite derecho, cambia de direcci�n
                movingRight = false;
                FlipDirection();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary.position.x)
            {
                // Si alcanza el l�mite izquierdo, cambia de direcci�n
                movingRight = true;
                FlipDirection();
            }

        }
    }

    private void FlipDirection()
    {
        // Voltear la escala en el eje Y para cambiar la direcci�n
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fluzz"))
        {
            audioSource.Play();
            other.transform.position = respawnPoint.position;
        }
    }
}
