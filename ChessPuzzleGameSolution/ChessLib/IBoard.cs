namespace CaptainCoder.Chess;

/// <summary>
/// An IChessBoard represents a rectangular grid which holds
/// some number of IPieces.
/// </summary>
public interface IChessBoard
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
    /// Returns the IPiece that occupies the specified position on the board.
    /// If no piece is in that position, this method will throw an 
    /// </summary>
    /// <param name="pos">A (row, col) pair that contains a piece on this board.</param>
    /// <exception cref="InvalidOperationException">Thrown if no piece is in the specified position.</exception>
    public IPiece GetPiece((int, int) pos);

    /// <summary>
    /// Resets the state of the board by initializing all of the current pieces
    /// that are on the board.
    /// </summary>
    public void ResetBoard();
}