using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanicaFluzzAguaV2 : MonoBehaviour
{
    public float velocidad = 2;
    public float velocidadDisparo = 10;
    public Rigidbody2D rigidbody;
    public GameObject disparoTinta;
    public Transform PuntoDeDisparo;
    private float ultimoDisparo;
    private bool orientacion;
    private float movimiento;
    public Animator animator;
    private int Health = 5;
    private bool quieto = false;
    public int vida;
    public int danio;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vida = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocidadHorizontal = Vector3.zero;
        Vector3 velocidadVertical = Vector3.zero;
        movimiento = Input.GetAxis("Horizontal");



        //  animator.SetInteger("Horizontal", 1);

        if (Input.GetKey(KeyCode.RightArrow))
        {


            Debug.Log("Derecha");
            velocidadHorizontal = new Vector3(velocidad, 0, 0) * Time.deltaTime;
            girar(movimiento);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            Debug.Log("Izquieda");
            velocidadHorizontal = new Vector3(-velocidad, 0, 0) * Time.deltaTime;
            girar(movimiento);



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

        if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.50f)
        {
            ultimoDisparo = Time.time;
            disparo();
        
        }
        if(movimiento == 0)
            animator.SetInteger("Horizontal", 1);


    }

    private void disparo()
    {


        var bala = Instantiate(disparoTinta, PuntoDeDisparo.position,Quaternion.identity);
        bala.transform.SetParent(null);
        if (!orientacion)
        {
            bala.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadDisparo;
        }
        else {
            bala.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadDisparo;

        }


    }

    private void girar(float movimiento) { 
        
        if((orientacion && movimiento > 0) || (!orientacion && movimiento < 0)){
            orientacion = !orientacion;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
        animator.SetInteger("Horizontal", 2);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

       

            vida -= 1;

            if (vida <= 0)
            {

                Destroy(gameObject);

            }
            StopAllCoroutines();
            StartCoroutine(Dano());
        
    }

    IEnumerator Dano()
    {

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorDano;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorReposo;




    }


}