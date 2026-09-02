using System.Collections.Generic;
using UnityEngine;

// <summary>
// 전투에서 사용하는 스킬의 데이터를 담은 SO
// </summary>

public enum SkillTargetType
{
    Enemy,
    Ally,
    Self
}

public enum SkillTargetRange
{
    Single,     // 대상 1명
    All,        // 조건에 맞는 대상 전체
    Adjacent,   // 선택한 대상과 인접한 대상
    Positions   // 지정된 위치의 대상 전부
}

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill/Skill")]
public class SkillSO : ScriptableObject
{
    [Header("Basic Info")]
    public string skillName;

    [TextArea(2, 5)]
    public string description;

    public Sprite icon;

    [Header("Position")]

    [Tooltip("스킬을 사용할 수 있는 시전자의 위치")]
    public List<BattlePosition> usablePositions = new();

    [Tooltip("스킬의 대상 종류")]
    public SkillTargetType targetType;

    [Tooltip("스킬의 대상 범위")]
    public SkillTargetRange targetRange;

    [Tooltip("공격하거나 지정할 수 있는 대상의 위치. Self 스킬에는 사용하지 않음")]
    public List<BattlePosition> targetablePositions = new();

    [Header("Effects")]

    [Tooltip("스킬이 발생시키는 효과 목록")]
    public List<SkillEffect> effects = new();


    public bool CanUseFrom(BattlePosition position)
    {
        return usablePositions != null &&
               usablePositions.Contains(position);
    }

    public bool CanTarget(BattlePosition position)
    {
        return targetType == SkillTargetType.Self ||
               targetablePositions != null &&
               targetablePositions.Contains(position);
    }
}