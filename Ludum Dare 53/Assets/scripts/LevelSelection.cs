using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;

    private void Start()
    {
        int levelAt = SaveScript.Instance.GetGameData().maxLevel;

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            // a level's build index is its id + 2 (because there's the main menu scene and the level selection scene)
            if (i > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
