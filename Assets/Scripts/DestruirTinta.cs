using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTinta : MonoBehaviour
{
public float distanciaMaxima = 10f; // Distancia máxima que puede recorrer el disparo

private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Limite" || collision.tag == "Enemigo" ) {
        // Destruye el objeto de disparo cuando colisiona con cualquier otro objeto
        Destroy(gameObject);
    }
    }
    private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
 
}
