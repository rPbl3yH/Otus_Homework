using TMPro;
using UnityEngine;

public sealed class HeroPopupProgressView : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private InteractableButton _levelButton;
    
    private IProgressPresentationModel _progressPresentationModel;

    public void Show(IProgressPresentationModel presentationModel)
    {
        _progressPresentationModel = presentationModel;
        _progressPresentationModel.OnStateChanged += OnStateChanged;
        _levelButton.OnClick += OnLevelButtonClick;
        OnStateChanged();
    }

    private void OnLevelButtonClick()
    {
        _progressPresentationModel.OnLevelUpClick();
    }

    private void OnStateChanged()
    {
        _levelText.text = _progressPresentationModel.GetLevelText();
        _progressBar.SetFill(_progressPresentationModel.GetFillAmount());
        _progressBar.SetText(_progressPresentationModel.GetProgressBarText());
        _levelButton.SetIntractable(_progressPresentationModel.GetButtonInteractable());
    }
}