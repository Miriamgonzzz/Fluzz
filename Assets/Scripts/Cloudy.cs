using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudy : MonoBehaviour
{
    private BoxCollider2D childCollider;
    // Start is called before the first frame update
    void Start()
    {
        childCollider = GetComponentInChildren<BoxCollider2D>();
        childCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarColaider()
    {
        childCollider.enabled = true;

    }

    public void desactivarColaider()
    {
        childCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Fluzz"))
        {
            Debug.Log("Jugador detectado");
        }
    }
}
