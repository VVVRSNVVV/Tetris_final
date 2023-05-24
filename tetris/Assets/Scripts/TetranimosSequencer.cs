using UnityEngine;

public class TetranimosSequencer : MonoBehaviour
{
    [SerializeField] private TetrominoData[] tetrominoes;
    private bool _isInited;
    public TetrominoData Current { get; private set; }
    public TetrominoData Next { get; private set; }


    private void Init()
    {
        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
        Current = GetRandomTetrominoData();
        Next = GetRandomTetrominoData();
        _isInited = true;
    }


    public TetrominoData MoveNext()
    {
        if (!_isInited)
        {
            Init();
        }

        Current = Next;
        Next = GetRandomTetrominoData();
        return Current;
    }

    

    private TetrominoData GetRandomTetrominoData()
    {
        int random = UnityEngine.Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];
        return data;
    }
}