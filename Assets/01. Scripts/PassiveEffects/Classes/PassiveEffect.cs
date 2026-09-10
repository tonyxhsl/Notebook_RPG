// <summary>
// 모든 런타임 패시브 효과의 부모 클래스
// 공통 수명 주기만 정의하고, 실제 동작은 PermanentPassive 또는 TriggerPassive가 담당한다.
// </summary>

public abstract class PassiveEffect
{
    public PassiveEffectSO data { get; }

    protected PassiveEffect(PassiveEffectSO data)
    {
        this.data = data;
    }

    public virtual void OnAdded(Unit owner) { }
    public virtual void OnRemoved(Unit owner) { }
}