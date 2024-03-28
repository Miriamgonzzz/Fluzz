using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public float velocidad = 2;
    public Rigidbody2D rigidbody;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocidadHorizontal = Vector3.zero;
        Vector3 velocidadVertical = Vector3.zero;


        if (Input.GetKey(KeyCode.RightArrow))
        {

            Debug.Log("Derecha");
            velocidadHorizontal = new Vector3(velocidad, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            Debug.Log("Izquieda");
            velocidadHorizontal = new Vector3(-velocidad, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            Debug.Log("Arriba");
            velocidadVertical = new Vector3(0, velocidad, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            Debug.Log("Abajo");
            velocidadVertical = new Vector3(0, -velocidad, 0) * Time.deltaTime;
        }
        transform.position += velocidadHorizontal;
        transform.position += velocidadVertical;

    }
}
