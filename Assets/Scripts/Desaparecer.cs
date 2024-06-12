using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    public GameObject fluzz;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        { 
            fluzz.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            fluzz.SetActive(true);
        }
        
        

    }
}
