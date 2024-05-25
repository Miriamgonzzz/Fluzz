using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGrecia : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject enemyPrefab;
    private EdgeCollider2D childCollider;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        childCollider = GetComponentInChildren<EdgeCollider2D>();

        if(childCollider == null)
        {
            Debug.Log("No lo detecta");

        }
        else
        {
            Debug.Log("He encontrado al hijo");
        }
        
    }

    void Update()
    {
        // Aquí puedes manejar cualquier otra lógica del enemigo
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Te mato");
        Invoke("Desaparecer", 1.0f);
    }

    public void Desaparecer()
    {
        // Aquí puedes agregar una animación de muerte antes de destruir el objeto
        Destroy(gameObject);
    }
}
