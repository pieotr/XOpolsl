using UnityEngine;
using UnityEngine.UI;

/// \class TileController
/// \brief Manages the state of an individual tile in a Tic-Tac-Toe game.
public class TileController : MonoBehaviour
{
    [Header("Component References")]
    public GameStateController gameController;    ///< Reference to the game state controller
    public Button interactiveButton;              ///< The interactive button component of this tile
    public Text internalText;                     ///< The Text component displaying the player's mark (X or O)

    /// \brief Updates the tile's state based on the current player's turn.
    /// \details Called every time the tile is clicked.
    public void UpdateTile()
    {
        // Update the tile with the current player's symbol and sprite
        internalText.text = gameController.GetPlayersTurn();
        interactiveButton.image.sprite = gameController.GetPlayerSprite();

        // Disable further interactions with this tile once it's been clicked
        interactiveButton.interactable = false;

        // Notify the game controller that a move has been made
        gameController.EndTurn();
    }

    /// \brief Resets the tile to its initial state.
    public void ResetTile()
    {
        // Clear the text and reset the sprite to the empty tile sprite
        internalText.text = "";
        interactiveButton.image.sprite = gameController.tileEmpty;
    }
}
