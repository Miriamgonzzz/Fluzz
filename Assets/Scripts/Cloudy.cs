using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudy : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    [SerializeField] public int vida = 10;
    private BoxCollider2D colliderEnemigo;
    public Animator animator;
    public Color colorReposo;
    public Color colorDano;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        colliderEnemigo = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
      
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Detector"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {

            vida -= 10;

            if (vida <= 0)
            {

                colliderEnemigo.enabled = false;
                animator.SetBool("muerte", true);

            }
            StopAllCoroutines();
            StartCoroutine(Dano());

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bola")
        {

            vida -= 10;
            transform.localScale = new Vector3(-10, 1, 1);
            if (vida <= 0)
            {

                colliderEnemigo.enabled = false;
                animator.SetBool("muerte", true);

            }
            StopAllCoroutines();
            StartCoroutine(Dano());
        }


    }

    private void destruirEnemigo()
    {
        Destroy(gameObject);
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
