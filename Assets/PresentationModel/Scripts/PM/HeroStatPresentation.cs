using Lessons.Architecture.PM;

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