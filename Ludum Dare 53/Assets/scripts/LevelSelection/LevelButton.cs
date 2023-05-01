using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Sprite _imageStarObtained;
    [SerializeField] private Image[] _stars;

    public void DisplayStars(int nbOfStars_)
    {
        for (int i = 0; i < nbOfStars_; i++)
        {
            _stars[i].sprite = _imageStarObtained;
        }
    }
}
