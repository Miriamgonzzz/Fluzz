using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoStiap : MonoBehaviour
{

[SerializeField] public int vida = 100;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
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

      }
        StopAllCoroutines();
        StartCoroutine(Dano());

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
