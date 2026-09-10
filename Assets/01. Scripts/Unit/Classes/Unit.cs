using UnityEngine;
using System.Collections.Generic;

// <summary>
// 전투에 참여하는 유닛(용병, 몬스터)에 사용되는 클래스
// </summary>

public abstract class Unit
{
    public string unitName { get; protected set; }
    public int level { get; protected set; }

    // 성장(레벨)까지 반영된 기본 능력치
    public UnitStats baseStats { get; protected set; }

    // 장비, 패시브, 버프까지 반영된 최종 능력치
    public UnitStats finalStats { get; protected set; }

    // 현재 체력
    public int currentHp { get; protected set; }
    public bool isAlive => currentHp > 0;

    // 상태 효과
    public StatusEffectController statusEffects { get; }
    public PassiveEffectController passiveEffects { get; }

    protected Unit()
    {
        statusEffects = new StatusEffectController(this);
        passiveEffects = new PassiveEffectController(this);
    }

    public virtual void Init(
        string unitName, 
        int level, 
        UnitStats stats, 
        IEnumerable<PassiveEffectSO> innatePassives = null)
    {
        this.unitName = unitName;
        this.level = level;

        baseStats = stats.Clone();
        finalStats = stats.Clone();

        passiveEffects.Clear();
        passiveEffects.AddRange(this, innatePassives);

        RecalculateStats();
        currentHp = finalStats.maxHp;
    }

    public void RecalculateStats()
    {
        if (baseStats == null)
        {
            return;
        }

        finalStats = new UnitStats(
            CalculateIntStat(UnitStatType.MaxHp, baseStats.maxHp, 1),
            CalculateIntStat(UnitStatType.Attack, baseStats.attack, 0),
            CalculateIntStat(UnitStatType.Defense, baseStats.defense, 0),
            CalculateIntStat(UnitStatType.Speed, baseStats.speed, 0),
            CalculateChanceStat(UnitStatType.CritChance, baseStats.critChance),
            CalculateChanceStat(UnitStatType.DodgeChance, baseStats.dodgeChance)
        );

        // 최대 체력이 감소해도 현재 체력이 새 최대치를 넘지 않게 한다.
        currentHp = Mathf.Min(currentHp, finalStats.maxHp);
    }

    private int CalculateIntStat(UnitStatType statType, int baseValue, int minimum)
    {
        float fixedAmount = 0f;
        float ratioAmount = 0f;

        foreach (PermanentPassiveEffect passive in passiveEffects.GetPermanentPassives())
        {
            fixedAmount += passive.GetFixedAdjustment(statType);
            ratioAmount += passive.GetRatioAdjustment(statType);
        }

        return Mathf.Max(minimum, Mathf.RoundToInt(baseValue + fixedAmount + baseValue * ratioAmount));
    }

    private float CalculateChanceStat(UnitStatType statType, float baseValue)
    {
        float fixedAmount = 0f;
        float ratioAmount = 0f;

        foreach (PermanentPassiveEffect passive in passiveEffects.GetPermanentPassives())
        {
            fixedAmount += passive.GetFixedAdjustment(statType);
            ratioAmount += passive.GetRatioAdjustment(statType);
        }

        // 확률과 확률의 고정 보정도 0.1 = 10% 단위를 사용한다.
        baseValue = Mathf.Clamp01(baseValue);
        return Mathf.Clamp01(baseValue + fixedAmount + baseValue * ratioAmount);
    }

    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(1, damage - finalStats.defense);
        currentHp = Mathf.Max(0, currentHp - finalDamage);
    }

    public virtual void Heal(int amount)
    {
        currentHp = Mathf.Min(finalStats.maxHp, currentHp + amount);
    }

    public virtual void OnTurnStart()
    {
        passiveEffects.OnTurnStart();
        statusEffects.OnTurnStart();
    }

    public virtual void OnTurnEnd()
    {
        passiveEffects.OnTurnEnd();
        statusEffects.OnTurnEnd();
    }

    public virtual void OnBattleStart()
    {
        passiveEffects.OnBattleStart();
    }

    public virtual void OnBattleEnd()
    {
        statusEffects.OnBattleEnd();
        passiveEffects.OnBattleEnd();
    }
}