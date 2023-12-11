using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    // Reference to the ChapManGame state machine
    private ChapManGame chapManGame;

    private void Start()
    {
        // Find the ChapManGame instance in the scene
        chapManGame = FindObjectOfType<ChapManGame>();

        if (chapManGame == null)
        {
            Debug.LogError("ChapManGame not found in the scene.");
        }

        // Set up initial state
        EnterSetupState();
    }

    private void EnterSetupState()
    {
        // Perform actions when entering the Setup state
        Debug.Log("Setting up the game...");

        // Add any additional setup logic here

        // Transition to the Playing state
        chapManGame.ChangeState(ChapManState.Playing);
    }

    // Additional methods for handling other aspects of the Setup state

    private void OnDestroy()
    {
        // Cleanup or perform actions when the script is destroyed
    }
}

