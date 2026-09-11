//summary: 범위 내 무작위 정수값을 가지는 클래스

using System;

[Serializable]
public class IntRandom
{
    public int min;
    public int max;

    public int GetValue()
    {
        return UnityEngine.Random.Range(min, max + 1);
    }
}