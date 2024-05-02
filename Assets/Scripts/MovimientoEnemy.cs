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
    Animator animator;
    private GameObject objetoConTagPegar;
    private BoxCollider2D colliderPegar;

    // Start is called before the first frame update
    void Start()
    {
        
        FlipDirection();

        objetoConTagPegar = GameObject.FindGameObjectWithTag("Pegar");
        if (objetoConTagPegar != null)
        {
            colliderPegar = objetoConTagPegar.GetComponent<BoxCollider2D>();
            if (colliderPegar != null)
            {
                Debug.Log("Se encontro");
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

    // Método para cambiar la dirección del enemigo
    private void FlipDirection()
    {
        // Voltear la escala en el eje Y para cambiar la dirección
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AtaqueEnemigo") && other.gameObject.CompareTag("Pegar"))
        {
            Debug.Log("Choque");
            animator.SetBool("Muerte", true);
            // Realizar la acción de muerte del enemigo aquí
            //Destroy(gameObject); // Por ejemplo, puedes destruir el GameObject del enemigo
        }
    }
}
