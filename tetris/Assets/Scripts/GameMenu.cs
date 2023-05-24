
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake()
    {
       button.onClick.AddListener(PlayGame); 
    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene("Tetris");
    }
}
