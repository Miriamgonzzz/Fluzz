using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftBoundary; // Punto de referencia izquierdo
    public Transform rightBoundary; // Punto de referencia derecho
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public Transform respawnPoint;
    public float respawnTime = 3f;
    public GameObject enemyPrefab;
    private bool movingRight = true; // Indica si el enemigo se está moviendo hacia la derecha
    Animator animator;
    private GameObject objetoConTagPegar;
    private BoxCollider2D colliderPegar;

    // Start is called before the first frame update
    void Start()
    {
        
        FlipDirection();

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
        if (other.CompareTag("Pegar"))
        {
            StartCoroutine(RespawnEnemy());
            animator.SetBool("Muerte", true);
            // Realizar la acción de muerte del enemigo aquí
            // Por ejemplo, puedes destruir el GameObject del enemigo
        }
    }

    public void Desaparecer()
    {
        Destroy(gameObject);
    }

   IEnumerator RespawnEnemy()
    {
        // Esperar el tiempo de respawn
        yield return new WaitForSeconds(respawnTime);

        // Instanciar un nuevo enemigo en la posición de respawn
        Instantiate(enemyPrefab, respawnPoint.position, Quaternion.identity);
       
    }
}
