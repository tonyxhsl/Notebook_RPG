//summary: 아군 용병에 대한 SO

using UnityEngine;

[CreateAssetMenu(
    fileName = "New Ally Unit",
    menuName = "Unit/Ally Unit"
)]
public class AllyUnitSO : UnitSO
{
    [Header("Appearance")]
    public SpriteRandom sprites;
}