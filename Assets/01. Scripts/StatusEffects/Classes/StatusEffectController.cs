using System;
using System.Collections.Generic;

// <summary>
// 한 유닛에게 적용된 상태 효과와 수명 주기를 관리하는 클래스
// </summary>

public sealed class StatusEffectController
{
    private readonly Unit owner;
    private readonly List<StatusEffect> effects = new();

    public IReadOnlyList<StatusEffect> effectsReadOnly => effects;

    public StatusEffectController(Unit owner)
    {
        this.owner = owner;
    }

    public void Apply(StatusEffect effect)
    {
        if (effect == null)
        {
            return;
        }

        StatusEffect existingEffect = effects.Find(existing => existing.GetType() == effect.GetType());

        // 만약 같은 종류의 상태 효과가 이미 존재한다면, 스택을 추가하고 새로 적용하지 않음
        if (existingEffect != null)
        {
            existingEffect.AddStack(effect.stack);
            if (effect.remainingTurns.HasValue)
            {
                existingEffect.AddRemainingTurn(effect.remainingTurns.Value);
            }
            return;
        }

        effects.Add(effect);
        effect.OnApply(owner);
    }

    public bool Remove(StatusEffect effect)
    {
        if (effect == null || !effects.Contains(effect))
        {
            return false;
        }

        effects.Remove(effect);
        effect.OnRemove(owner);
        return true;
    }

    private void RemoveIfExpired(StatusEffect effect)
    {
        if (effect == null || !effects.Contains(effect))
        {
            return;
        }

        if (effect.isExpired)
        {
            Remove(effect);
        }
    }

    public void OnTurnStart()
    {
        StatusEffect[] snapshot = effects.ToArray();

        foreach (StatusEffect effect in snapshot)
        {
            if (effects.Contains(effect))
            {
                effect.OnTurnStart(owner);
            }

            if (!effects.Contains(effect))
            {
                continue;
            }

            RemoveIfExpired(effect);
        }
    }

    public void OnTurnEnd()
    {
        StatusEffect[] snapshot = effects.ToArray();

        foreach (StatusEffect effect in snapshot)
        {
            if (!effects.Contains(effect))
            {
                continue;
            }

            effect.OnTurnEnd(owner);

            if (!effects.Contains(effect))
            {
                continue;
            }

            effect.ReduceRemainingTurn();

            RemoveIfExpired(effect);
        }
    }

    public void OnBattleEnd()
    {
        StatusEffect[] snapshot = effects.ToArray();

        foreach (StatusEffect effect in snapshot)
        {
            if (!effects.Contains(effect))
            {
                continue;
            }

            effect.OnBattleEnd(owner);

            RemoveIfExpired(effect);
        }
    }

    public void Clear()
    {
        StatusEffect[] snapshot = effects.ToArray();

        foreach (StatusEffect effect in snapshot)
        {
            Remove(effect);
        }
    }
}