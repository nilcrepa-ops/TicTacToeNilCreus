using TicTacToe.Logic;

namespace TicTacToe.Players;

/// <summary>
/// Contract defining a player's identity and move acquisition mechanism.
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// Gets the display name of the player.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the mark assigned to the player (X or O).
    /// </summary>
    CellSymbol Symbol { get; }

    /// <summary>
    /// Determines and returns the next move as a 0-based index (0 to 8).
    /// </summary>
    /// <param name="virtualBoard">The current state of the board.</param>
    /// <returns>A 0-based cell position.</returns>
    int GetMove(Board virtualBoard);
}
