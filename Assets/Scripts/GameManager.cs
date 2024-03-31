using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pattern to easily access the instance of the GameManager
    public GameObject gameOverScreenPrefab;
    // public Canvas gameOverCanvas;
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

        gameOverScreenPrefab.gameObject.SetActive(false);
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
        if (gameOverScreenPrefab != null)
        {
            GameObject gameOverInstance = Instantiate(gameOverScreenPrefab);
            gameOverInstance.GetComponent<Canvas>().enabled = true; // Force canvas visibility
            gameOverInstance.SetActive(true);
        }
    }
}
