using System;
using UnityEngine;

// <summary>
// 스킬이 대상에게 적용하는 개별 효과
// 데미지, 회복, 버프, 디버프, 이동 등을 정의
// </summary>

public enum SkillEffectType
{
    Damage, // 일반 피해
    Heal, // 회복
    StatusEffect, // 버프 or 디버프
    Move // 전투 대열에서 이동
}

public enum SkillEffectTarget
{
    Targets,    // SkillSO에서 결정된 대상들
    Self        // 시전자 자신
}

public enum SkillEffectStat
{
    None,
    MaxHp,
    CurrentHp,
    Attack,
    Defense,
    Speed,
    CritChance,
    DodgeChance
}

[Serializable]
public class SkillEffect
{
    [Header("Effect")]
    public SkillEffectType effectType;
    public SkillEffectTarget effectTarget;

    [Header("Value")]
    [Tooltip("고정 수치")]
    public int amount;

    [Tooltip("공격력 계수. 1 = 공격력 100%")]
    [Min(0f)]
    public float attackRatio;

    [Header("Status Effect")]
    [Tooltip("적용할 상태효과. StatusEffect일 때만 사용")]
    public StatusEffectSO statusEffect;

    [Header("Move")]
    [Tooltip("앞으로 이동하면 -, 뒤로 이동하면 +")]
    public int moveAmount;
}