using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de la cámara
    public Transform puntoDeParada; // El punto donde queremos que la cámara se detenga
    public float velocidadCamara = 2f; // La velocidad de la cámara

    private bool detenerCamara = false; // Indica si la cámara debe detenerse

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        // Si no se ha detenido la cámara y el punto de parada está asignado
        if (!detenerCamara && puntoDeParada != null)
        {
            // Movemos la cámara hacia el punto de parada a una velocidad constante
            transform.position = Vector3.MoveTowards(transform.position, puntoDeParada.position, velocidadCamara * Time.deltaTime);

            // Si la cámara llega al punto de parada, detenemos su movimiento
            if (transform.position == puntoDeParada.position)
            {
                detenerCamara = true;
                Debug.Log("La cámara ha llegado al punto de parada y se ha detenido.");
            }
        }
    }
}
