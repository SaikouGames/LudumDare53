using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Pause)
        {
            _rb.Sleep();
            enabled = false;
        }
        else
        {
            _rb.WakeUp();
            enabled = true;
        }
    }
}
