using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScript : MonoBehaviour
{
    [SerializeField] private PauseScript pauseScript;
    public void PlayGame()
    {
        pauseScript.ResumeGame();
        SceneManager.LoadScene("Tetris");
    }
}
