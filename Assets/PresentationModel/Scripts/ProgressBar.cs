using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private Image _fill;
    [SerializeField] private ProgressBarConfig _config;

    [Button]
    public void SetFill(float fillAmount) {
        _fill.fillAmount = fillAmount;

        if(fillAmount == 1) {
            _fill.sprite = _config.FillingBarSprite;
        }
        else {
            _fill.sprite = _config.DefaultBarSprite;
        }
    }

    public void SetText(string text) {
        _value.text = text;
    }
}
