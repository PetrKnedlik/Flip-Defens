using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false; // Tracks the pause state
    public GameObject pauseMenuPrefab; // Add this line
    GameObject pauseMenuInstance; // To store the instantiated object

    void Start() // Or use Awake() if you prefer
    {
        if (pauseMenuPrefab != null)
        {
            pauseMenuInstance = Instantiate(pauseMenuPrefab);
            pauseMenuInstance.SetActive(false); // Initially hide it
        }

        pauseMenuInstance.name = pauseMenuPrefab.name;
    }

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

    if (pauseMenuInstance != null)
    {
        pauseMenuInstance.SetActive(false); // No need to find the Canvas separately
    } else {
        Debug.LogWarning("Pause Menu instance reference is null.");
    } 

    Time.timeScale = 1f;
    isGamePaused = false;
}


    void PauseGame()
    {
        if (pauseMenuInstance != null) // Use the stored instance
        {
            pauseMenuInstance.SetActive(true);
        }
        Time.timeScale = 0f;
        isGamePaused = true;
    }

}