using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapManLossState : MonoBehaviour
{
    // Reference to the game state machine
    private ChapManGame chapManGame;

    // Reference to the UI panel for the "Game Lost" screen
    public GameObject gameLostPanel;
    


    private void Start()
    {
        // Find the ChapManGame instance in the scene
        chapManGame = FindObjectOfType<ChapManGame>();

        if (chapManGame == null)
        {
            Debug.LogError("ChapManGame not found in the scene.");
        }

        // Set up initial state
        EnterLossState();
    }

    private void Update()
    {
        // Check conditions for transitioning to the main menu
        if (gameLostPanel.activeSelf && Input.anyKeyDown)
        {
            ReturnToMainMenu();
        }
        
    }

    private void EnterLossState()
    {
        // Perform actions when entering the Loss state
        Debug.Log("Game Lost");

        // Activate the "Game Lost" screen UI panel
        if (gameLostPanel != null)
        {
            gameLostPanel.SetActive(true);
        }

        // Transition to the Loss state
        chapManGame.ChangeState(ChapManState.Loss);
    }
    

    private void ReturnToMainMenu()
    {
        // Perform actions to return to the main menu
        Debug.Log("Returning to Main Menu");

        // Deactivate the "Game Lost" screen UI panel
        if (gameLostPanel != null)
        {
            gameLostPanel.SetActive(false);
        }

        // Transition to the Main Menu state
        SceneManager.LoadScene("Main Menu"); // Replace "MainMenuScene" with the actual name of your main menu scene
    }

    // Additional methods for handling other aspects of the Loss state

    private void OnDestroy()
    {
        // Cleanup or perform actions when the script is destroyed
    }
}