using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public Text countdownText; // Reference to the UI Text component for displaying countdown
    public GameManager gameManager; // Reference to GameManager (for starting the game after countdown)

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Display "Level 1"
        countdownText.text = "Level 1";
        yield return new WaitForSeconds(1f);

        // Countdown: 3, 2, 1
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        // Display "Go!" and then hide countdown
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        // Start the game via the GameManager
        gameManager.StartGame();
    }
}