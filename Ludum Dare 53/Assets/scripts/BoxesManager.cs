using UnityEngine;

public class BoxesManager : MonoBehaviour
{
    [SerializeField] private int defaultNumberOfBoxes;
    private int currentNumberOfBoxes;

    private void Start()
    {
        currentNumberOfBoxes = defaultNumberOfBoxes;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            BoxLost();
        }
    }

    public int GetCurrentNumberOfBoxes()
    {
        return currentNumberOfBoxes;
    }

    public int GetDefaultNumberOfBoxes()
    {
        return defaultNumberOfBoxes;
    }

    private void BoxLost()
    {
        /*
         * Called when a box exits the BoxManager's collider (so when the player looses it). Decreases by 1 the amount of boxes remaining.
         */

        // /!\ Potential error: you can lose the same boxes multiple times if you enter and exit of their collider again and again
        currentNumberOfBoxes--;
        
        if (currentNumberOfBoxes <= 0)
        {
            // Player loses
            // Change the GameState to "Defeat"
            GameManager.Instance.UpdateGameState(GameManager.GameState.Defeat);
        }

        print("Box has been lost");
    }
}
