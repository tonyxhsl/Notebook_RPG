//Todo: 성별에 따라 주어진 후보군에서 이름을 랜덤으로 가지는 클래스
// 2개의 리스트 : 남자 후보군 & 여자 후보군
// GetValue함수 : 성별에 따른 리스트에서 무작위로 하나의 이름을 반환
// Tip: SpriteRandom 참고
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NameRandom
{
    public List<string> maleCandidates = new();
    public List<string> femaleCandidates = new();

    public string GetValue(Gender gender)
    {
        List<string> candidates = gender == Gender.Male ? maleCandidates : femaleCandidates;

        if (candidates == null || candidates.Count == 0)
        {
            Debug.LogError($"{gender} 스프라이트 후보가 존재하지 않습니다.");
            return string.Empty;
        }

        return candidates[UnityEngine.Random.Range(0, candidates.Count)];
    }
}
