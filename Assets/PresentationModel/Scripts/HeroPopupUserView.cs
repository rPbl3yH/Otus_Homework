using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class HeroPopupUserView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    private IUserInfoPresentationModel _userInfoPresentationModel;

    public void Show(IUserInfoPresentationModel userInfoPresentationModel)
    {
        _userInfoPresentationModel = userInfoPresentationModel;
        _userInfoPresentationModel.OnStateChanged += OnStateChanged;
        OnStateChanged();
    }

    public void Hide()
    {
        _userInfoPresentationModel.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged()
    {
        _nameText.text = _userInfoPresentationModel.GetName();
        _icon.sprite = _userInfoPresentationModel.GetIcon();
        _descriptionText.text = _userInfoPresentationModel.GetDescription();
    }
}