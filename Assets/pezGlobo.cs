using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pezGlobo : MonoBehaviour
{
   [SerializeField] public int vida = 10;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;


    public Transform objetivo;
    public float velocidad;
    private float velocidadX = 2;
    private float velocidadY = -1.2f;
    public Animator animator;


    public bool perseguir;
    public float distanciaFluzz;
    private float distanciaFluzzAbsoluta;

    float distanciaCambio = 0.2f;
    byte siguientePosicion = 0;



    public void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();    
        animator = GetComponent<Animator>();
         animator.SetInteger("modo",1);   

    }


    public void Update()
    {
        distanciaFluzz = objetivo.position.x - transform.position.x;
        if(distanciaFluzz < 0){ 
            distanciaFluzzAbsoluta = distanciaFluzz * -1;
        }else{
              distanciaFluzzAbsoluta = distanciaFluzz;
        }


        if (perseguir) {

            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
           
        
        }

        if (distanciaFluzz >= 0)
        {

            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }
        else {
          
            transform.localScale = new Vector3(0.3f, 0.3f, 1);


        }

        if (distanciaFluzzAbsoluta < 10)
        {

            perseguir = true;
             animator.SetInteger("modo",2);   
        }
        else {

            perseguir = false;
             animator.SetInteger("modo",1);   
        }

        if (!perseguir) {


            transform.Translate(velocidadX * Time.deltaTime,velocidadY * Time.deltaTime, 0);

            if ((transform.position.x < -8) || (transform.position.x > 8))
                velocidadX = -velocidadX;
            if ((transform.position.y < -4) || (transform.position.y > 4))
                velocidadY = -velocidadY;

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bola") {

            vida -= 10;
            transform.localScale = new Vector3(-10, 1, 1);
            if (vida <= 0) {

                Destroy(gameObject);
                    
             }
            StopAllCoroutines();
            StartCoroutine(Dano());
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


      if (collision.gameObject.CompareTag("Player")){

           vida -= 10;
    
        if (vida <= 0)
        {

            Destroy(gameObject);

        }
         StopAllCoroutines();
        StartCoroutine(Dano());

      }
       

    }


        IEnumerator Dano() {

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorDano;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;
    }
}
