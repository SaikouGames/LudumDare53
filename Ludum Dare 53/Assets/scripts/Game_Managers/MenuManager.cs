using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _defeatMenu;

    private bool _isPausing;

    private void Awake()
    {
        Instance = this;
    }
    public void Pause()
    {
        _isPausing = true;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Pause);

        _pauseMenu.SetActive(true);

        print("Game paused");
    }

    public void Resume()
    {
        _isPausing = false;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        _pauseMenu.SetActive(false);

        print("Game resumed");
    }

    public void ToggleVictoryMenu()
    {
        _victoryMenu.SetActive(!_victoryMenu.activeSelf);
    }

    public void ToggleDefeatMenu()
    {
        _defeatMenu.SetActive(!_defeatMenu.activeSelf);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPausing)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

}
