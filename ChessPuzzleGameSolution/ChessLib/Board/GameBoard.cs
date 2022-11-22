namespace CaptainCoder.Chess;
using System.Linq;

public class GameBoard : IGameBoard
{
    public (int rows, int cols) Size { get; private set; }
    private Dictionary<(int, int), IPiece> _board;
    private HashSet<IPiece> _pieces = new ();
    public GameBoard(int rows, int cols)
    {
        this.Size = (rows, cols);
        this._board = new ();
    }

    public IPiece GetPiece((int, int) pos) => this._board[pos];
    public bool IsEmpty((int, int) pos) => !this._board.ContainsKey(pos);
    public void InitBoard()
    {
        this._board.Clear();
        foreach (IPiece piece in this._pieces)
        {
            piece.Init();
        }
    }

    public void AddPiece(IPiece piece)
    {
        IPiece? other = _pieces.Where(other => piece.StartPosition == other.StartPosition).FirstOrDefault();
        if (other != null)
        {
            throw new InvalidOperationException($"Cannot add {piece.Name} to board because a {other.Name} is already in that StartPosition {piece.StartPosition}.");
        }
        this._pieces.Add(piece);
        piece.OnMove += this.OnPieceMove;
    }

    private void OnPieceMove((int row, int col) start, (int row, int col) end, IPiece piece)
    {
        _board.Remove(start);
        _board[end] = piece;
    }
}