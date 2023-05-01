using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;
    [SerializeField] private Text _starNumberText;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            // a level's build index is its id + 2 (because there's the main menu scene and the level selection scene)
            if (i + 2 > levelAt)
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
