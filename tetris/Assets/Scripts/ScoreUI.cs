using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]  ScoreManager _scoreManager;
    public TextMeshProUGUI textMeshPro;

    private void updateText(int score)
    {
        textMeshPro.text = $"{score}";
    }

    private void Awake()
    {
        // Отримуємо посилання на компонент TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        _scoreManager.onScoreUpdate+=updateText;
        updateText(0);
    }
    
}
