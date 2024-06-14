using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<string> niveles; //Lista de los niveles con los nombres de las escenas
    private HashSet<string> nivelesCompletados = new HashSet<string>(); //para ir agregando niveles que se han completado

    void Awake()
    {
        //Asegurarse de que este objeto, el controlador de escenas, no se destruya al cargar un nivel
        DontDestroyOnLoad(gameObject);

        //agregamos los nombres de los 4 niveles a la lista de niveles
        niveles.Add("MundoAcuaticoOK");
        niveles.Add("MundoJapon");
        niveles.Add("MundoGrecia");
        niveles.Add("MundoVolcan");
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

    private void ComprobarNivelesCompletados()
    {
        if (nivelesCompletados.Count == niveles.Count)
        {
            Debug.Log("Todos los niveles completados. Fin del juego");
            //PONER AQUÍ LA CARGA DE LA ESCENA FINAL DEL JUEGO
        }
    }

    public bool NivelEstaCompletado(string nombreNivel)
    {
        return nivelesCompletados.Contains(nombreNivel);
    }
}
