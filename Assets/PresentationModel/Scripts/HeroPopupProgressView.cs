using TMPro;
using UnityEngine;

public sealed class HeroPopupProgressView : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private TextMeshProUGUI _levelText;
    
    private IProgressPresentationModel _progressPresentationModel;
    
    public void Show(IProgressPresentationModel presentationModel)
    {
        _progressPresentationModel = presentationModel;
        _progressPresentationModel.OnLevelUp += OnLevelUp;
        _progressPresentationModel.OnExperienceChanged += OnExperienceChanged;
        OnExperienceChanged();
        OnLevelUp();
    }

    private void OnExperienceChanged()
    {
        _progressBar.SetFill(_progressPresentationModel.GetFillAmount());
        _progressBar.SetText(_progressPresentationModel.GetProgressBarText());
    }

    private void OnLevelUp()
    {
        _levelText.text = _progressPresentationModel.GetLevelText();
    }
}