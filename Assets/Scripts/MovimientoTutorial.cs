using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTutorial : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;

    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizador;

    private Vector3 velocidad = Vector3.zero;
    private bool mirada = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Caminar", movimientoHorizontal != 0f);

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;

    }

    private void FixedUpdate()
    {
     Mover(movimientoHorizontal * Time.fixedDeltaTime);   
    }

    private void Mover( float mover)
    {
        Vector3 velocidad = new Vector2(mover,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,velocidad, ref velocidad, suavizador);

        if((mover > 0 && !mirada) || (mover < 0 && mirada))
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirada = !mirada;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
