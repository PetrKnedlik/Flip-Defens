using UnityEngine;
using UnityEngine.UI; // Include this if you're using UI elements for the message

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pattern to easily access the instance of the GameManager

    public Text winMessage; // Assign a UI Text component in the Inspector
    private int enemiesDestroyed = 0;
    public int winCondition = 10; // Number of enemies to destroy to win

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

        winMessage.gameObject.SetActive(false); // Make sure the win message is hidden initially
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
        winMessage.gameObject.SetActive(true); // Show the win message
        // Optionally, add more logic here for what happens when the player wins (stop game, show menu, etc.)
    }
}
