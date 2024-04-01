using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuPrefab;

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

        if (pauseMenuPrefab != null)
        {
            pauseMenuPrefab.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Pause Menu instance reference is null.");
        }

        Time.timeScale = 1f;
        isGamePaused = false;
    }


    public void PauseGame()
    {
        if (pauseMenuPrefab != null)
        {
            pauseMenuPrefab.SetActive(true);
        }
        Time.timeScale = 0f;
        isGamePaused = true;
    }

}