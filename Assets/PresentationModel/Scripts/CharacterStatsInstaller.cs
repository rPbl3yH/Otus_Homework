using Lessons.Architecture.PM;
using System;
using UnityEngine;

public class CharacterStatsInstaller : MonoBehaviour
{
    [SerializeField] private CharacterStatsConfig _characterStatsConfig;
    private Lessons.Architecture.PM.CharacterInfo _characterInfo;

    public void Construct(Lessons.Architecture.PM.CharacterInfo characterInfo) {
        _characterInfo = characterInfo;

        foreach (var config in _characterStatsConfig.StatsConfig) {
            CharacterStat characterStat = new CharacterStat(config.Name, config.Value); 
            _characterInfo.AddStat(characterStat);
        }
    }
}
