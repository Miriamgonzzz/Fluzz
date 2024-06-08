using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        // Asegurar que sólo hay una instancia de GameController
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RespawnPlayer(FluzzMinotauro player, Transform respawnPoint, float maxVida, float tiempoDeRespawn)
    {
        StartCoroutine(Respawn(player, respawnPoint, maxVida, tiempoDeRespawn));
    }

    private IEnumerator Respawn(FluzzMinotauro player, Transform respawnPoint, float maxVida, float tiempoDeRespawn)
    {
        // Esperar el tiempo de respawn
        yield return new WaitForSeconds(tiempoDeRespawn);

        // Reposicionar al jugador al punto de inicio
        player.transform.position = respawnPoint.position;

        // Restablecer la vida al máximo
        player.vida = maxVida;
        player.barraVida.InicializarBarraVida(maxVida);

        // Reactivar al jugador
        player.gameObject.SetActive(true);
    }
}
