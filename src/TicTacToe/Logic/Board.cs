namespace TicTacToe.Logic;

/// <summary>
/// Represents the 3x3 game board and manages cell state, move registration, and win/draw evaluations.
/// </summary>
public class Board
{
    public const int BoardSize = 9;

    private readonly CellSymbol[] _cells = new CellSymbol[BoardSize];

    /// <summary>
    /// Precomputed winning combinations (3 rows, 3 columns, 2 diagonals) using 0-based indexing.
    /// </summary>
    private static readonly int[][] WinningCombinations =
    [
        // Rows
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],

        // Columns
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],

        // Diagonals
        [0, 4, 8],
        [2, 4, 6]
    ];

    public Board()
    {
        Reset();
    }

    /// <summary>
    /// Gets the current symbol at the specified 0-based cell position (0 to 8).
    /// </summary>
    public CellSymbol GetCell(int position)
    {
        if (position < 0 || position >= BoardSize)
        {
            throw new ArgumentOutOfRangeException(nameof(position), $"Position must be between 0 and {BoardSize - 1}.");
        }

        return _cells[position];
    }

    /// <summary>
    /// Checks whether the specified 0-based cell is within bounds and currently unoccupied.
    /// </summary>
    public bool IsCellEmpty(int position)
    {
        if (position < 0 || position >= BoardSize)
        {
            return false;
        }

        return _cells[position] == CellSymbol.Empty;
    }

    /// <summary>
    /// Registers a move for the specified symbol at the given 0-based position.
    /// Returns true if the move was successfully placed; false if invalid or already occupied.
    /// </summary>
    public bool RegisterMove(int position, CellSymbol symbol)
    {
        if (symbol == CellSymbol.Empty)
        {
            return false;
        }

        if (!IsCellEmpty(position))
        {
            return false;
        }

        _cells[position] = symbol;
        return true;
    }

    /// <summary>
    /// Checks if the specified symbol has won by completing any row, column, or diagonal.
    /// </summary>
    public bool HasWinner(CellSymbol symbol)
    {
        if (symbol == CellSymbol.Empty)
        {
            return false;
        }

        foreach (var combo in WinningCombinations)
        {
            if (_cells[combo[0]] == symbol &&
                _cells[combo[1]] == symbol &&
                _cells[combo[2]] == symbol)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Checks if all 9 cells are filled.
    /// </summary>
    public bool IsFull()
    {
        for (int i = 0; i < BoardSize; i++)
        {
            if (_cells[i] == CellSymbol.Empty)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Clears all cells on the board, resetting each cell to Empty.
    /// </summary>
    public void Reset()
    {
        Array.Clear(_cells, 0, BoardSize);
    }

    /// <summary>
    /// Returns a list of all currently unoccupied 0-based cell positions.
    /// </summary>
    public IReadOnlyList<int> GetAvailableMoves()
    {
        var available = new List<int>();
        for (int i = 0; i < BoardSize; i++)
        {
            if (_cells[i] == CellSymbol.Empty)
            {
                available.Add(i);
            }
        }

        return available;
    }
}
