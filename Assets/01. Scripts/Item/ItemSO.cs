// summary: 모든 아이템의 부모 클래스

using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;

    [TextArea(2, 5)]
    public string description;

    public Sprite icon;

    [Header("Price")]
    public int buyPrice;
    public int sellPrice;
}