namespace CaptainCoder.Chess;
public interface IPiece
{
    /// <summary>
    /// The common name for this IPiece
    /// </summary>
    public String Name { get; }

    /// <summary>
    /// The color of this IPiece
    /// </summary>
    public PieceColor Color { get; }

    /// <summary>
    /// The board that this piece is currently associated with.
    /// </summary>
    public IGameBoard Board { get; }

    /// <summary>
    /// The position that this piece starts at
    /// </summary>
    public (int row, int col) StartPosition { get; }

    /// <summary>
    /// The current position of this piece
    /// </summary>
    public (int row, int col) Position { get; }

    /// <summary>
    /// True if this piece has moved at least once and false otherwise
    /// </summary>
    public bool HasMoved { get; }

    /// <summary>
    /// True if this piece has been captured and false otherwise
    /// </summary>
    public bool IsCaptured { get; }

    /// <summary>
    /// Attempts to move this piece to the specified position. If
    /// the piece was able to move, returns true otherwise returns false.
    /// </summary>
    public bool TryMove((int, int) target);

    /// <summary>
    /// Returns a list of possible moves that this piece can make
    /// </summary>
    public List<(int, int)> GetPossibleMoves();

    /// <summary>
    /// If this piece is associated with a board, initializes it.
    /// If this method returns true, IsCaptured will be false, HasMoved
    /// will be false, and Position == StartPosition. Otherwise,
    /// the state of this IPiece is unknown.
    /// </summary>
    public bool Init();
}
