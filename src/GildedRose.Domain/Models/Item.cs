using GildedRose.Domain.Enums;

namespace GildedRose.Domain.Models;

public class Item(string name, ItemType itemType, int sellIn, int quality)
{
    public string Name { get; set; } = name;
    public ItemType ItemType { get; set; } = itemType;
    public int SellIn { get; set; } = sellIn;
    public int Quality { get; set; } = quality;
}