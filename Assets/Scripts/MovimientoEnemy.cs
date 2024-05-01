using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float flipCooldown = 1f;
    private bool movingRight = true; // Indica si el enemigo se est� moviendo hacia la derecha
    private float flipTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        flipTimer -= Time.deltaTime;

    }
    // M�todo para cambiar la direcci�n del enemigo
    private void FlipDirection()
    {
        // Verificar si el temporizador de volteo est� activo
        if (flipTimer <= 0f)
        {
            // Voltear la escala en el eje Y para cambiar la direcci�n
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

            // Reiniciar el temporizador de volteo
            flipTimer = flipCooldown;
        }
    }
}
