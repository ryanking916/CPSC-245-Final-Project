using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChapManState
{
    Pause,
    Playing,
    Win,
    Loss,
    MainMenu,
    SetUp
}

public class ChapManGame
{
    private ChapManState currentState;

    public ChapManGame()
    {
        currentState = ChapManState.MainMenu;
    }

    public void ChangeState(ChapManState newState)
    {
        currentState = newState;
    }

    public void Update()
    {
        switch (currentState)
        {
            case ChapManState.Pause:
                // Code for handling pause state
                break;
            case ChapManState.Playing:
                // Code for handling playing state
                break;
            case ChapManState.Win:
                // Code for handling win state
                break;
            case ChapManState.Loss:
                // Code for handling loss state
                break;
            case ChapManState.MainMenu:
                // Code for handling main menu state
                break;
            case ChapManState.SetUp:
                // Code for handling set up state
                break;
            default:
                break;
        }
    }
}
