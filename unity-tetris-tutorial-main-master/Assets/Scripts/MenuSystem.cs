using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    private void Awake()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Tetris");

    }
}
