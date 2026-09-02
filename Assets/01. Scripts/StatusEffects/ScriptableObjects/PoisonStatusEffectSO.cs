using UnityEngine;

// <summary>
// 독 디버프를 정의하는 ScriptableObject (미완성)
// </summary>

[CreateAssetMenu(menuName = "New Status Effect/Poison")]
public class PoisonEffectSO : StatusEffectSO
{
    public int damagePerTurn;
}
