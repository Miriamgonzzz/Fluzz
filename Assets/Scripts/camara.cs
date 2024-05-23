using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class camara : MonoBehaviour
{

    public GameObject Player; // El objeto del jugador
    public float yOffsetPercentage = 0.1f; // Porcentaje de la altura de la cámara donde se ubicará el jugador

    void Update()
    {
        if (Player != null)
        {
            // Calcula la altura ortográfica de la cámara
            float cameraHeight = Camera.main.orthographicSize * 18.0f;

            // Calcula el desplazamiento vertical en base al porcentaje especificado
            float yOffset = cameraHeight * yOffsetPercentage;

            // Establece la nueva posición de la cámara
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - Camera.main.orthographicSize + yOffset, transform.position.z);
        }
    }
}




