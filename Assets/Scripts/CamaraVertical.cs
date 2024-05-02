using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraVertical : MonoBehaviour
{
     public Transform objetivo; // El personaje que seguirá la cámara
    public float suavidad = 0.3f; // Controla la suavidad del seguimiento

    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        if (objetivo)
        {
            // Calcula la posición deseada de la cámara
            Vector3 objetivoPosicion = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);

            // Interpolación suave hacia la posición deseada
            transform.position = Vector3.SmoothDamp(transform.position, objetivoPosicion, ref velocidad, suavidad);
        }
    }

}
