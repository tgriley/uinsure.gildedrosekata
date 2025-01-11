namespace GildedRose.Domain;

public interface IItemProcessor
{
    (int Quality, int SellIn) Process(string itemName, int itemSellIn, int itemQuality);
}