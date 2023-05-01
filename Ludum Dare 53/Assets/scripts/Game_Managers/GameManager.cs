using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private BoxesManager boxesManager;

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

        boxesManager = GameObject.Find("BoxesArea").GetComponent<BoxesManager>();
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

        // If the player has already won or lost, it will not change the current GameState.
        if (State == GameState.Victory || State == GameState.Defeat)
        {
            return;
        }

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
                HandleDefeat();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlaying()
    {

    }

    private void HandleDefeat()
    {
        MenuManager.Instance.ToggleDefeatMenu();
    }

    private void HandleVictory()
    {
        int levelId = SceneManager.GetActiveScene().buildIndex - 2;
        int numberOfStars = GetNumberOfStars();

        SaveScript.Instance.Save(levelId, numberOfStars);

        MenuManager.Instance.ToggleVictoryMenu();
    }

    private void HandlePause()
    {

    }

    private int GetNumberOfStars()
    {
        int totalNumberOfBoxes = boxesManager.GetDefaultNumberOfBoxes();
        int numberOfBoxesDelivered = boxesManager.GetCurrentNumberOfBoxes();

        int partOfBoxesDelivered = totalNumberOfBoxes / numberOfBoxesDelivered;

        if(partOfBoxesDelivered == 1)
        {
            return 3;
        }
        else if (partOfBoxesDelivered > 0.5f)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}
