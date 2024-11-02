using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreenPanel; // Assign in the Inspector

    private void Start()
    {
        // Hide the death screen initially
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false);
            Debug.Log("Death screen initialized and hidden.");
        }
        else
        {
            Debug.LogError("Death screen panel is not assigned!");
        }
    }

    public void ShowDeathScreen()
    {
        // Show the death screen and pause the game
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(true);
            Time.timeScale = 0; // Pause the game
            Debug.Log("Death screen shown.");
        }
        else
        {
            Debug.LogError("Death screen panel is null when trying to show.");
        }
    }

    public void RestartGame()
    {
        // Ensure the game resumes before reloading the scene
        Time.timeScale = 1;
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }

    public void HideDeathScreen()
    {
        // Hide the death screen
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false);
            Debug.Log("Death screen hidden.");
        }
        else
        {
            Debug.LogError("Death screen panel is null when trying to hide.");
        }
    }
}
