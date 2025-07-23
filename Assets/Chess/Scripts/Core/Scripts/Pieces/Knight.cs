using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetPossibleMoves(GameObject[,] board)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //move logic
        int[] knightMovesX = { 2, 2, -2, -2, 1, -1, 1, -1 };
        int[] knightMovesY = { 1, -1, 1, -1, 2, 2, -2, -2 };

        for (int i = 0; i < 8; i++)
        {
            int r = row + knightMovesY[i];
            int c = column + knightMovesX[i];

            if (IsValidMove(r, c))
            {
                if (board[r, c] == null || CanCapture(board, r, c)) // Can move to empty square or capture
                {
                    moves.Add(new Vector2Int(r, c));
                }
            }
        }

        return moves;
    }
}

