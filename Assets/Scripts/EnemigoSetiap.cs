using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSetiap : MonoBehaviour
{

    [SerializeField] public int vida = 10;
    public Transform objetivo;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    public float velocidad = 0.5f; // Velocidad de movimiento del enemigo
    public float distancia = 1.5f; // Distancia máxima que recorrerá el enemigo

    private Vector3 puntoInicial; // Punto inicial del movimiento
    private Vector3 puntoFinal; // Punto final del movimiento

    private bool yendoHaciaPuntoFinal = true;
    public GameObject[] prefabs; // Array que contiene los prefabs a instanciar
    public int cantidadMaximaInstancias = 5; // Cantidad máxima de instancias


    // Start is called before the first frame update
    void Start()
    {
                spriteRenderer = GetComponent<SpriteRenderer>();    
                animator = GetComponent<Animator>();
                puntoInicial = transform.position;
                puntoFinal = puntoInicial + Vector3.left * distancia; 
                InstanciarPrefabAleatorio();


    }

    // Update is called once per frame
    void Update()
    {


        if(yendoHaciaPuntoFinal){
            transform.localScale = new Vector3(-0.3f, 0.3f, 1f); 

        }else{
             transform.localScale = new Vector3(0.3f, 0.3f, 1f); 

        }

        // Calcula la dirección del movimiento
        Vector3 direccion = (yendoHaciaPuntoFinal) ? puntoFinal - transform.position : puntoInicial - transform.position;

        // Calcula la distancia que se debe mover en este frame
        float distanciaMovimiento = velocidad * Time.deltaTime;

        // Si la distancia a mover es mayor que la distancia al punto final, ajusta la distanciaMovimiento
        if (distanciaMovimiento > direccion.magnitude)
        {
            distanciaMovimiento = direccion.magnitude;
            yendoHaciaPuntoFinal = !yendoHaciaPuntoFinal; 
            
        }else{

        }

        // Mueve el enemigo
        transform.Translate(direccion.normalized * distanciaMovimiento);

   
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bola") {

            vida -= 10;
            animator.SetInteger("estado",2);
            //transform.localScale = new Vector3(-10, 1, 1);
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
        animator.SetInteger("estado",1);
        InstanciarPrefabAleatorio();

    }


    public void InstanciarPrefabAleatorio()
    {
        // Genera un número aleatorio de instancias entre 1 y la cantidad máxima
        int cantidadInstancias = Random.Range(1, cantidadMaximaInstancias + 1);

        // Para cada instancia a realizar
        for (int i = 0; i < cantidadInstancias; i++)
        {
            // Genera un índice aleatorio dentro del rango de los prefabs disponibles
            int indiceAleatorio = Random.Range(0, prefabs.Length);

            // Instancia el prefab aleatorio en la posición actual del objeto
            GameObject instancia = Instantiate(prefabs[indiceAleatorio], transform.position, Quaternion.identity);

           
        }
    }
}
