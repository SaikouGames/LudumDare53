using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesManager : MonoBehaviour
{
    [SerializeField] private int amountOfBoxes;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            BoxLost();
        }
    }

    private void BoxLost()
    {
        /*
         * Called when a box exits the BoxManager's collider (so when the player looses it). Decreases by 1 the amount of boxes remaining.
         */

        // /!\ Potential error: you can lose boxes multiple times if you enter and exit of their collider again and again
        amountOfBoxes--;
        print("Box has been lost");
        
        if (amountOfBoxes <= 0)
        {
            // Player looses
            // Change the GameState to "Defeat"
            GameManager.Instance.UpdateGameState(GameManager.GameState.Defeat);
        }
    }
}
