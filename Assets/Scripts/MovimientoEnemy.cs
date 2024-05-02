using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    //public float flipCooldown = 1f;
    private bool movingRight = true; // Indica si el enemigo se está moviendo hacia la derecha

    // Start is called before the first frame update
    void Start()
    {
        // Obtener la referencia al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Desactivar la gravedad
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary.position.x)
            {
                // Si alcanza el límite derecho, cambia de dirección
                movingRight = true;
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= rightBoundary.position.x)
            {
                // Si alcanza el límite izquierdo, cambia de dirección
                movingRight = false;
            }
        }
    }

    // Método para cambiar la dirección del enemigo
    private void FlipDirection()
    {
        // Voltear la escala en el eje Y para cambiar la dirección
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
