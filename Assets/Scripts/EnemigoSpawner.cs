using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;      // Array de posiciones de spawn
    public float minSpawnInterval = 1f;  // Intervalo m�nimo de spawn en segundos
    public float maxSpawnInterval = 5f; // Intervalo m�ximo de spawn en segundos
    public GameObject[] Enemigos;
    public Transform player;
    public float activationAngle = 45f;
    public float spawnAreaHeight = 3f;     // Altura del �rea de spawn


    private void Start()
    {
        // Iniciar la generaci�n de enemigos
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generar un intervalo de spawn aleatorio
            float spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);

            // Esperar el intervalo de spawn
            yield return new WaitForSeconds(spawnInterval);

            // Seleccionar un punto de spawn aleatorio
            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

         
            // Seleccionar un enemigo aleatorio del array de prefabs
            int enemyIndex = UnityEngine.Random.Range(0, Enemigos.Length);
            GameObject enemyPrefab = Enemigos[enemyIndex];

            // Calcular una posici�n vertical aleatoria dentro del �rea de spawn
            float randomHeight = UnityEngine.Random.Range(-spawnAreaHeight / 2f, spawnAreaHeight / 2f);
            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + randomHeight, spawnPoint.position.z);


            // Instanciar el enemigo en el punto de spawn
            Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);

        }
    }
}
