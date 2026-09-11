//summary: 성별에 따라 스프라이트를 무작위로 반환하는 클래스

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteRandom
{
    public List<Sprite> maleCandidates = new();
    public List<Sprite> femaleCandidates = new();

    public Sprite GetValue(Gender gender)
    {
        List<Sprite> candidates = gender == Gender.Male ? maleCandidates : femaleCandidates;

        if (candidates == null || candidates.Count == 0)
        {
            Debug.LogError($"{gender} 스프라이트 후보가 존재하지 않습니다.");
            return null;
        }

        return candidates[UnityEngine.Random.Range(0, candidates.Count)];
    }
}