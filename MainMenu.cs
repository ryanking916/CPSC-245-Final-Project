using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public ChapManGame chapManGame;

    // You may have UI elements like buttons to trigger state changes
    public Button playButton;
    public Button quitButton;
    public Button instructButton;

    private void Start()
    {
        // Set up button click events
        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        instructButton.onClick.AddListener(Instruct);

        // Ensure ChapManGame is not null
        if (chapManGame == null)
        {
            Debug.LogError("ChapManGame not assigned. Assign it in the Unity Editor.");
        }
    }

    private void Update()
    {
        // You may add additional logic related to the main menu here
    }

    private void StartGame()
    {
        // Trigger state change to SetUp when the play button is clicked
        chapManGame.ChangeState(ChapManState.SetUp);
    }

    private void Instruct()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void QuitGame()
    {
        // You may add additional quit game logic here
        Application.Quit();
    }
}

