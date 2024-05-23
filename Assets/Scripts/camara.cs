using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class camara : MonoBehaviour
{

    public GameObject Player; // El objeto del jugador
    public float yOffsetPercentage = 0.1f; // Porcentaje de la altura de la c�mara donde se ubicar� el jugador

    void Update()
    {
        if (Player != null)
        {
            // Calcula la altura ortogr�fica de la c�mara
            float cameraHeight = Camera.main.orthographicSize * 18.0f;

            // Calcula el desplazamiento vertical en base al porcentaje especificado
            float yOffset = cameraHeight * yOffsetPercentage;

            // Establece la nueva posici�n de la c�mara
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - Camera.main.orthographicSize + yOffset, transform.position.z);
        }
    }
}




