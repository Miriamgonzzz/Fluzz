using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;       // El prefab del enemigo
    public Transform[] spawnPoints;      // Array de posiciones de spawn
    public float minSpawnInterval = 1f;  // Intervalo mínimo de spawn en segundos
    public float maxSpawnInterval = 5f; // Intervalo máximo de spawn en segundos
    public GameObject[] Enemigos;
    public Transform player;
    public float activationAngle = 45f;

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
            float spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);

            // Esperar el intervalo de spawn
            yield return new WaitForSeconds(spawnInterval);

            // Seleccionar un punto de spawn aleatorio
            int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

         
            // Seleccionar un enemigo aleatorio del array de prefabs
            int enemyIndex = UnityEngine.Random.Range(0, Enemigos.Length);
            GameObject enemyPrefab = Enemigos[enemyIndex];

            // Instanciar el enemigo en el punto de spawn
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
        }
    }
    private bool IsSpawnPointInFrontOfPlayer(Transform spawnPoint)
    {
        Debug.Log("Entra");
        Vector3 directionToSpawnPoint = spawnPoint.position - player.position;
        float angle = Vector3.Angle(player.forward, directionToSpawnPoint);

        // Verificar si el ángulo está dentro del rango de activación
        return angle < activationAngle;
    }
}
