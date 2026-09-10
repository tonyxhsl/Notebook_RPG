using UnityEngine;

// <summary>
// 패시브의 공유 설정 데이터. 변경 가능한 런타임 상태는 저장하지 않는다.
// </summary>

public abstract class PassiveEffectSO : ScriptableObject
{
    [Header("Basic Info")]
    public string effectName;

    [TextArea(2, 5)]
    public string description;

    public abstract PassiveEffect CreateInstance();
}