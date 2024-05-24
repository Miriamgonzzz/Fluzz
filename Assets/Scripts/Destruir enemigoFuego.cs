using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirenemigoFuego : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform; // El transform del personaje principal
    public float destroyDistance = 1f; // La distancia mínima para destruir el enemigo

    private void Update()
    {
        // Comprobar si el enemigo ha pasado al personaje principal
        if (transform.position.x < playerTransform.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
