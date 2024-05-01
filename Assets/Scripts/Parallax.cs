using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Transform cameraTransform;
    private Vector3 cameraPosition;
    private float sprite, startPosition; 
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraPosition = cameraTransform.position;
        sprite = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - cameraPosition.x)*velocidad;
        float moveAmount = cameraTransform.position.x * (1 - velocidad);
        transform.Translate(new Vector3(deltaX, 0, 0));
        cameraPosition = cameraTransform.position;

        if(moveAmount > startPosition + sprite)
        {
            transform.Translate(new Vector3(sprite, 0, 0));
            startPosition += sprite;
        }
        else if(moveAmount < startPosition - sprite)
        {
            transform.Translate(new Vector3(-sprite, 0, 0));
            startPosition -= sprite;
        }
    }
}
