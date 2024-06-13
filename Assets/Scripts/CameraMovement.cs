using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de la c�mara
    public Transform puntoDeParada; // El punto donde queremos que la c�mara se detenga
    public float velocidadCamara = 2f; // La velocidad de la c�mara

    private bool detenerCamara = false; // Indica si la c�mara debe detenerse

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        // Si no se ha detenido la c�mara y el punto de parada est� asignado
        if (!detenerCamara && puntoDeParada != null)
        {
            // Movemos la c�mara hacia el punto de parada a una velocidad constante
            transform.position = Vector3.MoveTowards(transform.position, puntoDeParada.position, velocidadCamara * Time.deltaTime);

            // Si la c�mara llega al punto de parada, detenemos su movimiento
            if (transform.position == puntoDeParada.position)
            {
                detenerCamara = true;
                Debug.Log("La c�mara ha llegado al punto de parada y se ha detenido.");
            }
        }
    }
}
