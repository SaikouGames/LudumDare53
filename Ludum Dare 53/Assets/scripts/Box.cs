using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(0.03f,0.04f), Random.Range(0.05f, 0.4f),0.4f);
        transform.Rotate(new Vector3(0f,0f,Random.Range(0,360)));
    }

    private void OnDestroy()
    {
        // To avoid memory leaks in case the object is destroyed
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
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
