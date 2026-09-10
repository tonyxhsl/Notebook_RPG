// summary: 적 유닛 클래스

using System.Collections.Generic;

public class EnemyUnit : Unit
{
    public int dropGold { get; private set; }
    public List<ItemSO> dropItems { get; private set; }

    public void Init(
        string unitName,
        int level,
        int dropGold,
        UnitStats stats,
        List<ItemSO> dropItems,
        IEnumerable<PassiveEffectSO> innatePassives = null)
    {
        base.Init(unitName, level, stats, innatePassives);

        this.dropGold = dropGold;
        this.dropItems = dropItems;
    }
}