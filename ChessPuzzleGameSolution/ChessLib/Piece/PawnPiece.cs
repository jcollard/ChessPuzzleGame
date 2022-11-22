namespace CaptainCoder.Chess;

public class PawnPiece : IPiece
{
    public string Name { get; private set; } = "Pawn";
    public PieceColor Color { get; private set; }
    public IGameBoard Board { get; private set; }
    public (int, int) StartPosition { get; private set; }
    public (int, int) Position { get; private set; }
    public bool HasMoved { get; private set; } = false;
    public bool IsCaptured { get; private set; } = false;

    public PawnPiece(IGameBoard board, (int, int) startPosition)
    {
        this.Board = board;
        this.StartPosition = startPosition;
        this.Position = startPosition;
        board.AddPiece(this);
    }

    public List<(int, int)> GetPossibleMoves()
    {
        throw new NotImplementedException();
    }

    public bool Init()
    {
        throw new NotImplementedException();
    }

    public bool TryMove((int, int) target)
    {
        throw new NotImplementedException();
    }
}