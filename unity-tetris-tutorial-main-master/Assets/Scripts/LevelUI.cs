using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LevelUI : MonoBehaviour
{
    [SerializeField] LevelManager _levelManager;
    public TextMeshProUGUI textMeshPro;

    private void UpdateLevel(int level)
    {
        textMeshPro.text = $"level: {_levelManager.level}";
    }
    private void Awake()
    {
        // Отримуємо посилання на компонент TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        _levelManager.onLevelUpdate=UpdateLevel;
        UpdateLevel(0);
    }
}
