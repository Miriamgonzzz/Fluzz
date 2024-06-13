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
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;


    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vida = 100;
        barraVida.InicializarBarraVida(vida);

        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 velocidadHorizontal = Vector3.zero;
        Vector3 velocidadVertical = Vector3.zero;
        movimiento = Input.GetAxis("Horizontal");

        float vertExtent = mainCamera.orthographicSize;
        float horizExtent = vertExtent * Screen.width / Screen.height;

        Vector3 cameraPosition = mainCamera.transform.position;
        minX = cameraPosition.x - horizExtent;
        maxX = cameraPosition.x + horizExtent;
        minY = cameraPosition.y - vertExtent;
        maxY = cameraPosition.y + vertExtent;
        // Obtener la posición actual del jugador
        Vector3 playerPosition = transform.position;

        // Clampeo de la posición del jugador para mantenerlo dentro de los límites de la cámara
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y, minY, maxY);

        // Asignar la posición clampeada de nuevo al transform del jugador
        transform.position = playerPosition;

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
        }


    }


    public void muerte()
    {
        SceneManager.LoadScene("MundoVolcan"); // Carga la escena con el nombre especificado
    }

    void OnDrawGizmos()
    {
        // Dibujar los límites de la cámara para visualización
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
        Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
        Gizmos.DrawLine(new Vector3(maxX, maxY, 0), new Vector3(minX, maxY, 0));
        Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(minX, minY, 0));
    }

}
