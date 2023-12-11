using UnityEngine;

public class WinState : MonoBehaviour
{
    // Reference to the game state machine
    private ChapManGame chapManGame;

    // Reference to the UI panel for the win screen
    public GameObject winPanel;

    // Reference to a Text component on the win panel to display a message
    public Text winMessageText;

    private void Start()
    {
        // Find the ChapManGame instance in the scene
        chapManGame = FindObjectOfType<ChapManGame>();

        if (chapManGame == null)
        {
            Debug.LogError("ChapManGame not found in the scene.");
        }
        
        EnterWinState();
    }

    private void Update()
    {
        // Check conditions for transitioning to the main menu
        if (winPanel.activeSelf && Input.anyKeyDown)
        {
            ReturnToMainMenu();
        }
    }

    private void EnterWinState()
    {
        // Perform actions when entering the Win state
        Debug.Log("Game Won");

        // Display a custom win message
        if (winMessageText != null)
        {
            winMessageText.text = "Congratulations!\nYou Won!";
        }

        // Activate the win screen UI panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Transition to the Win state
       chapManGame.ChangeState(ChapManState.Win);
    }

    private void ReturnToMainMenu()
    {
        // Perform actions to return to the main menu
        Debug.Log("Returning to Main Menu");

        // Deactivate the win screen UI panel
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        // Transition to the Main Menu state
        // You can customize this transition based on your game's main menu setup
        // For example, you might use SceneManager.LoadScene("MainMenuScene");
    }

    // Additional methods for handling other aspects of the Win state

    private void OnDestroy()
    {
        // Cleanup or perform actions when the script is destroyed
    }
}