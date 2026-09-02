using UnityEngine;

// <summary>
// 아군 용병에 대한 SO
// </summary>

[CreateAssetMenu(fileName = "New Ally Unit",menuName = "Unit/Ally Unit")]
public class AllyUnitSO : UnitSO
{
    [Header("Basic Info")]
    public string unitType;
}