using UnityEngine;
using UnityEngine.Tilemaps;

public class NextTetraminoDisplay : MonoBehaviour
{
    [SerializeField] private TetranimosSequencer _sequencer;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Vector3Int _offset;

    private void Update()
    {
        Clear(_sequencer.Current);
        Clear(_sequencer.Next);
        Draw(_sequencer.Next);
    }

    private void Clear(TetrominoData data)
    {
        foreach (var cell in data.cells)
        {
            var pos = _offset + (Vector3Int) cell;
            _tilemap.SetTile(pos, null);
        }
    }

    private void Draw(TetrominoData data)
    {
        foreach (var cell in data.cells)
        {
            var pos = _offset + (Vector3Int) cell;
            _tilemap.SetTile(pos, data.tile);
        }
    }
}