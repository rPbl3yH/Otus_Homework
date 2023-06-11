using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(CharacterStatsConfig), menuName = "Presentation model/" + nameof(CharacterStatsConfig))]
public class CharacterStatsConfig : ScriptableObject
{
    [ShowInInspector]
    public List<CharacterStatConfig> StatsConfig { get; private set; }
}

[Serializable]
public class CharacterStatConfig
{
    public string Name;
    public int Value;
}

public class CharacterStatKeys
{
    public const string Damage = "Damage";
    public const string Intelligence = "Intelligence";
    public const string MoveSpeed = "MoveSpeed";
    public const string Stamina = "Stamina";
    public const string Dexterity = "Dexterity";
    public const string Regeneration = "Regeneration";
}
