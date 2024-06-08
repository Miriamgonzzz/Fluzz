using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluefire : MonoBehaviour
{
    public float speed = 5f;            // Velocidad de movimiento del enemigo
    public float minY = -5f;            // L�mite inferior de movimiento
    public float maxY = 2f;             // L�mite superior de movimiento
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el enemigo
        transform.Translate(Vector3.up * speed * direction * Time.deltaTime);

        // Si alcanza el l�mite superior, cambiar la direcci�n hacia abajo
        if (transform.position.y >= maxY)
        {
            direction = -1;
        }
        // Si alcanza el l�mite inferior, cambiar la direcci�n hacia arriba
        else if (transform.position.y <= minY)
        {
            direction = 1;
        }

}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Detector"))
        {
            Destroy(gameObject);
        }
    }
}
