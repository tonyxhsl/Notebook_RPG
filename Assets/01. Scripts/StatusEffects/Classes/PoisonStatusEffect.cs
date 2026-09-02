using UnityEngine;

// <summary>
// 독 디버프를 정의하는 클래스 (미완성)
// </summary>

public class PoisonEffect : StatusEffect
{
    private PoisonEffectSO data;

    public PoisonEffect(PoisonEffectSO data)
        : base(data.duration)
    {
        this.data = data;
    }

    public override void OnTurnEnd(Unit target)
    {
        target.TakeDamage(data.damagePerTurn);
    }
}