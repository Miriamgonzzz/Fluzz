using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidra : MonoBehaviour
{

    public Collider2D mainCollider; // Referencia al collider principal
    public Collider2D childCollider; // Referencia al collider del objeto hijo
    public Animator animator;
    [SerializeField] public int vida = 50;
    public AudioSource audioSource;

    void Start()
    {
        // Asegúrate de que los colliders estén deshabilitados al inicio si así lo deseas
        if (mainCollider != null)
            mainCollider.enabled = false;

        if (childCollider != null)
            childCollider.enabled = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Aparecer()
    {
        if (mainCollider != null)
            mainCollider.enabled = true;

        if (childCollider != null)
            childCollider.enabled = true;

        Debug.Log("Colliders habilitados");
    }

    public void Desaparecer()
    {
        if (mainCollider != null)
            mainCollider.enabled = false;

        if (childCollider != null)
            childCollider.enabled = false;

        Debug.Log("Colliders deshabilitados");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " ha colisionado con " + other.name);

        animator.SetBool("danio", true);
        audioSource.Play();
        vida -= 10;

        other.gameObject.GetComponent<Rebotar>().Rebotando();

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        Desaparecer();

    }

    private void deshacerDanio()
    {
        animator.SetBool("danio", false);
    }
}
