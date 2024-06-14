using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaDesdeelTutorial : MonoBehaviour
{
    public string mundo;
    private bool estaEnLaPuerta = false;
    void Start()
    {

    }

    void Update()
    {

        if (estaEnLaPuerta && Input.GetKeyDown(KeyCode.UpArrow))
        {
            

                SceneManager.LoadScene(mundo);
                estaEnLaPuerta = false;

            


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
    public void IrTutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }
    public void salirJuego()
    {
        Application.Quit();
    }

}
