using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluefire : MonoBehaviour
{
    public float speed = 5f;            // Velocidad de movimiento del enemigo
    public float minY = -5f;            // Límite inferior de movimiento
    public float maxY = 2f;             // Límite superior de movimiento
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

        // Si alcanza el límite superior, cambiar la dirección hacia abajo
        if (transform.position.y >= maxY)
        {
            direction = -1;
        }
        // Si alcanza el límite inferior, cambiar la dirección hacia arriba
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
