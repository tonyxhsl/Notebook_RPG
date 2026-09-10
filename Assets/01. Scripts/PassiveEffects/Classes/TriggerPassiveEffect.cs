// <summary>
// 턴이나 전투 같은 특정 사건이 발생했을 때 동작하는 패시브
// </summary>

public abstract class TriggerPassive : PassiveEffect
{
    protected TriggerPassive(PassiveEffectSO data) : base(data) { }

    public virtual void OnBattleStart(Unit owner) { }
    public virtual void OnBattleEnd(Unit owner) { }
    public virtual void OnTurnStart(Unit owner) { }
    public virtual void OnTurnEnd(Unit owner) { }
}