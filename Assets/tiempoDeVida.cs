using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoDeVida : MonoBehaviour
{

    [SerializeField] private float tiempo;

    void Start()
    {

        Destroy(gameObject, tiempo);    
    }
}
