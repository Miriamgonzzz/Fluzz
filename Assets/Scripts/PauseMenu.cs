using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private bool isMusicOn = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadStation()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("EstacionCentral");
    }

    public void QuitGame()
    {
        Debug.Log("hola");
        Application.Quit();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        // Aqu� debes controlar la m�sica del juego. 
        // Por ejemplo, si tienes un componente de AudioManager, puedes llamarlo aqu� para pausar/reanudar la m�sica.
        if (isMusicOn)
        {
            // AudioManager.Instance.PlayMusic();
        }
        else
        {
            // AudioManager.Instance.StopMusic();
        }
    }
}
