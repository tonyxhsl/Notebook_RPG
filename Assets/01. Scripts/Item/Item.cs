//summary: 모든 아이템의 상위 클래스

public abstract class Item
{
    public ItemSO data { get; protected set; }

    public Item(ItemSO data)
    {
        this.data = data;
    }
}