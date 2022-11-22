namespace CaptainCoder.Chess;

public class PawnPiece : IPiece
{
    public string Name { get; private set; } = "Pawn";
    public PieceColor Color { get; private set; }
    public IGameBoard Board { get; private set; }
    public (int, int) StartPosition { get; private set; }

    private (int, int) _position;
    public (int row, int col) Position 
    { 
        get => _position; 
        private set {
            (int, int) start = _position;
            _position = value;
            OnMove?.Invoke(start, value, this);
        } 
    }
    public bool HasMoved { get; private set; } = false;
    public bool IsCaptured { get; private set; } = false;
    public event Action<(int row, int col), (int row, int col), IPiece>? OnMove;
    public PawnPiece(IGameBoard board, (int, int) startPosition, PieceColor color)
    {
        this.Color = color;
        this.Board = board;
        this.StartPosition = startPosition;
        this.Position = startPosition;
        board.AddPiece(this);
    }

    public List<(int, int)> GetPossibleMoves()
    {
        List<(int, int)> moves = new ();
        int moveDir = this.Color == PieceColor.White ? -1 : 1;
        (int, int) target = (this.Position.row + moveDir, this.Position.col); 
        bool isInBounds = this.Board.IsInBounds(target);
        bool isEmpty =  this.Board.IsEmpty(target);
        if (this.Board.IsInBounds(target) && this.Board.IsEmpty(target))
        {
            moves.Add(target);
        }

        return moves;
    }

    public bool Init()
    {
        this.Position = this.StartPosition;
        this.IsCaptured = false;
        this.HasMoved = false;
        return true;
    }

    public bool TryMove((int, int) target)
    {
        if (this.GetPossibleMoves().Contains(target))
        {
            this.Position = target;
            this.HasMoved = true;
            return true;
        }
        return false;
    }
}