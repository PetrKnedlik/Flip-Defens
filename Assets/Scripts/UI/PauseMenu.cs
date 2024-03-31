using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuPrefab; // Add this line
    public static bool isGamePaused = false; // Tracks the pause state
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        if (pauseMenuPrefab != null)
        {
            Instantiate(pauseMenuPrefab);
        }
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
