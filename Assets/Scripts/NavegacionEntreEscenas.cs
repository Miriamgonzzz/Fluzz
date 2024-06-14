using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacionEntreEscenas : MonoBehaviour
{
    public string mundo;
    public string escenaFinal;
    private bool estaEnLaPuerta = false;
    private bool irAlFinalDelJuego = false;
    void Start()
    {

    }

    void Update()
    {

        if (estaEnLaPuerta && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //busca el objeto llamado LevelController
            LevelController levelController = FindFirstObjectByType<LevelController>();

            //si la escena en la que te encuentras al activar la puerta coincide con uno de estos 4 nombres...
            if (SceneManager.GetActiveScene().name == "MundoAcuaticoOK" || 
                SceneManager.GetActiveScene().name == "MundoJapon" || 
                SceneManager.GetActiveScene().name == "MundoGrecia" || 
                SceneManager.GetActiveScene().name == "MundoVolcan")
            {
                //...agrega a niveles completados del LevelController ese nombre del nivel
                levelController.CompletarNivel(SceneManager.GetActiveScene().name);

            }

            irAlFinalDelJuego = levelController.ComprobarNivelesCompletados();

            if (irAlFinalDelJuego)
            {
                SceneManager.LoadScene(escenaFinal);
                estaEnLaPuerta = false;
            }
            else {
                SceneManager.LoadScene(mundo);
                estaEnLaPuerta = false;

            }

            
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fluzz"))
        {
            estaEnLaPuerta = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto es "Fluzz"
        if (other.CompareTag("Fluzz"))
        {
            estaEnLaPuerta = false;
        }
    }
    public void IrTutorial(){
        SceneManager.LoadScene("Tutorial");

    }
    public void salirJuego()
    {
        Application.Quit();
    }
    

}
