using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public float velocidad = 2;
    public Rigidbody2D rigidbody;
    public GameObject disparoTinta;
    public Transform PuntoDeDisparo;
    private float ultimoDisparo;
    private int Health = 5;
    private bool quieto = false;
   // public Animator animator;
    void Start()
    {
     //   animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocidadHorizontal = Vector3.zero;
        Vector3 velocidadVertical = Vector3.zero;

        
          //  animator.SetInteger("Horizontal", 1);

            if (Input.GetKey(KeyCode.RightArrow))
            {


                Debug.Log("Derecha");
                velocidadHorizontal = new Vector3(velocidad, 0, 0) * Time.deltaTime;
               // transform.localScale = new Vector3(0.4f, 0.4f, 1);


            //animator.SetInteger("Horizontal", 2);

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {

                Debug.Log("Izquieda");
                velocidadHorizontal = new Vector3(-velocidad, 0, 0) * Time.deltaTime;
               // transform.localScale = new Vector3(-0.4f, 0.4f, 1);
           //     animator.SetInteger("Horizontal", 2);


            }

            if (Input.GetKey(KeyCode.UpArrow))
            {

                Debug.Log("Arriba");
                velocidadVertical = new Vector3(0, velocidad, 0) * Time.deltaTime;
          //      animator.SetInteger("Horizontal", 2);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {

                Debug.Log("Abajo");
                velocidadVertical = new Vector3(0, -velocidad, 0) * Time.deltaTime;
            //    animator.SetInteger("Horizontal", 2);

            }
            transform.position += velocidadHorizontal;
            transform.position += velocidadVertical;

            if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.50f)
            {
                ultimoDisparo = Time.time;
                this.disparo();
            }
        }
       

    private void disparo() {


        var bala = Instantiate(disparoTinta, PuntoDeDisparo);
        bala.transform.SetParent(bala.transform, false);
        bala.GetComponent<Rigidbody2D>().velocity = bala.transform.right * velocidad;


    }

     
}
