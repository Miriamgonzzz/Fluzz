using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shogun_mecanic : MonoBehaviour
{
    public enum State { estaDormido, estaDespierto, estaAlerta }
    public State currentState = State.estaDormido;

    public Transform respawnPoint;
    public float wakeUpTime = 4f; // Tiempo para despertar
    public float sleepTime = 2f; // Tiempo para dormir si no detecta al jugador
    public float alertTime = 1f; // Tiempo en estado de alerta
    public string playerTag = "Fluzz"; // Tag del jugador
    private Animator animator;
    private CircleCollider2D boxCollider;
    private bool playerInRange = false;
    private GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<CircleCollider2D>();
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.estaDormido:
                    // Estado Dormido
                    animator.SetBool("estaDormido", true);
                    animator.SetBool("estaDespierto", false);
                    animator.SetBool("estaAlerta", false);
                    boxCollider.enabled = false;
                    yield return new WaitForSeconds(wakeUpTime);
                    currentState = State.estaDespierto;
                    break;

                case State.estaDespierto:
                    // Estado Despierto
                    animator.SetBool("estaDormido", false);
                    animator.SetBool("estaDespierto", true);
                    animator.SetBool("estaAlerta", false);
                    boxCollider.enabled = true;

                    // Espera a que el jugador entre en el collider o al tiempo de espera
                    float elapsedTime = 0f;
                    while (elapsedTime < sleepTime)
                    {
                        if (playerInRange)
                        {
                            break;
                        }
                        elapsedTime += Time.deltaTime;
                        yield return null;
                    }

                    if (!playerInRange)
                    {
                        currentState = State.estaDormido;
                    }

                    break;

                case State.estaAlerta:
                    // Estado Alerta
                    animator.SetBool("estaDormido", false);
                    animator.SetBool("estaDespierto", false);
                    animator.SetBool("estaAlerta", true);
                    yield return new WaitForSeconds(alertTime);

                    if (playerInRange && player != null)
                    {
                        Debug.Log("Player detected! Respawning...");
                        player.transform.position = respawnPoint.position;
                    }

                    currentState = State.estaDormido;
                    break;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentState == State.estaDespierto && other.CompareTag(playerTag))
        {
            player = other.gameObject;
            playerInRange = true;
            currentState = State.estaAlerta;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }
}
