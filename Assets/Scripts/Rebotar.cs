using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebotar : MonoBehaviour
{

    private Rigidbody2D rbPadre;
    [SerializeField] private float velocidadRebote;
    // Start is called before the first frame update
    void Start()
    {
        rbPadre = transform.parent.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rebotando()
    {
        Debug.Log("REBOTANDO");
        Debug.Log(rbPadre);
        rbPadre.velocity = new Vector2(rbPadre.velocity.x, velocidadRebote);
    }
}
