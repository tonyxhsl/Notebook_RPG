// summary: 아군 유닛(용병, 혹은 용병이 소환한 유닛) 클래스

public class AllyUnit : Unit
{
    public int exp { get; private set; }

    public void Init(
        string unitName,
        int level,
        UnitStats stats,
        int exp = 0)
    {
        base.Init(unitName, level, stats);

        this.exp = exp;
    }

    public void AddExp(int amount)
    {
        exp += amount;
    }
}