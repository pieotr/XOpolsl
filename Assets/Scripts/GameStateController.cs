using UnityEngine;
using UnityEngine.UI;

/// \class GameStateController
/// \brief Manages the overall game state for a Tic-Tac-Toe game.
public class GameStateController : MonoBehaviour
{
    [Header("TitleBar References")]
    public Image playerXIcon;             ///< Icon for player X
    public Image playerOIcon;             ///< Icon for player O
    public InputField player1InputField;  ///< Input field for player 1's name
    public InputField player2InputField;  ///< Input field for player 2's name
    public Text winnerText;               ///< Text UI to display the winner

    [Header("Misc References")]
    public GameObject endGameState;       ///< Container for end game state UI

    [Header("Asset References")]
    public Sprite tilePlayerO;            ///< Sprite for O tile
    public Sprite tilePlayerX;            ///< Sprite for X tile
    public Sprite tileEmpty;              ///< Sprite for an empty tile
    public Text[] tileList;               ///< Array of all tiles as Text UI

    [Header("GameState Settings")]
    public Color inactivePlayerColor;     ///< Color for inactive player icon
    public Color activePlayerColor;       ///< Color for active player icon
    public string whoPlaysFirst;          ///< Indicates who plays first, 'X' or 'O'

    [Header("Private Variables")]
    private string playerTurn;            ///< Current player's turn
    private string player1Name;           ///< Display name for player 1
    private string player2Name;           ///< Display name for player 2
    private int moveCount;                ///< Count of moves made

    /// \brief Initializes the game state at the start.
    private void Start()
    {
        playerTurn = whoPlaysFirst;       // Initialize who plays first

        if (playerTurn == "X") playerOIcon.color = inactivePlayerColor;
        else playerXIcon.color = inactivePlayerColor;

        // Add listeners for name changes
        player1InputField.onValueChanged.AddListener(delegate { OnPlayerNameChanged(ref player1Name, player1InputField.text); });
        player2InputField.onValueChanged.AddListener(delegate { OnPlayerNameChanged(ref player2Name, player2InputField.text); });

        // Set player names from input fields
        player1Name = player1InputField.text;
        player2Name = player2InputField.text;
    }

    /// \brief Updates the player icons based on the current turn.
    private void UpdatePlayerIcons()
    {
        // Set player icon colors based on current turn
        if (playerTurn == "X")
        {
            playerOIcon.color = inactivePlayerColor;
            playerXIcon.color = activePlayerColor;
        }
        else
        {
            playerXIcon.color = inactivePlayerColor;
            playerOIcon.color = activePlayerColor;
        }
    }

    /// \brief Ends the current player's turn and checks for game over conditions.
    public void EndTurn()
    {
        moveCount++;  // Increment move count

        // Check all win conditions
        CheckWinConditions();

        // If no win, change turn
        if (moveCount < 9 && endGameState.activeSelf == false)
        {
            ChangeTurn();
        }
    }

    /// \brief Checks all possible win conditions.
    private void CheckWinConditions()
    {
        // Horizontal, vertical, and diagonal win conditions
        if (CheckLine(0, 1, 2) || CheckLine(3, 4, 5) || CheckLine(6, 7, 8) ||
            CheckLine(0, 3, 6) || CheckLine(1, 4, 7) || CheckLine(2, 5, 8) ||
            CheckLine(0, 4, 8) || CheckLine(2, 4, 6))
        {
            GameOver(playerTurn);  // Declare current player as winner
        }
        else if (moveCount >= 9)
        {
            GameOver("D");  // Declare draw if all moves are exhausted
        }
    }

    /// \brief Checks if a single tile is owned by the current player.
    /// \param index The index of the tile to check.
    /// \return True if the tile is owned by the current player.
    private bool CheckLineSingle(int index)
    {
        return tileList[index].text == playerTurn;
    }

    /// \brief Checks if a line of tiles is owned by the current player.
    /// \param a Index of the first tile in the line.
    /// \param b Index of the second tile in the line.
    /// \param c Index of the third tile in the line.
    /// \return True if all tiles in the line are owned by the current player.
    private bool CheckLine(int a, int b, int c)
    {
        return CheckLineSingle(a) && CheckLineSingle(b) && CheckLineSingle(c);
    }

    /// \brief Changes the turn to the next player.
    private void ChangeTurn()
    {
        playerTurn = playerTurn == "X" ? "O" : "X"; // Toggle player turn
        UpdatePlayerIcons(); // Update UI icons to reflect the change
    }

    /// \brief Ends the game and declares the winner.
    /// \param winningPlayer The player who won the game, or 'D' for a draw.
    private void GameOver(string winningPlayer)
    {
        // Determine the winner and set the winnerText accordingly
        if (winningPlayer == "D")
        {
            winnerText.text = "DRAW";
        }
        else
        {
            if (winningPlayer == "X")
            {
                winnerText.text = player1Name;
                SetNewStartingPlayer("X");
            }
            else
            {
                winnerText.text = player2Name;
                SetNewStartingPlayer("O");
            }
        }

        endGameState.SetActive(true); // Show end game UI
        ToggleButtonState(false); // Disable all buttons
    }

    /// \brief Sets the starting player for a new game.
    /// \param win The player who won the previous game.
    public void SetNewStartingPlayer(string win)
    {
        whoPlaysFirst = win; // Set starting player as winning player
    }

    /// \brief Restarts the game.
    public void RestartGame()
    {
        moveCount = 0;  // Reset move count
        playerTurn = whoPlaysFirst; // Reset to initial player
        ToggleButtonState(true); // Enable all buttons
        endGameState.SetActive(false); // Hide end game UI
        ResetTiles(); // Reset all tiles
    }

    /// \brief Toggles the interactable state of all tile buttons.
    /// \param state The state to set for the buttons (true to enable, false to disable).
    private void ToggleButtonState(bool state)
    {
        foreach (Text tile in tileList)
        {
            tile.GetComponentInParent<Button>().interactable = state; // Enable or disable button component
        }
    }

    /// \brief Resets all tiles to their initial state.
    private void ResetTiles()
    {
        foreach (Text tile in tileList)
        {
            tile.GetComponentInParent<TileController>().ResetTile(); // Call reset on each tile
        }
    }

    /// \brief Updates the player's name.
    /// \param playerName Reference to the player's name variable.
    /// \param newValue The new name value.
    private void OnPlayerNameChanged(ref string playerName, string newValue)
    {
        playerName = newValue; // Update player name
    }

    /// \brief Returns the current player's turn (X or O).
    /// \return The current player's turn.
    public string GetPlayersTurn()
    {
        return playerTurn;
    }

    /// \brief Returns the sprite corresponding to the current player's turn.
    /// \return The current player's sprite.
    public Sprite GetPlayerSprite()
    {
        if (playerTurn == "X")
            return tilePlayerX;
        else
            return tilePlayerO;
    }
}
