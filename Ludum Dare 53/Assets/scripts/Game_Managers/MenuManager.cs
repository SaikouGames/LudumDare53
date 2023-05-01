using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _defeatMenu;
    [SerializeField] private GameObject _starsObtained;
    private LevelButton _starsObtainedScript;

    private bool _isPausing;

    private void Awake()
    {
        Instance = this;
        _starsObtainedScript = _starsObtained.GetComponent<LevelButton>();
    }
    public void Pause()
    {
        _isPausing = true;

        Time.timeScale = 0;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Pause);

        _pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        _isPausing = false;

        Time.timeScale = 1;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        _pauseMenu.SetActive(false);
    }

    public void ToggleVictoryMenu()
    {
        _victoryMenu.SetActive(!_victoryMenu.activeSelf);
        _starsObtainedScript.DisplayStars(GameManager.Instance.GetStarsNumber());
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
