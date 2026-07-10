//summary: 적 유닛에 대한 SO

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Unit", menuName = "Unit/Enemy Unit")]
public class EnemyUnitSO : UnitSO
{
    [Header("Appearance")]
    public Sprite sprite;
    
    [Header("Drop")]
    public int dropGold;
    public List<ItemSO> dropItems;
}