using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;       // El prefab del enemigo
    public Transform[] spawnPoints;      // Array de posiciones de spawn
    public float minSpawnInterval = 5f;  // Intervalo mínimo de spawn en segundos
    public float maxSpawnInterval = 15f; // Intervalo máximo de spawn en segundos

    private void Start()
    {
        // Iniciar la generación de enemigos
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generar un intervalo de spawn aleatorio
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Esperar el intervalo de spawn
            yield return new WaitForSeconds(spawnInterval);

            // Seleccionar un punto de spawn aleatorio
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Instanciar el enemigo en el punto de spawn
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
