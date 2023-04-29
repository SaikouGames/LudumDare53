using UnityEngine;

public class Objective : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Player wins
            GameManager.Instance.UpdateGameState(GameManager.GameState.Victory);
        }
    }
}
