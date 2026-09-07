using UnityEngine;

// <summary>
// 독 디버프를 정의하는 ScriptableObject (미완성)
// 독의 데미지 로직(그냥 고정 피해, 라운드 마다 증가, 계수 등등)을 정해야함.
// </summary>

[CreateAssetMenu(menuName = "New Status Effect/Poison")]
public class PoisonStatusEffectSO : StatusEffectSO
{
    public int damagePerTurn;

    public override StatusEffect CreateInstance(int stack, int? duration)
    {
        return new PoisonStatusEffect(this, stack, duration);
    }
}
