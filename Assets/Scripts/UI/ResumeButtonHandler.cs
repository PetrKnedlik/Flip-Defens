using UnityEngine;
using UnityEngine.UI;

public class ResumeButtonHandler : MonoBehaviour
{
    public PauseMenu pauseMenu; // Assign this in the Inspector

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ResumeGame);
    }

    public void ResumeGame()
    {
        if (pauseMenu != null)
        {
            pauseMenu.ResumeGame();
        }
    }
}
