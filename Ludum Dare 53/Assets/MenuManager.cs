using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    
    private bool _isPausing;


    public void Pause()
    {
        _isPausing = true;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Pause);

        print("Game paused");

        //_pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        _isPausing = false;

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);

        print("Game resumed");

        //_pauseMenu.SetActive(false);
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
