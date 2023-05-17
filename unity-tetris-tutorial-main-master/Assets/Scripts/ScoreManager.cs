using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private int _score;
    [SerializeField] private LevelManager _levelManager;
    public int Score => _score;

    public Action<int> onScoreUpdate;

    // Start is called before the first frame update
    void Start()
    {
        _board.OnLinesCleared += _board_OnLinesCleared;
    }

    private void _board_OnLinesCleared(int linesCleared)
    {
        _score += GetScore(linesCleared, _levelManager.level);
        onScoreUpdate?.Invoke(_score);
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

    // Update is called once per frame
    void Update()
    {

    }
}
