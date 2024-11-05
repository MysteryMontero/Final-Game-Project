using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject characterPrefab; // Assign your character prefab in the Inspector
    public Vector3 spawnPosition = new Vector3(0, 0, 0); // Default spawn position

    private GameObject currentCharacter; // To keep track of the instantiated character

    public GameObject deathScreenPanel;

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
        Time.timeScale = 0;
        // Optionally handle character destruction or respawn logic here

        {
            if (deathScreenPanel != null)
            {
                deathScreenPanel.SetActive(true);  // Display the death screen
            }
            Time.timeScale = 0; // Pause the game
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
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
                             // Add any other game start logic here if needed
    }
}
