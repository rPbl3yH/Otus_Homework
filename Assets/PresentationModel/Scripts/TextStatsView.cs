using TMPro;
using UnityEngine;

public sealed class TextStatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IStatPresentationModel _statsPresentation;

    public void Show(IStatPresentationModel heroStatsPresentation) {
        _statsPresentation = heroStatsPresentation;
        _text.text = _statsPresentation.GetStatText();
    }
}
