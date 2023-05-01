using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        AudioManager.Instance.Play("Click");

        SceneManager.LoadScene("LevelSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
