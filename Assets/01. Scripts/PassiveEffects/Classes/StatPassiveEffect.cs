// <summary>
// 유닛의 스탯을 조정하는 패시브
// 스탯 증가뿐 아니라 감소도 가능
// </summary>

public sealed class StatPassiveEffect : PermanentPassiveEffect
{
    private readonly StatPassiveEffectSO statData;

    public StatPassiveEffect(StatPassiveEffectSO data) : base(data)
    {
        statData = data;
    }

    public override float GetFixedAdjustment(UnitStatType statType) => statData.GetFixedAdjustment(statType);
    public override float GetRatioAdjustment(UnitStatType statType) => statData.GetRatioAdjustment(statType);
}