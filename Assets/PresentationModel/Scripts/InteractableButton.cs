using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    public event Action OnClick;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    [SerializeField] private InteractableButtonConfig _config;

    private bool _interactable;

    private void OnEnable() {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() {
        _button.onClick.RemoveListener(OnButtonClick);        
    }

    [Button]
    public void SetIntractable(bool isInteractable) {
        _interactable = isInteractable;
        _image.sprite = _interactable ? _config.InteractableSprite : _config.NonInteractableSprite;
    }

    public void SetText(string text) {
        _text.text = text;
    }

    private void OnButtonClick() {
        if (_interactable) {
            OnClick?.Invoke();
        }
    }
}
