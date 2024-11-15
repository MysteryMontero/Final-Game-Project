using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI countdownText3;
    public TextMeshProUGUI countdownText2;
    public TextMeshProUGUI countdownText1;
    public TextMeshProUGUI goText;

    private bool isSkipped = false; // Flag to track if countdown was skipped

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Notify GameManager that countdown is active
        GameManager.Instance.isCountdownActive = true;

        Time.timeScale = 0; // Freeze game time
        levelText.gameObject.SetActive(true);
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        yield return WaitOrSkip(1f);

        levelText.gameObject.SetActive(false);

        // Show countdown for 3
        countdownText3.gameObject.SetActive(true);
        countdownText3.text = "3";
        yield return WaitOrSkip(1f);
        countdownText3.gameObject.SetActive(false);

        // Show countdown for 2
        countdownText2.gameObject.SetActive(true);
        countdownText2.text = "2";
        yield return WaitOrSkip(1f);
        countdownText2.gameObject.SetActive(false);

        // Show countdown for 1
        countdownText1.gameObject.SetActive(true);
        countdownText1.text = "1";
        yield return WaitOrSkip(1f);
        countdownText1.gameObject.SetActive(false);

        // Show "Go!" text
        goText.gameObject.SetActive(true);
        goText.text = "Go!";
        yield return WaitOrSkip(1f);
        goText.gameObject.SetActive(false);

        Time.timeScale = 1; // Unfreeze game time

        // Notify GameManager that countdown is complete
        GameManager.Instance.isCountdownActive = false;
    }

    // Helper function to wait or skip the countdown
    private IEnumerator WaitOrSkip(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isSkipped = true; // Set the flag
                break;
            }

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        if (isSkipped)
        {
            EndCountdown();
        }
    }

    private void EndCountdown()
    {
        StopAllCoroutines(); // Stop the countdown coroutine
        Time.timeScale = 1; // Unfreeze game time

        // Hide all countdown-related UI
        levelText.gameObject.SetActive(false);
        countdownText3.gameObject.SetActive(false);
        countdownText2.gameObject.SetActive(false);
        countdownText1.gameObject.SetActive(false);
        goText.gameObject.SetActive(false);

        GameManager.Instance.isCountdownActive = false; // Notify GameManager
    }
}