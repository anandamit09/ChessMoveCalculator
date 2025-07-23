using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GetPossibleMoves(GameObject[,] board)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //move logic
        int[] directionsX = { 0, 0, -1, 1, 1, -1, 1, -1 };
        int[] directionsY = { -1, 1, 0, 0, 1, 1, -1, -1 };

        for (int i = 0; i < 8; i++)
        {
            int r = row + directionsY[i];
            int c = column + directionsX[i];

            if (IsValidMove(r, c))
            {
                if (board[r, c] == null || CanCapture(board, r, c))
                {
                    moves.Add(new Vector2Int(r, c));
                }
            }
        }

        return moves;
    }
}
