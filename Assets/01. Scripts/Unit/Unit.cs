// summary: 전투에 참여하는 유닛(용병, 몬스터)에 사용되는 클래스

using UnityEngine;

public abstract class Unit
{
    public string unitName { get; protected set; }
    public int level { get; protected set; }
    public UnitStats stats { get; protected set; }

    public int currentHp { get; protected set; }
    public bool isAlive => currentHp > 0;

    public virtual void Init(string unitName, int level, UnitStats stats)
    {
        this.unitName = unitName;
        this.level = level;
        this.stats = stats;
        currentHp = stats.maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(1, damage - stats.defense);
        currentHp = Mathf.Max(0, currentHp - finalDamage);
    }

    public virtual void Heal(int amount)
    {
        currentHp = Mathf.Min(stats.maxHp, currentHp + amount);
    }

    public virtual void OnTurnStart()
    {

    }

    public virtual void OnTurnEnd()
    {

    }
}