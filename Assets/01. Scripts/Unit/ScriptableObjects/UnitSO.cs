using UnityEngine;
using System.Collections.Generic;

// <summary>
// 모든 유닛 SO의 상위 클래스
// </summary>

public abstract class UnitSO : ScriptableObject
{
    [Header("Stats(Int)")]
    public IntRandom maxHp;
    public IntRandom attack;
    public IntRandom defense;
    public IntRandom speed;


    [Header("Chance Stats (0.1 = 10%)")]
    public FloatRandom critChance;
    public FloatRandom dodgeChance;

    [Header("Passive Effects")]
    public List<PassiveEffectSO> passiveEffects = new();

    [Header("Appearance")]
    public SpriteRandom sprites;

    public UnitStats GenerateInitialStats()
    {
        return new UnitStats(
            maxHp.GetValue(),
            attack.GetValue(),
            defense.GetValue(),
            speed.GetValue(),
            Mathf.Clamp01(critChance.GetValue()),
            Mathf.Clamp01(dodgeChance.GetValue())
        );
    }
}