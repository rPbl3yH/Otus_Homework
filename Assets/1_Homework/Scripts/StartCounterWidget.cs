using TMPro;
using UnityEngine;

public class StartCounterWidget : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private GameStartUp _gameStartUp;

    private void Awake() {
        _gameStartUp.OnCountChanged += OnCounterChanged;
        _countText.gameObject.SetActive(false);
    }

    void OnCounterChanged(int count) {
        _countText.gameObject.SetActive(count != 0);
        _countText.text = count.ToString();
    }
}
