using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaTinta : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidbody2D;
    public Vector3 direccion;

    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
            
            
     }

    // Update is called once per frame
    private void FixedUpdate()
    {

       

            rigidbody2D.velocity = Vector2.right * velocidad;
         


    }

    public void dameDireccion(Vector2 direccion) {

        this.direccion = direccion;
       
           
    }
}
