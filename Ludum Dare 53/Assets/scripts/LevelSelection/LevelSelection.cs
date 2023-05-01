using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlButtonsGO;
    [SerializeField] private Button[] buttonsComponent;

    private void Start()
    {
        Data gameData = SaveScript.Instance.GetGameData();

        int levelAt = gameData.maxLevel;

        for (int i = 0; i < levelAt+1; i++)
        {
            // For each level the player has completed yet, the buttons are clickable
                
            buttonsComponent[i].interactable = true;

            int nbOfStars = gameData.levelsStars[i];

            LevelButton lvlButton = lvlButtonsGO[i].GetComponent<LevelButton>();

            lvlButton.DisplayStars(nbOfStars);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
