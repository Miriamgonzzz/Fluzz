using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoOniBoss : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject objetoConTagMazaOni;
    private GameObject objetoConTagPiernaDerecha;
    private GameObject objetoConTagPiernaIzquierda;
    private BoxCollider2D colliderMaza;
    private BoxCollider2D colliderPiernaDerecha;
    private BoxCollider2D colliderPiernaIzquierda;
    public Transform respawnPoint;
    void Start()
    {
        objetoConTagMazaOni = GameObject.FindGameObjectWithTag("MazaOni");
        objetoConTagPiernaDerecha = GameObject.FindGameObjectWithTag("PiernaDerecha");
        objetoConTagPiernaIzquierda = GameObject.FindGameObjectWithTag("PiernaIzquierda");

        colliderMaza = objetoConTagMazaOni.GetComponent<BoxCollider2D>();
        colliderPiernaDerecha = objetoConTagPiernaDerecha.GetComponent<BoxCollider2D>();
        colliderPiernaIzquierda = objetoConTagPiernaIzquierda.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesactivarColliderMazaOni()
    {
        colliderMaza.enabled = false;
    }

    public void DesactivarColliderPiernaDerecha()
    {
        colliderPiernaDerecha.enabled = false;
        colliderMaza.enabled = false;
    }

    public void DesactivarColliderPiernaIzquierda()
    {
        colliderPiernaIzquierda.enabled = false;
    }

    public void ActivarColliderMazaOni()
    {
        colliderMaza.enabled = true;
    }

    public void ActivarColliderPiernaDerecha()
    {
        colliderPiernaDerecha.enabled = true;
        colliderMaza.enabled = true;
    }

    public void ActivarColliderPiernaIzquierda()
    {
        colliderPiernaIzquierda.enabled = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Fluzz"))
        {
            other.transform.position = respawnPoint.position;
        }

    }

}
