using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alliron : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    private bool movingRight = true; // Indica si el enemigo se está moviendo hacia la derecha
    Animator animator;
    public GameObject disparoCorchea;
    public Transform PuntoDeDisparo;
    public float velocidadDisparo = 5.0f;  // Velocidad del proyectil

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        FlipDirection();
        InvokeRepeating("disparo", 2.0f, 2.0f); // Dispara cada 2 segundos
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
                FlipDirection();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= leftBoundary.position.x)
            {
                // Si alcanza el límite izquierdo, cambia de dirección
                movingRight = true;
                FlipDirection();
            }

        }
    }

    private void FlipDirection()
    {
        // Voltear la escala en el eje Y para cambiar la dirección
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void disparo()
    {

        Debug.Log("CAGO UNA CORCHEA");

        // Instancia el proyectil en el punto de disparo
        var corchea = Instantiate(disparoCorchea, PuntoDeDisparo.position, Quaternion.identity);
        corchea.transform.SetParent(null);

        // Dirección hacia abajo
        Vector2 direccion = Vector2.down;

        // Aplica la dirección a la velocidad del proyectil
        corchea.GetComponent<Rigidbody2D>().velocity = direccion * velocidadDisparo;


    }

}
