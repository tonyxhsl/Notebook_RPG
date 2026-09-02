using System.Collections.Generic;
using UnityEngine;

// <summary>
// 적 유닛에 대한 SO
// </summary>

[CreateAssetMenu(fileName = "New Enemy Unit", menuName = "Unit/Enemy Unit")]
public class EnemyUnitSO : UnitSO
{
    [Header("Basic Info")]
    public string unitName;
    
    [Header("Drop")]
    public int dropGold;
    public List<ItemSO> dropItems;
}