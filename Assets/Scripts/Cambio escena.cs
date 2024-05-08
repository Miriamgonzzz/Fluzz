using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cambioescena : MonoBehaviour
{
    public string nombreEscena;

    // Start is called before the first frame update

    public void CambiarEscena()
    {
        if (nombreEscena.Equals("Salir", System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Quitar");
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(nombreEscena);
            Debug.Log("Cambio");

        }
    }
}
