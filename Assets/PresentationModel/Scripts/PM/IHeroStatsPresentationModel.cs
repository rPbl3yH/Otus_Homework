using System;
using Lessons.Architecture.PM;

public interface IHeroStatsPresentationModel
{
    event Action<CharacterStat> OnStatAdded;
    event Action<CharacterStat> OnStatRemoved;
    CharacterStat[] GetStats();
}