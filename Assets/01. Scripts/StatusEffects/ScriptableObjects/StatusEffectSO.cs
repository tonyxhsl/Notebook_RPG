using UnityEngine;
using UnityEngine.Serialization;

//<summary>
// 상태 효과를 정의하는 ScriptableObject
//</summary>

public enum StatusEffectType
{
    Buff,
    Debuff
}

public abstract class StatusEffectSO : ScriptableObject
{
    public string effectName;
    public StatusEffectType effectType;

    [Tooltip("최대 스택 수 (1 이상)")]
    [Min(1)]
    public int maxStack = 1;

    public abstract StatusEffect CreateInstance(int stack, int? duration);
}
