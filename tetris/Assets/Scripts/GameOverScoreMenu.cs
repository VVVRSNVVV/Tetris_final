using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreMenu : MonoBehaviour
{

    [SerializeField] private ScoreValue currentScore;
    [SerializeField] private ScoreValue maxScore;

    public TextMeshProUGUI textMeshPro;

    private void ScoreOut()
    {
        textMeshPro.text = $"Max score: {maxScore.Value} \nCurrent score: {currentScore.Value}" ;
    }
    
    private void Awake()
    {
        // Отримуємо посилання на компонент TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        ScoreOut();
        
    }
}
