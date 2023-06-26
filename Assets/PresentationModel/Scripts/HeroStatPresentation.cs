using Lessons.Architecture.PM;
using System;

public sealed class HeroStatPresentation : IStatPresentationModel
{
    private CharacterStat _characterStat;
    public HeroStatPresentation(CharacterStat characterStat) { 
        _characterStat = characterStat;
    }

    public string GetStatText() {
        return $"{_characterStat.Name} : {_characterStat.Value}";
    }
}

public sealed class HeroStatsPresentation : IHeroStatsPresentationModel
{
    public event Action<CharacterStat> OnStatAdded;
    public event Action<CharacterStat> OnStatRemoved;

    private CharacterInfo _characterInfo;

    public HeroStatsPresentation(CharacterInfo characterInfo) {
        _characterInfo = characterInfo;

        _characterInfo.OnStatAdded += OnCharacterStatAdded;
        _characterInfo.OnStatRemoved += OnCharacterStatRemoved;
    }

    private void OnCharacterStatRemoved(CharacterStat stat) {
        OnStatRemoved?.Invoke(stat);
    }

    private void OnCharacterStatAdded(CharacterStat stat) {
        OnStatAdded?.Invoke(stat);
    }

    public CharacterStat[] GetStats() {
        return _characterInfo.GetStats();
    }
}
