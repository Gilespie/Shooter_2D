using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesInfo : MonoBehaviour
{
    [SerializeField] private Image _liveImage;
    [SerializeField] private TextMeshProUGUI _personInfo;

    public void UpdateLives(float currentLives, float maxLives)
    {
        _liveImage.fillAmount = currentLives/ maxLives;
    }

    public void UpdatePersonInfo(string name, int level)
    {
        _personInfo.text = $"{name} - <color=yellow>{level.ToString()} LVL</color>";
    }
}