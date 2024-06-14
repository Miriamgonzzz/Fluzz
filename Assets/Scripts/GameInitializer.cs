using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject pauseMenuPrefab;

    void Start()
    {
        if (PauseMenu.Instance == null)
        {
            Instantiate(pauseMenuPrefab);
        }
    }
}
