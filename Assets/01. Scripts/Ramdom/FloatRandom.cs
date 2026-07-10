//summary: 범위 내 무작위 실수값을 가지는 클래스

using System;

[Serializable]
public class FloatRandom
{
    public float min;
    public float max;

    public float GetValue()
    {
        return UnityEngine.Random.Range(min, max);
    }
}