using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : SingletonBase<UIManager>
{
    [SerializeField] private TextMeshProUGUI _ammoCount;

    void Start()
    {
        
    }

    public void UpdateAmmo(int ammoCount)
    {
        _ammoCount.text = ammoCount.ToString();
    }
}
