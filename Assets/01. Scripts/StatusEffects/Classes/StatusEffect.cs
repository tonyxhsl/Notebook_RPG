using System;

// <summary>
// 모든 상태 효과의 부모 클래스 (미완성)
// </summary>

public abstract class StatusEffect
{
    public int? remainingTurns { get; private set; }    
    public int maxStack { get; }
    public int stack { get; private set; }

    // 이 상태 효과가 제거되어야 하는지 여부    
    public bool isExpired => stack <= 0 || (remainingTurns.HasValue && remainingTurns.Value <= 0);

    protected StatusEffect(int stack, int? duration, int maxStack)
    {
        this.maxStack = maxStack;

        this.stack = Math.Min(stack, maxStack);
        remainingTurns = duration;
    }

    internal void AddRemainingTurn(int amount = 1)
    {
        if (!remainingTurns.HasValue)
        {
            return;
        }

        remainingTurns += amount;
    }

    internal void ReduceRemainingTurn(int amount = 1)
    {
        if (!remainingTurns.HasValue)
        {
            return;
        }

        remainingTurns = Math.Max(0, remainingTurns.Value - amount);
    }

    public void AddStack(int amount = 1)
    {
        stack = Math.Min(maxStack, stack + amount);
    }

    public void ReduceStack(int amount = 1)
    {
        stack = Math.Max(0, stack - amount);
    }

    // 이벤트 기반으로 상태 효과가 발동 혹은 없어지거나 스택, 지속시간이 변화할 때 사용
    public virtual void OnApply(Unit target) { }
    public virtual void OnAttack(Unit target) { }
    public virtual void OnTakeDamage(Unit target) { }
    public virtual void OnTurnStart(Unit target) { }
    public virtual void OnTurnEnd(Unit target) { }
    public virtual void OnBattleStart(Unit target) { }
    public virtual void OnBattleEnd(Unit target) { }
    public virtual void OnRemove(Unit target) { }
}