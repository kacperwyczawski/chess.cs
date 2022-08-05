﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace ConsoleChess.ChessPieces;

/// <inheritdoc cref="ChessPiece"/>
public sealed class Bishop : ChessPiece
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bishop"/> class.
    /// </summary>
    /// <param name="color">
    /// Color of chess piece.
    /// </param>
    public Bishop(Color color)
        : base(color)
    {
    }

    /// <inheritdoc/>
    public override char ToChar() => 'B';

    /// <inheritdoc/>
    public override bool ValidateMove(Cell from, Cell to, ChessBoard board)
    {
        // if move is not diagonal, return false
        if (Math.Abs(from.X - to.X) == Math.Abs(from.Y - to.Y) == false)
            return false;

        int xIterator;
        int yIterator;

        // North-West direction
        if (to.X < from.X && to.Y < from.Y)
        {
            xIterator = from.X - 1;
            yIterator = from.Y - 1;

            // if there is a piece in the way, return false
            for (; xIterator >= to.X && yIterator >= to.Y; xIterator--, yIterator--)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // North-East direction
        if (to.X > from.X && to.Y < from.Y)
        {
            xIterator = from.X + 1;
            yIterator = from.Y - 1;

            // if there is a piece in the way, return false
            for (; xIterator <= to.X && yIterator >= to.Y; xIterator++, yIterator--)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-West direction
        if (to.X < from.X && to.Y > from.Y)
        {
            xIterator = from.X - 1;
            yIterator = from.Y + 1;

            // if there is a piece in the way, return false
            for (; xIterator >= to.X && yIterator <= to.Y; xIterator--, yIterator++)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // South-East direction
        if (to.X > from.X && to.Y > from.Y)
        {
            xIterator = from.X + 1;
            yIterator = from.Y + 1;

            // if there is a piece in the way, return false
            for (; xIterator <= to.X && yIterator <= to.Y; xIterator++, yIterator++)
            {
                if (board[xIterator, yIterator].IsOccupied)
                    return false;
            }

            // if there was no pieces in the way, return true
            return true;
        }

        // this return statement should never be reached, but is here to make the compiler happy :P
        return false;
    }

    public override IEnumerable<Cell> GetValidMoves(Cell position, ChessBoard board)
    {
        // North-West direction
        for (int x = position.X - 1, y = position.Y - 1; x >= 0 && y >= 0; x--, y--)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // North-East direction
        for (int x = position.X + 1, y = position.Y - 1; x <= 7 && y >= 0; x++, y--)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // South-West direction
        for (int x = position.X - 1, y = position.Y + 1; x >= 0 && y <= 7; x--, y++)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
        
        // South-East direction
        for (int x = position.X + 1, y = position.Y + 1; x <= 7 && y <= 7; x++, y++)
        {
            if (board[x, y].IsOccupied)
                break;

            yield return board[x, y];
        }
    }
}