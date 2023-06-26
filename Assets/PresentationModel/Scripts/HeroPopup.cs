using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class HeroPopup : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private HeroPopupStatsAdapter _statsAdapter;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private InteractableButton _levelUpButton;
    [SerializeField] private Button _closeButton;
    
    private IPresentationModel _presentationModel;
    private IHeroStatsPresentationModel _heroStatsPresentationModel;

    public void Show(IPresentationModel presentationModel, IHeroStatsPresentationModel heroStatsPresentationModel) {
        gameObject.SetActive(true);
        _presentationModel = presentationModel;
        _heroStatsPresentationModel = heroStatsPresentationModel;
        _presentationModel.OnStateChanged += OnStateChanged;
        _closeButton.onClick.AddListener(OnCloseButtonClick);
        _levelUpButton.OnClick += OnLevelUpButtonClick;
        UpdateInfo();
    }

    private void OnStateChanged() {
        UpdateInfo();
    }

    public void Hide() { 
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        _levelUpButton.OnClick -= OnLevelUpButtonClick;
    }

    private void UpdateInfo() {
        _statsAdapter.Show(_heroStatsPresentationModel);

        _nameText.text = _presentationModel.GetName();
        _levelText.text = _presentationModel.GetLevelText();
        _icon.sprite = _presentationModel.GetIcon();
        _descriptionText.text = _presentationModel.GetDescription();

        _progressBar.SetFill(_presentationModel.GetFillAmount());
        _progressBar.SetText(_presentationModel.GetProgressBarText());

        _levelUpButton.SetText(_presentationModel.GetLevelUpText());
        _levelUpButton.SetIntractable(_presentationModel.GetButtonInteractable());
    }

    private void OnLevelUpButtonClick() {
        _presentationModel.OnLevelUpClick();
    }

    private void OnCloseButtonClick() {
        _presentationModel.OnCloseClick();
    }
}
