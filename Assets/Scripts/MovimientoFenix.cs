using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoFenix : MonoBehaviour
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
    private bool quieto = false;
    public float vida;
    public int danio;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;

    public barraVida barraVida;

    private float cameraHalfWidth;
    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vida = 100;
        barraVida.InicializarBarraVida(vida);

        mainCamera = Camera.main;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;




    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada horizontal del jugador
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcular el movimiento horizontal
        Vector2 movement = new Vector2(horizontalInput * velocidad, rigidbody.velocity.y);

        // Aplicar el movimiento al Rigidbody2D
        rigidbody.velocity = movement;

        // Limitar el movimiento del jugador al borde izquierdo de la cámara
        Vector3 playerPosition = transform.position;
        Vector3 cameraPosition = mainCamera.transform.position;

        float leftLimit = cameraPosition.x - cameraHalfWidth;

        if (playerPosition.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, playerPosition.y, playerPosition.z);
        }




        Vector3 velocidadHorizontal = Vector3.zero;
        Vector3 velocidadVertical = Vector3.zero;
        movimiento = Input.GetAxis("Horizontal");

        if (vida <= 1)
        {
            Destroy(gameObject);
            muerte();
        }
        //  animator.SetInteger("Horizontal", 1);

        if (Input.GetKey(KeyCode.RightArrow))
        {


            //Debug.Log("Derecha");
            velocidadHorizontal = new Vector3(velocidad, 0, 0) * Time.deltaTime;
            girar(movimiento);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            //Debug.Log("Izquieda");
            velocidadHorizontal = new Vector3(-velocidad, 0, 0) * Time.deltaTime;
            girar(movimiento);



        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            //Debug.Log("Arriba");
            velocidadVertical = new Vector3(0, velocidad, 0) * Time.deltaTime;


        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            //Debug.Log("Abajo");
            velocidadVertical = new Vector3(0, -velocidad, 0) * Time.deltaTime;


        }
        transform.position += velocidadHorizontal;
        transform.position += velocidadVertical;

        if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.50f)
        {
            ultimoDisparo = Time.time;
            disparo();

        }
        if (movimiento == 0)
            animator.SetInteger("Horizontal", 1);


    }

    private void disparo()
    {


        var bala = Instantiate(disparoTinta, PuntoDeDisparo.position, Quaternion.identity);
        bala.transform.SetParent(null);
        if (!orientacion)
        {
            bala.GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidadDisparo;
        }
        else
        {
            bala.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadDisparo;

        }


    }

    private void girar(float movimiento)
    {

        if ((orientacion && movimiento > 0) || (!orientacion && movimiento < 0))
        {
            orientacion = !orientacion;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
        animator.SetInteger("Horizontal", 2);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vida -= 20;
            barraVida.CambiarVidaActual(vida);



            Debug.Log("Vida Fluzz: " + vida);

            StopAllCoroutines();
            StartCoroutine(Dano());
        }


        if (collision.gameObject.CompareTag("Premio"))
        {
            vida += 100;
            if (vida > 100)
            {
                vida = 100;
            }
            barraVida.CambiarVidaActual(vida);



            Debug.Log("Vida Fluzz: " + vida);

        }

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


    public void muerte()
    {
        SceneManager.LoadScene("FinalMundoAcuatico"); // Carga la escena con el nombre especificado
    }

}
