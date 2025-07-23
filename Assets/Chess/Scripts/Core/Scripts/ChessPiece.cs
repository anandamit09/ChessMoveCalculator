using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public int row, column;
    public bool isWhite;

    private void Start()
    {
        transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
    }

    public abstract List<Vector2Int> GetPossibleMoves(GameObject[,] board);

    protected bool IsValidMove(int r, int c)
    {
        return r >= 0 && r < 8 && c >= 0 && c < 8;
    }

    protected bool CanCapture(GameObject[,] board, int r, int c)
    {
        if (board[r, c] != null)
        {
            ChessPiece otherPiece = board[r, c].GetComponent<ChessPiece>();
            return otherPiece != null && otherPiece.isWhite != this.isWhite;
        }
        return false;
    }

    private void OnMouseUp()
    {
        if (!ChessGameManager.Instance.IsGameOver() && ChessGameManager.Instance.GetCurrentPlayer() == isWhite)
        {
            ChessGameManager.Instance.SelectPiece(this);
        }
    }
}


