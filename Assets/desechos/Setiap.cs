using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setiap : MonoBehaviour
{

    public Animator animator;
    private float velocidadX = 2;
    private float velocidadY = -1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
         velocidadX * Time.deltaTime,
         velocidadY * Time.deltaTime,
         0);

        if ((transform.position.x < -25) || (transform.position.x > 25))
            velocidadX = -velocidadX;
        if ((transform.position.y < -2.5)|| (transform.position.y > 2.5))
            velocidadY = -velocidadY;
    }

    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
             Debug.Log("Tocado");
            animator.SetInteger("danio", 1);
            


        }
    }
    
    IEnumerator Espera(int segundos) {

        yield return new WaitForSeconds(segundos);
    
    }


}
