using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    public enum GameState
    {
        Playing,
        Pause,
        Victory,
        Defeat
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState newState)
    {
        /* 
         * Called when the GameState changes. Will also call the event OnGameStateChanged,
         * and scripts that are listening to it (scripts with the line GameManager.OnGameStateChanged += GameManager_OnGameStateChanged; in awake)
         * will be "notified" of the changes.
         */

        State = newState;

        switch (newState)
        {
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Pause:
                HandlePause();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Defeat:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlaying()
    {

    }

    private void HandleLose()
    {
        print("Player looses");
    }

    private void HandleVictory()
    {

    }

    private void HandlePause()
    {

    }
}
