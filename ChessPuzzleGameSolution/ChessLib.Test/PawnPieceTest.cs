namespace CaptainCoder.Chess.Test;
using CaptainCoder.Chess;

public class PawnPieceTest
{
    [Fact]
    public void TestCanMoveForward()
    {
        /*
         0 XXXX
         1 XXXX
         2 XXXX
         3 XXPX
           0123
        */
        // Initialize PawnPiece
        IGameBoard board = new GameBoard(4, 4);
        IPiece pawn = new PawnPiece(board, (3, 2), PieceColor.White);
        board.InitBoard();
        List<(int, int)> moves = pawn.GetPossibleMoves();
        Assert.Single(moves);
        Assert.Contains(moves, pos => pos == (2,2));

        Assert.Equal((3, 2), pawn.Position);
        Assert.False(pawn.HasMoved);
        Assert.False(pawn.TryMove((0, 0)));
        Assert.Equal((3, 2), pawn.Position);
        Assert.False(pawn.HasMoved);

        Assert.True(pawn.TryMove((2,2)));
        Assert.Equal((2, 2), pawn.Position);
        Assert.True(pawn.HasMoved);

        /*
         0 XXXX
         1 XXXX
         2 XXPX
         3 XXXX
           0123
        */

        moves = pawn.GetPossibleMoves();
        Assert.Single(moves);
        Assert.Contains(moves, pos => pos == (1,2));
        Assert.False(pawn.TryMove((0, 0)));
        Assert.Equal((2, 2), pawn.Position);
        Assert.True(pawn.TryMove((1, 2)));
        Assert.Equal((1, 2), pawn.Position);

        /*
         0 XXXX
         1 XXPX
         2 XXXX
         3 XXXX
           0123
        */

        moves = pawn.GetPossibleMoves();
        Assert.Single(moves);
        Assert.Contains(moves, pos => pos == (0,2));
        Assert.False(pawn.TryMove((0, 0)));
        Assert.Equal((1, 2), pawn.Position);
        Assert.True(pawn.TryMove((0, 2)));
        Assert.Equal((0, 2), pawn.Position);

        /*
         0 XXPX
         1 XXXX
         2 XXXX
         3 XXXX
           0123
        */
        
        moves = pawn.GetPossibleMoves();
        Assert.Empty(moves);
        Assert.False(pawn.TryMove((0, 0)));
        Assert.Equal((0, 2), pawn.Position);

    }

    [Fact]
    public void TestInit()
    {
        /*
         0 XXXX
         1 XXXX
         2 XXXX
         3 XXPX
           0123
        */
        // Initialize PawnPiece
        IGameBoard board = new GameBoard(4, 4);
        IPiece pawn = new PawnPiece(board, (3, 2), PieceColor.White);
        board.InitBoard();
        List<(int, int)> moves = pawn.GetPossibleMoves();
        pawn.TryMove(2, 2);
        pawn.TryMove(1, 2);
        pawn.TryMove(0, 2);
        pawn.Init();
        Assert.Equal((3, 2), pawn.Position);
        Assert.False(pawn.HasMoved);

    }
}