using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakasa_obake : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform upBoundary; // Punto de referencia superior
    public Transform downBoundary; // Punto de referencia inferior
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public Transform respawnPoint;
    public float respawnTime = 3f;
    public GameObject enemyPrefab;
    private bool movingUp = true; // Indica si el enemigo se est� moviendo hacia arriba
    Animator animator;
    private BoxCollider2D colliderPegar;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            Debug.Log("Subiendo");
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= upBoundary.position.y)
            {
                // Si alcanza el l�mite superior, cambia de direcci�n
                movingUp = false;
                Debug.Log("Alcanzado el l�mite superior");
            }
        }
        else
        {
            Debug.Log("Bajando");
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= downBoundary.position.y)
            {
                // Si alcanza el l�mite inferior, cambia de direcci�n
                movingUp = true;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aqu� puedes implementar la l�gica de perder
            Debug.Log("Jugador ha perdido!");
            // Ejemplo: destruir el jugador o reiniciar la escena
            // Destroy(collision.gameObject);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
