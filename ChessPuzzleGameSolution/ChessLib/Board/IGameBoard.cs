namespace CaptainCoder.Chess;

/// <summary>
/// An IChessBoard represents a rectangular grid which holds
/// some number of IPieces.
/// </summary>
public interface IGameBoard
{
    /// <summary>
    /// A pair, representing the dimensions of this board.
    /// </summary>
    public (int rows, int cols) Size { get; }

    /// <summary>
    /// Given a position on the board, returns true if there is
    /// no piece at that position and false otherwise.
    /// </summary>
    /// <param name="pos">A (row, col) pair that must be within the Size of the board.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the position is outside the bounds of the board.</exception>
    public bool IsEmpty((int, int) pos);

    /// <summary>
    /// Checks if the given position a position on this board.
    /// </summary>
    public bool IsInBounds((int row, int col) pos) => pos.row >= 0 && pos.col >= 0 && pos.row < this.Size.rows && pos.col < this.Size.cols;

    /// <summary>
    /// Returns the IPiece that occupies the specified position on the board.
    /// If no piece is in that position, this method will throw an 
    /// </summary>
    /// <param name="pos">A (row, col) pair that contains a piece on this board.</param>
    /// <exception cref="InvalidOperationException">Thrown if no piece is in the specified position.</exception>
    public IPiece GetPiece((int, int) pos);

    /// <summary>
    /// Adds the specified piece to this board.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the specified piece could not be added to the board</exception>
    public void AddPiece(IPiece piece);

    /// <summary>
    /// Initializes the state of the board by initializing all of the current pieces
    /// that are on the board.
    /// </summary>
    public void InitBoard();
}