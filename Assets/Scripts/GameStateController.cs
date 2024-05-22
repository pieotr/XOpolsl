using UnityEngine;
using UnityEngine.UI;


public class GameStateController : MonoBehaviour
{
    [Header("TitleBar References")]
    public Image playerXIcon;             // Icon for player X
    public Image playerOIcon;             // Icon for player O
    public InputField player1InputField;  // Input field for player 1's name
    public InputField player2InputField;  // Input field for player 2's name
    public Text winnerText;               // Text UI to display the winner

    [Header("Misc References")]
    public GameObject endGameState;       // Container for end game state UI

    [Header("Asset References")]
    public Sprite tilePlayerO;            // Sprite for O tile
    public Sprite tilePlayerX;            // Sprite for X tile
    public Sprite tileEmpty;              // Sprite for an empty tile
    public Text[] tileList;               // Array of all tiles as Text UI

    [Header("GameState Settings")]
    public Color inactivePlayerColor;     // Color for inactive player icon
    public Color activePlayerColor;       // Color for active player icon
    public string whoPlaysFirst;          // Indicates who plays first, 'X' or 'O'

    [Header("Private Variables")]
    private string playerTurn;            // Current player's turn
    private string player1Name;           // Display name for player 1
    private string player2Name;           // Display name for player 2
    private int moveCount;                // Count of moves made

    private void Start()
    {
        playerTurn = whoPlaysFirst;       // Initialize who plays first

        //UpdatePlayerIcons();              // Update player icons based on who plays first
        if (playerTurn == "X") playerOIcon.color = inactivePlayerColor;
        else playerXIcon.color = inactivePlayerColor;


        // Add listeners for name changes
        player1InputField.onValueChanged.AddListener(delegate { OnPlayerNameChanged(ref player1Name, player1InputField.text); });
        player2InputField.onValueChanged.AddListener(delegate { OnPlayerNameChanged(ref player2Name, player2InputField.text); });

        // Set player names from input fields
        player1Name = player1InputField.text;
        player2Name = player2InputField.text;
    }

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

    private bool CheckLineSingle(int index)
    {
        return tileList[index].text == playerTurn;
    }

    private bool CheckLine(int a, int b, int c)
    {
        // Returns true if all tiles in a line are owned by the current player
        return tileList[a].text == playerTurn && tileList[b].text == playerTurn && tileList[c].text == playerTurn;
    }

    private void ChangeTurn()
    {
        //playerTurn = playerTurn == "X" ? "O" : "X"; // Toggle player turn


        if (playerTurn == "X")
        {
            playerTurn = "O";
        }
        else
        {
            playerTurn = "X";
        }
        UpdatePlayerIcons(); // Update UI icons to reflect the change






    }

    private void GameOver(string winningPlayer)
    {
        // Set the winner text based on the game outcome
        // POPRAWIĆ CZYTELNOŚĆ
        winnerText.text = winningPlayer == "D" ? "DRAW" : (winningPlayer == "X" ? player1Name : player2Name);
        endGameState.SetActive(true); // Show end game UI
        ToggleButtonState(false); // Disable all buttons
    }

    public void RestartGame()
    {
        moveCount = 0;  // Reset move count
        playerTurn = whoPlaysFirst; // Reset to initial player
        ToggleButtonState(true); // Enable all buttons
        endGameState.SetActive(false); // Hide end game UI
        ResetTiles(); // Reset all tiles
    }

    private void ToggleButtonState(bool state)
    {
        foreach (Text tile in tileList)
        {
            tile.GetComponentInParent<Button>().interactable = state; // Enable or disable button component
        }
    }

    private void ResetTiles()
    {
        foreach (Text tile in tileList)
        {
            tile.GetComponentInParent<TileController>().ResetTile(); // Call reset on each tile
        }
    }

    private void OnPlayerNameChanged(ref string playerName, string newValue)
    {
        playerName = newValue; // Update player name
    }





    public string GetPlayersTurn()    // Returns the current player's turn (X or O).
    {
        return playerTurn;
    }



    public Sprite GetPlayerSprite()    // Returns the sprite corresponding to the current player's turn.
    {
        if (playerTurn == "X")
            return tilePlayerX;
        else
            return tilePlayerO;
    }



}