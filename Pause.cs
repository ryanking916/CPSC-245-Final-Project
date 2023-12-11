using UnityEngine;


public class Pause : MonoBehaviour
{
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
        EnterPauseState();
    }

    private void Update()
    {
        // Check for input or conditions to resume the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResumeGame();
        }
    }

    private void EnterPauseState()
    {
        // Perform actions when entering the Pause state
        Debug.Log("Game Paused");
        chapManGame.ChangeState(ChapManState.Pause); // Change state to Pause in ChapManGame
        Time.timeScale = 0f; // Pause time scale or perform other pause-related actions
    }

    private void ResumeGame()
    {
        // Perform actions to resume the game
        Debug.Log("Resuming Game");
        chapManGame.ChangeState(ChapManState.Playing); // Change state to Playing in ChapManGame
        Time.timeScale = 1f; // Reset time scale to normal
    }

    // Additional methods for handling other aspects of the Pause state

    private void OnDestroy()
    {
        // Cleanup or perform actions when the script is destroyed
    }
}



