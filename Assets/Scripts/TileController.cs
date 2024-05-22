using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    [Header("Component References")]
    public GameStateController gameController;    // Reference to the game state controller
    public Button interactiveButton;               // The interactive button component of this tile
    public Text internalText;                      // The Text component displaying the player's mark (X or O)



    public void UpdateTile()    // Called every time the tile is clicked. Updates the tile's state based on the current player's turn.
    {
        // Update the tile with the current player's symbol and sprite
        internalText.text = gameController.GetPlayersTurn();
        interactiveButton.image.sprite = gameController.GetPlayerSprite();

        // Disable further interactions with this tile once it's been clicked
        interactiveButton.interactable = false;

        // Notify the game controller that a move has been made
        gameController.EndTurn();
    }


    public void ResetTile()    // Resets the tile to its initial state.
    {
        // Clear the text and reset the sprite to the empty tile sprite
        internalText.text = "";
        interactiveButton.image.sprite = gameController.tileEmpty;
    }
}