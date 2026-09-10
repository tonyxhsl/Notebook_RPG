using System.Collections.Generic;

// <summary>
// 아군 유닛(용병, 혹은 용병이 소환한 유닛) 클래스
// </summary>



public class AllyUnit : Unit
{
    public int exp { get; private set; }

    public void Init(
        string unitName,
        int level,
        UnitStats stats,
        int exp = 0,
        IEnumerable<PassiveEffectSO> innatePassives = null)
    {
        base.Init(unitName, level, stats, innatePassives);

        this.exp = exp;
    }

    public void AddExp(int amount)
    {
        exp += amount;
    }
}