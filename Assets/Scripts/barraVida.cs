using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVida : MonoBehaviour
{

    private Slider slider;
   



    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

    }

      public void CambiarVidaActual(float cantidadVida){
        slider.value = cantidadVida;


    }


    public void InicializarBarraVida(float cantidadVida){
        slider.maxValue = cantidadVida;
        CambiarVidaActual(cantidadVida);
    }

}
