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
    [SerializeField] private TextMeshProUGUI _moveSpeedText;
    [SerializeField] private TextMeshProUGUI _staminaText;
    [SerializeField] private TextMeshProUGUI _dexterityText;
    [SerializeField] private TextMeshProUGUI _intelligenceText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _regenerationText;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private InteractableButton _levelUpButton;
    [SerializeField] private Button _closeButton;
    
    private IPresentationModel _presentationModel;

    public void Show(IPresentationModel presentationModel) {
        gameObject.SetActive(true);
        _presentationModel = presentationModel;
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
        _nameText.text = _presentationModel.GetName();
        _levelText.text = _presentationModel.GetLevelText();
        _icon.sprite = _presentationModel.GetIcon();
        _descriptionText.text = _presentationModel.GetDescription();
        _moveSpeedText.text = _presentationModel.GetSpeed();
        _staminaText.text = _presentationModel.GetStamina();
        _dexterityText.text = _presentationModel.GetDexterity();
        _intelligenceText.text = _presentationModel.GetIntelligence();
        _damageText.text = _presentationModel.GetDamage();
        _regenerationText.text = _presentationModel.GetRegeneration();
        
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
