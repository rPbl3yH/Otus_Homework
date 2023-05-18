using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private void Awake() {
        _counterText.gameObject.SetActive(false);
    }

    public TMP_Text GetCounterText() {
        return _counterText;
    }
}
