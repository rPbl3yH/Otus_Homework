using Lessons.Architecture.PM;
using System.Collections.Generic;
using UnityEngine;

public sealed class HeroPopupStatsAdapter : MonoBehaviour
{
    [SerializeField] private TextStatsView _textStatsView;
    [SerializeField] private Transform _container;

    private IHeroStatsPresentationModel _presentationModel;
    private Dictionary<CharacterStat, TextStatsView> _characterStats = new Dictionary<CharacterStat, TextStatsView>();

    public void Show(IHeroStatsPresentationModel presentationModel) {
        _presentationModel = presentationModel;
        
        var stats = _presentationModel.GetStats();
        foreach ( var characterStat in stats ) {
            AddStatView(characterStat);
        }
        
        _presentationModel.OnStatAdded += OnStatAdded;
        _presentationModel.OnStatRemoved += OnStatRemoved;
    }

    private void OnStatRemoved(CharacterStat characterStat) {
        RemoveStatView(characterStat);
    }

    private void OnStatAdded(CharacterStat characterStat) {
        AddStatView(characterStat);
    }

    private void AddStatView(CharacterStat characterStat) {
        if(_characterStats.ContainsKey(characterStat)) {
            print("Key is already existed");
            return;
        }

        var view = Instantiate(_textStatsView, _container);
        _characterStats.Add(characterStat, view);
        var pm = new HeroStatPresentation(characterStat);
        view.Show(pm);
    }

    private void RemoveStatView(CharacterStat characterStat) {
        if (_characterStats.TryGetValue(characterStat, out var view)) {
            _characterStats.Remove(characterStat);
            Destroy(view);
        }
    }
}
