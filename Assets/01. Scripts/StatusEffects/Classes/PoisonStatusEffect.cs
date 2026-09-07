using System;

// <summary>
// 독 디버프를 정의하는 클래스 (미완성)
// 독의 데미지 로직(그냥 고정 피해, 라운드 마다 증가, 계수 등등)을 정해야함.
// </summary>

public class PoisonStatusEffect : StatusEffect
{
    private readonly PoisonStatusEffectSO data;

    public PoisonStatusEffect(PoisonStatusEffectSO data, int stack, int? duration)
        : base(stack, duration, data.maxStack)
    {
        this.data = data;
    }

    public override void OnTurnEnd(Unit target)
    {
        target.TakeDamage(data.damagePerTurn);
        ReduceStack(1);
    }
}