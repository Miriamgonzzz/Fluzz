using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePerla : MonoBehaviour
{
   public float distanciaMaxima = 10f; // Distancia máxima que puede recorrer el disparo

void OnCollisionEnter2D(Collision2D collision)
    {
        // Destruye el proyectil al colisionar con cualquier objeto
        Destroy(gameObject);
    }
/*
private void OnCollisionEnter2D(Collider2D collision){
  if (collision.tag == "Limite" || collision.tag == "Player" ) {
        // Destruye el objeto de disparo cuando colisiona con cualquier otro objeto
        Destroy(gameObject);
}
}

private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Limite" || collision.tag == "Enemigo" ) {
        // Destruye el objeto de disparo cuando colisiona con cualquier otro objeto
        Destroy(gameObject);
    }
    }

    */
    private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
 
}
