using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
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

            while (IsValidMove(r, c))
            {
                if (board[r, c] == null)
                {
                    moves.Add(new Vector2Int(r, c));
                }
                else
                {
                    ChessPiece pieceOnTile = board[r, c].GetComponent<ChessPiece>();

                    if (pieceOnTile.isWhite != this.isWhite)
                    {
                        moves.Add(new Vector2Int(r, c));
                    }
                    break;
                }

                r += directionsY[i];
                c += directionsX[i];
            }
        }

        return moves;
    }
}

