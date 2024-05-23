using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MecanicaDraken : MonoBehaviour
{

    private bool deteccionFluz = false;
    public GameObject disparoPerla;
    public Transform PuntoDeDisparo;
    private float ultimoDisparo;
    public float velocidadDisparo = 50;
    public string orientacion;
        private bool hasFired = false; // Variable de control para asegurarnos que solo dispare una vez
     public GameObject objetivo; // El objetivo al que se disparará
    void Start()
    {
        InvokeRepeating("disparar", 3.0f, 3.0f); 
    }

    private void disparar(){
          if (deteccionFluz  && !hasFired)
        {
            Debug.Log("veo a Fluzz");
            disparo();
            hasFired = true; // Marca que ya se ha disparado
        }else{
               hasFired = false; 
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (deteccionFluz  && !hasFired)
        {
            Debug.Log("veo a Fluzz");
            disparo();
            hasFired = true; // Marca que ya se ha disparado
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            deteccionFluz = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto es "Fluzz"
        if (other.CompareTag("Player"))
        {
            deteccionFluz = false;
        }
    }


    private void disparo()
    {


         var perla = Instantiate(disparoPerla, PuntoDeDisparo.position, Quaternion.identity);
        perla.transform.SetParent(null);

       
        // Calcula la dirección desde el punto de disparo hasta el objetivo
        Vector2 direccion = (objetivo.transform.position - PuntoDeDisparo.position).normalized;

        // Aplica la dirección a la velocidad del proyectil
        perla.GetComponent<Rigidbody2D>().velocity = direccion * velocidadDisparo;


    }
}
