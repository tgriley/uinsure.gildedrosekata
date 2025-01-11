using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;

namespace GildedRose.Domain;

public class ItemProcessor : IItemProcessor
{
    public (int Quality, int SellIn) Process(string itemName, int itemSellIn, int itemQuality)
    {
        var item = new Item(itemName, GetItemType(itemName), itemSellIn, itemQuality);

        var itemTypeProcessor = TypeProcessorFactory.GetTypeProcessor(item.ItemType);
        var processedItem = itemTypeProcessor.Process(item);

        return (processedItem.Quality, processedItem.SellIn);
    }

    private ItemType GetItemType(string itemName)
    {
        return itemName switch
        {
            "Backstage passes to a TAFKAL80ETC concert" => ItemType.BackstagePass,
            "Aged Brie" => ItemType.Appreciating,
            "Sulfuras, Hand of Ragnaros" => ItemType.Legendary,
            "Conjured Mana Cake" => ItemType.Conjured,
            _ => ItemType.Basic
        };
    }
}