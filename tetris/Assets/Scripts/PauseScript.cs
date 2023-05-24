using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool IsPaused { get; private set; }
    public void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        IsPaused = false;
    }
}
