using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level = 0;
    [SerializeField] Board _board;
    public Action<int> onLevelUpdate;

    // Start is called before the first frame update
    void Awake()
    {
        _board.OnLinesCleared += _board_OnLinesCleared;
        
    }

    private void _board_OnLinesCleared(int linesCleared)
    {
        linesClearedOnCurrentLevel += linesCleared;
        if (linesClearedOnCurrentLevel >= (level+1)*10)//(level+1)*10)
        { 
        linesClearedOnCurrentLevel= 0;
            level++;
            onLevelUpdate?.Invoke(level);
        }
    }
    int linesClearedOnCurrentLevel;

    // Update is called once per frame
    void Update()
    {
        
    }
}
