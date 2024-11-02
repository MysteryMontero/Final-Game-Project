using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI levelText; // Drag Level Text from hierarchy
    public TextMeshProUGUI countdownText3; // Drag Countdown Text for "3"
    public TextMeshProUGUI countdownText2; // Drag Countdown Text for "2"
    public TextMeshProUGUI countdownText1; // Drag Countdown Text for "1"
    public TextMeshProUGUI goText;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        Time.timeScale = 0; // Freeze game time
        levelText.gameObject.SetActive(true);
        levelText.text = "Level 1"; // Set level text
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second

        levelText.gameObject.SetActive(false); // Hide level text

        // Show countdown for 3
        countdownText3.gameObject.SetActive(true);
        countdownText3.text = "3";
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second
        countdownText3.gameObject.SetActive(false); // Hide "3"

        // Show countdown for 2
        countdownText2.gameObject.SetActive(true);
        countdownText2.text = "2";
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second
        countdownText2.gameObject.SetActive(false); // Hide "2"

        // Show countdown for 1
        countdownText1.gameObject.SetActive(true);
        countdownText1.text = "1";
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second
        countdownText1.gameObject.SetActive(false); // Hide "1"

        // Show "Go!" text
        goText.gameObject.SetActive(true); // Show "Go!" text
        goText.text = "Go!";
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 second

        goText.gameObject.SetActive(false); // Hide "Go!" text
        Time.timeScale = 1; // Unfreeze game time
    }
}