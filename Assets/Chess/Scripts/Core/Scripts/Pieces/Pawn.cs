using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetPossibleMoves(GameObject[,] board)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //move logic
        int direction = isWhite ? 1 : -1;
        int forwardRow = row + direction;

        if (IsValidMove(forwardRow, column))
        {
            if (board[forwardRow, column] == null)
            {
                moves.Add(new Vector2Int(forwardRow, column));

                // 2 for first move
                int doubleForwardRow = row + (2 * direction);
                if ((isWhite && row == 1) || (!isWhite && row == 6))
                {
                    if (board[doubleForwardRow, column] == null && board[forwardRow, column] == null)
                    {
                        moves.Add(new Vector2Int(doubleForwardRow, column));
                    }
                }
            }
            else
            {

            }
        }

        //diagonals
        int[] captureOffsets = { -1, 1 };
        foreach (int offset in captureOffsets)
        {
            int captureCol = column + offset;
            if (IsValidMove(forwardRow, captureCol) && CanCapture(board, forwardRow, captureCol))
            {
                moves.Add(new Vector2Int(forwardRow, captureCol));
            }
        }

        return moves;
    }
}

