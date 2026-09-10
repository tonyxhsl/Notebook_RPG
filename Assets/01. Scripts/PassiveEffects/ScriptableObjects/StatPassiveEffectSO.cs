using System;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// 스탯을 조정하는 패시브 효과의 공유 설정 데이터
// </summary>

[CreateAssetMenu(fileName = "New Stat Passive", menuName = "New Passive Effect/Stat Modifier")]
public sealed class StatPassiveEffectSO : PassiveEffectSO
{
    [Serializable]
    public class StatAdjustment
    {
        public UnitStatType statType;

        [Header("Fixed Amount")]
        public float fixedAmount;

        [Header("Base Stat Ratio (0.1 = 10%)")]
        public float ratioAmount;
    }

    public List<StatAdjustment> statAdjustments = new();

    public override PassiveEffect CreateInstance()
    {
        return new StatPassiveEffect(this);
    }

    public float GetFixedAdjustment(UnitStatType statType)
    {
        float total = 0f;

        foreach (StatAdjustment adjustment in statAdjustments)
        {
            if (adjustment != null && adjustment.statType == statType)
            {

                total += adjustment.fixedAmount;
            }
        }

        return total;
    }

    public float GetRatioAdjustment(UnitStatType statType)
    {
        float total = 0f;

        foreach (StatAdjustment adjustment in statAdjustments)
        {
            if (adjustment != null && adjustment.statType == statType)
            {
                total += adjustment.ratioAmount;
            }
        }

        return total;
    }
}