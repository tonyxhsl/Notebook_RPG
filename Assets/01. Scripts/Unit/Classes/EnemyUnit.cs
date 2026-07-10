// summary: 적 유닛 클래스

using System.Collections.Generic;

public class EnemyUnit : Unit
{
    public int dropGold { get; private set; }
    public List<ItemSO> dropItems { get; private set; }

    public void Init(
        string unitName,
        UnitStats stats,
        int level,
        int dropGold,
        List<ItemSO> dropItems)
    {
        base.Init(unitName, level, stats);

        this.dropGold = dropGold;
        this.dropItems = dropItems;
    }
}