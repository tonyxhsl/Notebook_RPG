using System;
using System.Collections.Generic;

// <summary>
// 한 유닛이 가진 모든 패시브와 그 출처(유닛/장비)를 관리한다.
// </summary>

public sealed class PassiveEffectController
{
    private sealed class Entry
    {
        public object source { get; }
        public PassiveEffect effect { get; }

        public Entry(object source, PassiveEffect effect)
        {
            this.source = source;
            this.effect = effect;
        }
    }

    private readonly Unit owner;
    private readonly List<Entry> entries = new();
    private readonly List<PassiveEffect> effects = new();

    public IReadOnlyList<PassiveEffect> effectsReadOnly => effects;

    public PassiveEffectController(Unit owner)
    {
        this.owner = owner;
    }


    // 하나의 패시브를 추가하는 함수. 추후에 Add()와 AddRange()를 합칠 수도 있음.
    public PassiveEffect Add(object source, PassiveEffectSO data)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (data == null)
        {
            return null;
        }

        PassiveEffect effect = data.CreateInstance();
        if (effect == null)
        {
            throw new InvalidOperationException($"{data.name} did not create a passive effect instance.");
        }

        entries.Add(new Entry(source, effect));
        effects.Add(effect);
        effect.OnAdded(owner);
        owner.RecalculateStats();
        return effect;
    }

    // 한번에 여러 패시브를 추가하는 함수. 추후에 Add()와 AddRange()를 합칠 수도 있음.
    public void AddRange(object source, IEnumerable<PassiveEffectSO> passiveData)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (passiveData == null)
        {
            return;
        }

        bool addedAny = false;
        foreach (PassiveEffectSO data in passiveData)
        {
            if (data == null)
            {
                continue;
            }

            PassiveEffect effect = data.CreateInstance();
            if (effect == null)
            {
                throw new InvalidOperationException($"{data.name} did not create a passive effect instance.");
            }

            entries.Add(new Entry(source, effect));
            effects.Add(effect);
            effect.OnAdded(owner);
            addedAny = true;
        }

        if (addedAny)
        {
            owner.RecalculateStats();
        }
    }

    // 장비 해제처럼 한 출처가 제공한 패시브를 한 번에 제거할 때 사용한다. ex) RemoveAllFrom(armor)
    public int RemoveAllFrom(object source)
    {
        int removedCount = 0;

        for (int i = entries.Count - 1; i >= 0; i--)
        {
            Entry entry = entries[i];
            if (!ReferenceEquals(entry.source, source))
            {
                continue;
            }

            entries.RemoveAt(i);
            effects.Remove(entry.effect);
            entry.effect.OnRemoved(owner);
            removedCount++;
        }

        if (removedCount > 0)
        {
            owner.RecalculateStats();
        }

        return removedCount;
    }

    public void Clear()
    {
        if (entries.Count == 0)
        {
            return;
        }

        PassiveEffect[] snapshot = effects.ToArray();
        entries.Clear();
        effects.Clear();

        foreach (PassiveEffect effect in snapshot)
        {
            effect.OnRemoved(owner);
        }

        owner.RecalculateStats();
    }

    internal IEnumerable<PermanentPassiveEffect> GetPermanentPassives()
    {
        foreach (PassiveEffect effect in effects)
        {
            if (effect is PermanentPassiveEffect permanentPassive)
            {
                yield return permanentPassive;
            }
        }
    }

    public void OnBattleStart() => InvokeTriggers(effect => effect.OnBattleStart(owner));
    public void OnBattleEnd() => InvokeTriggers(effect => effect.OnBattleEnd(owner));
    public void OnTurnStart() => InvokeTriggers(effect => effect.OnTurnStart(owner));
    public void OnTurnEnd() => InvokeTriggers(effect => effect.OnTurnEnd(owner));

    private void InvokeTriggers(Action<TriggerPassive> callback)
    {
        PassiveEffect[] snapshot = effects.ToArray();
        foreach (PassiveEffect effect in snapshot)
        {
            if (effect is TriggerPassive triggerPassive && effects.Contains(effect))
            {
                callback(triggerPassive);
            }
        }
    }
}