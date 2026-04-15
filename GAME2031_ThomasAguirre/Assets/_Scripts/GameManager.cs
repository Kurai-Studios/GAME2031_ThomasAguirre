using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer Setting")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float gameTime;

    [Header("References")]
    [SerializeField] private GameObject spawner;
    [SerializeField] private PlayerController player;

    private float currentTime;
    private bool isGameActive = true;
    void Start()
    {
        currentTime = gameTime;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (isGameActive && currentTime > 0)
        {
            yield return new WaitForSeconds(1);

            currentTime--;
            UpdateDisplay();
        }

        if (currentTime <= 0)
            OnTimerEnd();
    }

    private void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Update()
    {
        if (isGameActive && player != null && player.GetCurrentLives() <= 0)
            OnGameOver();
    }

    private void OnTimerEnd()
    {
        isGameActive = false;
        Debug.Log("Game Over! You escaped from the seal holding you for centuries");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        if (player != null)
            player.enabled = false;

        if (spawner != null)
            spawner.SetActive(false);

        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Points");
        foreach (GameObject obj in fallingObjects)Destroy(obj);

        GameObject[] dangerObjects = GameObject.FindGameObjectsWithTag("Danger");
        foreach (GameObject obj in dangerObjects) Destroy(obj);

        
    }

    private void OnGameOver()
    {
        isGameActive = false;
        Debug.Log("You couldn't escape the seal and will remain trapped");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        StopCoroutine(UpdateTimer());

        if (player != null)
            player.enabled = false;

        if (spawner != null)
            spawner.SetActive(false);

        GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag("Points");
        foreach (GameObject obj in fallingObjects) Destroy(obj);

        GameObject[] dangerObjects = GameObject.FindGameObjectsWithTag("Danger");
        foreach (GameObject obj in dangerObjects) Destroy(obj);
    }
}
