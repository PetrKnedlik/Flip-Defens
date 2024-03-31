using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pattern to easily access the instance of the GameManager

    public Canvas gameOverCanvas;
    private int enemiesDestroyed = 0;
    public int winCondition; // Number of enemies to destroy to win

    void Awake()
    {
        // Singleton pattern setup
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        gameOverCanvas.gameObject.SetActive(false);
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        if (enemiesDestroyed >= winCondition)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameOverCanvas.gameObject.SetActive(true); // Show the win message
        // Optionally, add more logic here for what happens when the player wins (stop game, show menu, etc.)
        Time.timeScale = 0f; // Stop the game
    }
}
