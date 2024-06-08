using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Medushield : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    private bool movingRight = true; // Indica si el enemigo se está moviendo hacia la derecha
    Animator animator;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " ha colisionado con " + other.name);
        Invoke("Desaparecer", 1.0f);
        other.gameObject.GetComponent<Rebotar>().Rebotando();
        
        
        
    }

    public void Desaparecer()
    {
        Debug.Log(gameObject.name + " desaparece");
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.2f);
    }
}
