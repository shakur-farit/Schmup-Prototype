using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which manages the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    // The script that manages all others.
    public static GameManager instance = null;

    [Tooltip("The player gameobject.")]
    public GameObject player = null;

    [Tooltip("Whether or not to allow pausing.")]
    public bool allowPause = true;

    [Header("Game Over Settings:")]
    [Tooltip("The game over effect to create when the game is lost")]
    public GameObject gameOverEffect;

    // Whether or not the application is paused
    private bool isPaused = false;


    private void OnEnable()
    {
        GameEvents.OnQuitButton += QuitGame;
        GameEvents.OnLoadLevel += LoadLevelByName;
        GameEvents.OnPauseButton += PauseGame;
        GameEvents.OnResumeButton += ResumeGame;
        GameEvents.OnRestartButton += RestartLevel;
    }

    private void OnDisable()
    {
        GameEvents.OnQuitButton -= QuitGame;
        GameEvents.OnLoadLevel -= LoadLevelByName;
        GameEvents.OnPauseButton -= PauseGame;
        GameEvents.OnResumeButton -= ResumeGame;
        GameEvents.OnRestartButton -= RestartLevel;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }



    /// <summary>
    /// Description:
    /// Loads a level according to the name provided.
    /// Input:
    /// string levelToLoadName
    /// Returns:
    /// void (no return)
    /// </summary>
    /// <param name="levelToLoadName">The name of the level to load</param>
    private void LoadLevelByName(string levelToLoadName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoadName);
    }

    /// <summary>
    /// Description:
    /// If the game is not paused, pauses the game.
    /// Inputs:
    /// None
    /// Retuns:
    /// void (no return)
    /// </summary>
    private void PauseGame()
    {
        if (allowPause)
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                GetComponent<GameEvents>().ShowPopupPanel("Pause");
                isPaused = true;
            }
        }
    }

    /// <summary>
    /// Description:
    /// If the game is paused, unpauses the game.
    /// Inputs:
    /// None
    /// Retuns:
    /// void (no return)
    /// </summary>
    private void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    /// <summary>
    /// Description:
    /// Restart the current level.
    /// Input:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Description:
    /// Closes the game or exits play mode depending on the case.
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// Description:
    /// Displays game over screen
    /// Inputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    public void GameOver()
    {
        if (gameOverEffect != null)
        {
            Instantiate(gameOverEffect, transform.position, transform.rotation, null);
        }

        GetComponent<GameEvents>().ShowPopupPanel("GameOver");

        Time.timeScale = 0;
    }
}
