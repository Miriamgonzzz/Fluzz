using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquePam : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject enemyPrefab;
    private EdgeCollider2D childCollider;
    private CircleCollider2D detectorCollider;
    private Animator animator;
    public float velocidadDisparo = 50;
    public string orientacion;
    private bool hasFired = false; // Variable de control para asegurarnos que solo dispare una vez
    public GameObject objetivo; // El objetivo al que se disparará
    private bool deteccionFluz = false;
    public GameObject disparoCorchea;
    public Transform PuntoDeDisparo;
    public AudioSource audiosource;

    void Start()
    {
        animator = GetComponent<Animator>();
        childCollider = GetComponentInChildren<EdgeCollider2D>();
        detectorCollider = GetComponentInChildren<CircleCollider2D>();

        InvokeRepeating("disparar", 3.0f, 3.0f);

        if (detectorCollider == null)
        {
            Debug.Log("No lo detecta");

        }
        else
        {
            Debug.Log("He encontrado al hijo");
        }

    }

    private void disparar()
    {
        if (deteccionFluz && !hasFired)
        {

            disparo();
            hasFired = true; // Marca que ya se ha disparado
        }
        else
        {
            hasFired = false;
        }
    }

    void Update()
    {

        if (deteccionFluz && !hasFired)
        {

            disparo();
            hasFired = true; // Marca que ya se ha disparado
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Fluzz"))
        {
            Debug.Log("Te veo, Fluzz!!");
            deteccionFluz = true;
        }
    }

    private void disparo()
    {


        var corchea = Instantiate(disparoCorchea, PuntoDeDisparo.position, Quaternion.identity);
        corchea.transform.SetParent(null);
        audiosource.Play();


        // Calcula la dirección desde el punto de disparo hasta el objetivo
        Vector2 direccion = (objetivo.transform.position - PuntoDeDisparo.position).normalized;

        // Aplica la dirección a la velocidad del proyectil
        corchea.GetComponent<Rigidbody2D>().velocity = direccion * velocidadDisparo;


        Destroy(corchea, 1f);


    }
}
