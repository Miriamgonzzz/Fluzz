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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (deteccionFluz)
        {
            Debug.Log("veo a Fluzz");
            disparo();
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

        if (orientacion == "derecha")
        {
            perla.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadDisparo;
        }
        else
        {
            perla.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadDisparo;

        }


    }
}
