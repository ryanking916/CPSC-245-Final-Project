using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.OnGameStart += StartGame;
    }

    public void StartGame()
    {
        print("game has started");
    }

    public void EndGame()
    {
        print("game over");
    }

    public void HandlePauseTrigger()
    {
        if (EventHandler.GameIsPaused)
        {
            print("game is paused");
        }
        else
        {
            print("game is unpaused");
        }
    }

    private void OnEnable()
    {
        EventHandler.OnGamePause += HandlePauseTrigger;
        EventHandler.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        EventHandler.OnGamePause -= HandlePauseTrigger;
        EventHandler.OnGameEnd -= EndGame;
    }

    private void OnDestroy()
    {
        EventHandler.OnGameStart -= StartGame;
    }
}
