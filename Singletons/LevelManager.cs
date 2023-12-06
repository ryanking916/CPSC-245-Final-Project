using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Text levelText; // Reference to your UI Text element

    public int CurrentLevel { get; private set; }

    void Awake()
    {
        CurrentLevel = 1;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, if you want to persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find and update the levelText reference in the new scene
        levelText = FindObjectOfType<Text>(); // Assuming there's only one Text component
        UpdateLevelDisplay();
    }


    public void AdvanceLevel()
    {
        CurrentLevel++;
        UpdateLevelDisplay();
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the range of available scenes
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    private void UpdateLevelDisplay()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + CurrentLevel.ToString();
        }
    }

    // Optionally, you can have a method to set a specific level
    public void SetLevel(int level)
    {
        CurrentLevel = level;
        UpdateLevelDisplay();
    }
}
