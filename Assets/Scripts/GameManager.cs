using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    //Store the current state of the game
    public GameState currentState;
    //Store the previous state
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;

    //current stat displays
    public Text currentHealthDisplay;
    public Text currentRecoveryDisplay;
    public Text currentMoveSpeedDisplay;
    public Text currentMightDisplay;
    public Text currentProjectileSpeedDisplay;
    public Text currentMagnetDisplay;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject);
        }
        DisableScreen();    
    }

    void Update()
    {
        //define behavior of each state
        switch (currentState)
        {
            case GameState.Gameplay:
                //code
                CheckForPauseAndResume();
                break;

            case GameState.Paused:
                //code
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                //code
                break;
            default:
                Debug.LogWarning("State does not exit");
                break;
        }    
    }

    //define the method to change state
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("GAME PAUSED");
        } 
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("GAME RESUMED");
        }
    }

    void CheckForPauseAndResume()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreen()
    {
        pauseScreen.SetActive(false);
    }
}
