using UnityEngine;

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

    public int currentHp { get; protected set; }
    public bool isAlive => currentHp > 0;

    public virtual void Init(string unitName, int level, UnitStats stats)
    {
        this.unitName = unitName;
        this.level = level;

        baseStats = stats.Clone();
        finalStats = stats.Clone();

        currentHp = finalStats.maxHp;
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

    }

    public virtual void OnTurnEnd()
    {

    }
}