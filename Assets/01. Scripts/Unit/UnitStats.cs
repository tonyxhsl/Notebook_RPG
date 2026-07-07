// summary: 용병 혹은 몬스터의 스탯 클래스

using System;
using UnityEngine;

[Serializable]
public class UnitStats
{
    [Header("Health")]
    public int maxHp;

    [Header("Combat")]
    public int attack;
    public int defense;
    public int speed;

    [Header("Chance (%)")]
    [Range(0f, 100f)]
    public float critChance;

    [Range(0f, 100f)]
    public float dodgeChance;

    public UnitStats(int maxHp, int attack, int defense, int speed, float critChance, float dodgeChance)
    {
        this.maxHp = maxHp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.critChance = critChance;
        this.dodgeChance = dodgeChance;
    }

    public UnitStats Clone()
    {
        return new UnitStats(
            maxHp,
            attack,
            defense,
            speed,
            critChance,
            dodgeChance
        );
    }
}