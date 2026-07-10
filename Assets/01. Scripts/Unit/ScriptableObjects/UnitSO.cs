//summary: 모든 유닛 SO의 상위 클래스

using UnityEngine;

public abstract class UnitSO : ScriptableObject
{
    [Header("Basic Info")]
    public string unitName;

    [Header("Stats(Int)")]
    public IntRandom maxHp;
    public IntRandom attack;
    public IntRandom defense;
    public IntRandom speed;


    [Header("Stats(float)")]
    public FloatRandom critChance;
    public FloatRandom dodgeChance;

    public UnitStats GenerateInitialStats()
    {
        return new UnitStats(
            maxHp.GetValue(),
            attack.GetValue(),
            defense.GetValue(),
            speed.GetValue(),
            critChance.GetValue(),
            dodgeChance.GetValue()
        );
    }
}