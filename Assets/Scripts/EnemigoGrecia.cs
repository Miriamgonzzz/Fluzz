using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGrecia : MonoBehaviour
{
    private Rigidbody2D rb;
    private EdgeCollider2D childCollider;
    private Animator animator;

    // Variables para el movimiento oscilante
    public float amplitude = 1.0f;  // Amplitud del movimiento (cuánto se mueve hacia arriba y hacia abajo)
    public float frequency = 1.0f;  // Frecuencia del movimiento (qué tan rápido se mueve hacia arriba y hacia abajo)
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        childCollider = GetComponentInChildren<EdgeCollider2D>();
        startPosition = transform.position;  // Guardar la posición inicial

        if (childCollider == null)
        {
            Debug.Log("No lo detecta en " + gameObject.name);
        }
        else
        {
            Debug.Log("He encontrado al hijo en " + gameObject.name);
        }

        if (rb == null)
        {
            Debug.Log("Rigidbody2D no encontrado en " + gameObject.name);
        }
    }

    void Update()
    {
        // Aquí manejamos el movimiento oscilante
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " ha colisionado con " + other.name);
        Invoke("Desaparecer", 1.0f);
        other.gameObject.GetComponent<Rebotar>().Rebotando();
    }

    public void Desaparecer()
    {
        Debug.Log(gameObject.name + " desaparece");
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }
}
