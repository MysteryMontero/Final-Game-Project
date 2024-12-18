using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Drag the PauseMenu panel here in the Inspector
    private bool isPaused = false;

    void Update()
    {
        // Check for the pause input (e.g., Escape key)
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isCountdownActive &&
            !GameManager.Instance.isPlayerDead)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pause the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f;       // Stop time
        isPaused = true;
    }

    // Resume the game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f;        // Resume time
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Optional methods for buttons
    public void QuitGame()
    {
        Application.Quit(); // Quits the application
        // Note: This only works in a built application, not in the editor.
    }
}