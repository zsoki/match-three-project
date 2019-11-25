using System;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject gem;
    public RuntimeSet2D board;
    public float padding;

    private Vector2 _gemSize;
    private Vector2 _boardSize;

    private void Awake()
    {
        _gemSize = gem.GetComponent<BoxCollider2D>().size;
        var boardHorizontalSize = _gemSize.x * board.height.value + padding * (board.height.value - 1);
        var boardVerticalSize = _gemSize.y * board.height.value + padding * (board.height.value - 1);
        _boardSize = new Vector2(boardHorizontalSize, boardVerticalSize);
    }

    private void Start()
    {
        for (var horizontalIndex = 0; horizontalIndex < board.height.value; horizontalIndex++)
        {
            ForEachBoardLine(horizontalIndex);
        }
    }

    private void ForEachBoardLine(int horizontalIndex)
    {
        for (var verticalIndex = 0; verticalIndex < board.height.value; verticalIndex++)
        {
            ForEachBoardColumn(horizontalIndex, verticalIndex);
        }
    }

    private void ForEachBoardColumn(int horizontalIndex, int verticalIndex)
    {
        var horizontalPosition = _gemSize.x / 2 + horizontalIndex * (_gemSize.x + padding);
        var verticalPosition = _gemSize.y / 2 + verticalIndex * (_gemSize.y + padding);
        var gemCoordinate = new Vector2(horizontalPosition, verticalPosition) - _boardSize / 2;
        
        var gemObject = Instantiate(gem, gemCoordinate, Quaternion.identity, transform);
        board.Register(gemObject, horizontalIndex, verticalIndex);
    }
}