using System.Collections.Generic;
using UnityEngine;

public class ChessGameManager : MonoBehaviour
{
    public static ChessGameManager Instance { get; private set; }

    private ChessPiece selectedPiece;
    private GameObject[,] board = new GameObject[8, 8];
    private bool isWhiteTurn = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializeBoard();
    }

    private void InitializeBoard()
    {
        ChessPiece[] pieces = FindObjectsOfType<ChessPiece>();

        foreach (ChessPiece piece in pieces)
        {
            board[piece.row, piece.column] = piece.gameObject;
        }
    }

    public bool IsGameOver() => false;

    public bool GetCurrentPlayer() => isWhiteTurn;

    public void SelectPiece(ChessPiece piece)
    {
        if (selectedPiece == piece) return;

        ChessBoardPlacementHandler.Instance.ClearHighlights();
        selectedPiece = piece;

        List<Vector2Int> moves = selectedPiece.GetPossibleMoves(board);
        foreach (var move in moves)
        {
            if (board[move.x, move.y] == null)
            {
                ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
            }
            else
            {
                ChessPiece targetPiece = board[move.x, move.y].GetComponent<ChessPiece>();
                if (targetPiece != null && targetPiece.isWhite != selectedPiece.isWhite)
                {
                    ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y, true);
                }
            }
        }
    }
}



