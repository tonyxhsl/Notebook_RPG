using UnityEngine;

// <summary>
// 모든 상태 효과의 부모 클래스 (미완성)
// </summary>

public abstract class StatusEffect
{
    public int remainingTurns;

    protected StatusEffect(int duration)
    {
        remainingTurns = duration;
    }

    public virtual void OnApply(Unit target) { }
    public virtual void OnTurnStart(Unit target) { }
    public virtual void OnTurnEnd(Unit target) { }
    public virtual void OnRemove(Unit target) { }
}