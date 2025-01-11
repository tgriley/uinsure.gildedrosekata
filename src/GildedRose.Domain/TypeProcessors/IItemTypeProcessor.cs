using GildedRose.Domain.Models;

namespace GildedRose.Domain.TypeProcessors;

public interface IItemTypeProcessor
{
    Item Process(Item item)
    {
        CalculateSellIn(item);
        CalculateQuality(item);

        return item;
    }

    void CalculateSellIn(Item item)
    {
        item.SellIn--;
    }

    void CalculateQuality(Item item);
}