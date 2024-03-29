﻿using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Serializable]
    public class GameBoardParams
    {
        public Vector2 dimensions;
        public float padding;
    }

    public GameObject gem;
    public Transform board;
    public GameBoardParams gameBoardParams;

    private Vector2 _gemSize;
    private Vector2 _boardSize;

    private void Awake()
    {
        _gemSize = gem.GetComponent<BoxCollider2D>().size;
        var boardHorizontalSize = _gemSize.x * gameBoardParams.dimensions.x + gameBoardParams.padding *
                                  (gameBoardParams.dimensions.x - 1);
        var boardVerticalSize = _gemSize.y * gameBoardParams.dimensions.y + gameBoardParams.padding *
                                (gameBoardParams.dimensions.y - 1);
        _boardSize = new Vector2(boardHorizontalSize, boardVerticalSize);
    }

    private void Start()
    {
        for (var horizontalIndex = 0; horizontalIndex < gameBoardParams.dimensions.x; horizontalIndex++)
        {
            ForEachBoardLine(horizontalIndex);
        }
    }

    private void ForEachBoardLine(int horizontalIndex)
    {
        for (var verticalIndex = 0; verticalIndex < gameBoardParams.dimensions.y; verticalIndex++)
        {
            ForEachBoardColumn(horizontalIndex, verticalIndex);
        }
    }

    private void ForEachBoardColumn(int horizontalIndex, int verticalIndex)
    {
        var horizontalPosition = _gemSize.x / 2 + horizontalIndex * (_gemSize.x + gameBoardParams.padding);
        var verticalPosition = _gemSize.y / 2 + verticalIndex * (_gemSize.y + gameBoardParams.padding);
        var gemCoordinate = new Vector2(horizontalPosition, verticalPosition) - _boardSize / 2;
        
        Instantiate(gem, gemCoordinate, Quaternion.identity, board.transform);
    }
}
