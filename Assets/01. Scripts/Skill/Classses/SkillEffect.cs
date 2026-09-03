using System;
using UnityEngine;
using System.Collections.Generic;

// <summary>
// 스킬이 대상에게 적용하는 개별 효과
// 데미지, 회복, 버프, 디버프, 이동 등을 정의
// 스킬의 최종 수치는 스킬의 기본 수치 + 스탯 계수에 따른 수치로 계산됨
// ex1) 공격 데미지 = 스킬 기본 수치 5 + 공격력 * 0.5
// ex2) 보호막량 = 스킬 기본 수치 10 + 방어력 * 0.3
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

public enum StatType
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
public class StatScaling
{
    [Tooltip("계수에 사용할 스탯")]
    public StatType statType;

    [Tooltip("스탯 계수. 1 = 해당 스탯 100%")]
    [Min(0f)]
    public float ratio;
}


[Serializable]
public class SkillEffect
{
    [Header("Effect")]
    public SkillEffectType effectType;
    public SkillEffectTarget effectTarget;

    [Header("Value")]
    [Tooltip("기본 수치")]
    public int baseAmount;

    [Tooltip("효과 수치에 반영할 스탯 계수 목록")]
    public List<StatScaling> statScalings = new();

    [Header("Status Effect")]
    [Tooltip("적용할 상태효과. StatusEffect일 때만 사용")]
    public StatusEffectSO statusEffect;

    [Header("Move")]
    [Tooltip("앞으로 이동하면 -, 뒤로 이동하면 +")]
    public int moveAmount;
}