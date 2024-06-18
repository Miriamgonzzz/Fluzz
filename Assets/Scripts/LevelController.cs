using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public List<string> niveles; // Lista de los niveles con los nombres de las escenas
    private HashSet<string> nivelesCompletados = new HashSet<string>(); // para ir agregando niveles que se han completado
    public bool juegoCompletado = false;
    public GameObject estrellaAgua;
    public GameObject estrellaVolcan;
    public GameObject estrellaJapon;
    public GameObject estrellaGrecia;


    void Awake()
    {
        // Asegurarse de que este objeto, el controlador de escenas, no se destruya al cargar un nivel
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(estrellaAgua);
        DontDestroyOnLoad(estrellaVolcan);
        DontDestroyOnLoad(estrellaJapon);
        DontDestroyOnLoad(estrellaGrecia);

        // Agregamos los nombres de los 4 niveles a la lista de niveles
        niveles.Add("MundoAcuaticoOK");
        niveles.Add("MundoGrecia");
        niveles.Add("MundoVolcan");
        niveles.Add("MundoJapon");
    }

    public void CompletarNivel(string nombreNivel)
    {
        if (!nivelesCompletados.Contains(nombreNivel))
        {
            nivelesCompletados.Add(nombreNivel);
            Debug.Log("Nivel completado: " + nombreNivel);
        }

        ComprobarNivelesCompletados();
    }

    public bool ComprobarNivelesCompletados()
    {
        if (nivelesCompletados.Count == niveles.Count)
        {
            Debug.Log("Todos los niveles completados. Fin del juego");
            juegoCompletado = true;
            return juegoCompletado;
        }

        // Actualiza las estrellas cada vez que se completa un nivel
        ActualizarEstrellas();

        return juegoCompletado;
    }

    public bool NivelEstaCompletado(string nombreNivel)
    {
        return nivelesCompletados.Contains(nombreNivel);
    }

    public void victoria()
    {
        Debug.Log("Cargando escena final: JuegoCompletado");

        // Verificar si la escena es válida antes de intentar cargarla
        if (Application.CanStreamedLevelBeLoaded("JuegoCompletado"))
        {
            Debug.Log("La escena es válida. Cargando ahora.");
            SceneManager.LoadScene("JuegoCompletado");
        }
        else
        {
            Debug.LogError("La escena 'NombreDeLaEscenaFinal' no se encuentra en los Build Settings o el nombre es incorrecto.");
        }
    }

    void ActualizarEstrellas()
    {
        foreach (var nivel in niveles)
        {

            if (nivelesCompletados.Contains(nivel))
            {
                Debug.Log("Encontré el nivel " + nivel);

               if(nivel == "MundoAcuaticoOK")
                {
                    estrellaAgua.SetActive(true);
                }

                if (nivel == "MundoVolcan")
                {
                    estrellaVolcan.SetActive(true);
                }

                if (nivel == "MundoGrecia")
                {
                    estrellaGrecia.SetActive(true);
                }

                if (nivel == "MundoJapon")
                {
                    estrellaJapon.SetActive(true);
                }
            }
        }
    }

    public void DesactivarEstrellas()
    {
        estrellaAgua.SetActive(false);
        estrellaVolcan.SetActive(false);
        estrellaJapon.SetActive(false);
        estrellaGrecia.SetActive(false);
    }
}
