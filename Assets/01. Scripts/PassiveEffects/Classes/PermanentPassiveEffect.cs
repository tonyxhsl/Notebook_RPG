// <summary>
// 출처가 유닛에 붙어 있는 동안 항상 적용되는 패시브 (상시 적용 패시브)
// 주의: 패시브가 영원히 없어지지 않는다는 뜻은 아님
// </summary>

public abstract class PermanentPassiveEffect : PassiveEffect
{
    protected PermanentPassiveEffect(PassiveEffectSO data) : base(data) { }

    public virtual float GetFixedAdjustment(UnitStatType statType) => 0f;
    public virtual float GetRatioAdjustment(UnitStatType statType) => 0f;
}
