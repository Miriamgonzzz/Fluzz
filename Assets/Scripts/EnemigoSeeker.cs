using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTipo2 : MonoBehaviour
{
 
    
  
    public Animator animator;
    public float velocidad = 5f; 
    public float distancia = 50f; 

    private Vector3 puntoInicial; // Punto inicial del movimiento
    private Vector3 puntoFinal; // Punto final del movimiento

    private bool yendoHaciaPuntoFinal = true;


    // Start is called before the first frame update
    void Start()
    {
                animator = GetComponent<Animator>();
                puntoInicial = transform.position;
                puntoFinal = puntoInicial + Vector3.left * distancia; 
           


    }

    // Update is called once per frame
    void Update()
    {


        if(yendoHaciaPuntoFinal){
            transform.localScale = new Vector3(0.3f, 0.3f, 1f); 

        }else{
             transform.localScale = new Vector3(-0.3f, 0.3f, 1f); 

        }

        // Calcula la dirección del movimiento
        Vector3 direccion = (yendoHaciaPuntoFinal) ? puntoFinal - transform.position : puntoInicial - transform.position;

        // Calcula la distancia que se debe mover en este frame
        float distanciaMovimiento = velocidad * Time.deltaTime;

        // Si la distancia a mover es mayor que la distancia al punto final, ajusta la distanciaMovimiento
        if (distanciaMovimiento > direccion.magnitude)
        {
            distanciaMovimiento = direccion.magnitude;
            yendoHaciaPuntoFinal = !yendoHaciaPuntoFinal; 
            
        }else{

        }

        // Mueve el enemigo
        transform.Translate(direccion.normalized * distanciaMovimiento);

   
    }


    
   
    
}
