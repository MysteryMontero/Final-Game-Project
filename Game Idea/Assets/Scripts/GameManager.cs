using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isCountdownActive = false; // Flag to track if countdown is active

    public GameObject characterPrefab; // Assign your character prefab in the Inspector

    public Vector3 spawnPosition = new Vector3(0, 0, 0); // Default spawn position

    private GameObject currentCharacter; // To keep track of the instantiated character

    public GameObject deathScreenPanel;

    public bool isPlayerDead = false; // Tracks death state

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Spawn the character at the specified spawn position
        SpawnCharacter(spawnPosition);
        if (deathScreenPanel != null)
        {
            deathScreenPanel.SetActive(false); // Hide initially
        }
    }

    public void PlayerDied()
    {
        isPlayerDead = true; // Set to true when the player dies
        Time.timeScale = 0;
        // Optionally handle character destruction or respawn logic here

        {
            if (deathScreenPanel != null)
            {
                deathScreenPanel.SetActive(true);  // Display the death screen
            }
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnCharacter(Vector3 spawnPosition)
    {
        // Destroy existing character if it exists
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        // Instantiate the character prefab at the specified position and rotation
        currentCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Unpause the game if it was paused
    }

    public void StartCountdown()
    {
        isCountdownActive = true;
        // Start your countdown logic here
    }

    public void EndCountdown()
    {
        isCountdownActive = false;
        // Trigger game start logic here
    }

    public GameObject successScreenPanel; // Assign your success screen panel in Inspector

    public void LevelCompleted()
    {
        successScreenPanel.SetActive(true); // Show the success screen
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your menu scene name
    }
}
