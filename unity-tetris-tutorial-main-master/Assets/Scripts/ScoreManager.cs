using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private ScoreValue currentScore;
    [SerializeField] private ScoreValue maxScore;
    [SerializeField] private LevelManager _levelManager;
    public int Score => currentScore.Value;
    public int MaxScore => maxScore.Value;

    public Action<int> onScoreUpdate;

    private void Awake()
    {
        currentScore.Value = 0;
        LoadScore();
    }
    void Start()
    {
        _board.OnLinesCleared += _board_OnLinesCleared;
    }

    private void _board_OnLinesCleared(int linesCleared)
    {
        currentScore.Value += GetScore(linesCleared, _levelManager.level);
        onScoreUpdate?.Invoke(currentScore.Value);
    }
    private int GetScore(int linesCleared, int level)
    {
        switch (linesCleared)
        {
            case 1: return ((level+1)*40);
            case 2: return ((level+1)*100);
            case 3: return ((level+1)*300);
            case 4: return ((level+1)*1200);
        }
        throw new System.ArgumentException($"lines cleared should be in range 1 to 4 but was {linesCleared}");

    }



    //saving
    public void SaveScore()
    {
        if (MaxScore >= Score) return;
        maxScore.Value = Score;
        SaveSystem.SaveScore(MaxScore);
    }
    public void LoadScore()
    {
        ScoreData data = SaveSystem.LoadScore();
        maxScore.Value = data.score;
    }
}
