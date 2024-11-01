using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreenPanel; // Assign in inspector

    private void Start()
    {
        deathScreenPanel.SetActive(false); // Hide the death screen initially
    }

    public void ShowDeathScreen()
    {
        deathScreenPanel.SetActive(true); // Show the death screen
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }

    public void HideDeathScreen()
    {
        deathScreenPanel.SetActive(false); // Hide the death screen
    }
}
