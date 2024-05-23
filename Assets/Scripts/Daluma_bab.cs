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
    private bool movingRight = true; // Indica si el enemigo se está moviendo hacia la derecha
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBoundary.position.x)
            {
                // Si alcanza el límite derecho, cambia de dirección
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary.position.x)
            {
                // Si alcanza el límite izquierdo, cambia de dirección
                movingRight = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fluzz"))
        {
            other.transform.position = respawnPoint.position;
        }
    }
}
