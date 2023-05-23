using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private Camera _camera;
    [SerializeField] private Piece _piece;
    [SerializeField] private Vector2Int _lastPosition;
    [SerializeField] private float gridSize;
    [SerializeField] private bool _isMovingPiece;
    private Vector3 _startPosition;
    private bool _hasPieceMoved = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMovingPiece = true;
            _startPosition = GetRayPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Restore();
        }

        if (!_isMovingPiece) return;
        Vector3 pos = GetRayPosition();
        Vector2Int intPos = GetIntPosition(pos);
        if (intPos == _lastPosition) return;
        Vector2Int offset = intPos - _lastPosition;
        offset.y = Mathf.Clamp(offset.y, -100, 0);
        _lastPosition = intPos;
        Move(offset);
    }

    private Vector2Int GetIntPosition(Vector3 position)
    {
        Vector3 offset = position - _startPosition;
        float x = offset.x;
        float y = offset.y;
        return new Vector2Int()
        {
            x = GetIntPosition(x),
            y = GetIntPosition(y)
        };
    }

    private int GetIntPosition(float x)
    {
        if (x >= 0) return Mathf.FloorToInt(x);
        return -GetIntPosition(-x);
    }

    private void Restore()
    {
        if (!_hasPieceMoved)
        {
            Rotate();
        }

        _lastPosition = Vector2Int.zero;
        _hasPieceMoved = false;
        _isMovingPiece = false;
    }

    private void Move(Vector2Int translation)
    {
        Debug.Log($"Move: {translation}");
        _hasPieceMoved = true;
        _board.Clear(_piece);
        _piece.Move(translation);
        _board.Set(_piece);
    }

    private void Rotate()
    {
        _board.Clear(_piece);
        _piece.Rotate(1);
        _board.Set(_piece);
    }

    private Vector3 GetRayPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.zero, Vector3.forward);
        plane.Raycast(ray, out float enter);
        return ray.GetPoint(enter);
    }
}