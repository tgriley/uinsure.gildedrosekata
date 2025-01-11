using GildedRose.Domain.Models;

namespace GildedRose.Domain.TypeProcessors;

public class BackstagePassItemTypeProcessor : IItemTypeProcessor
{
    public void CalculateQuality(Item item)
    {
        if (item.Quality < 0 || item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }

        var modifier = 1;
        if (item.SellIn < 10) modifier++;
        if (item.SellIn < 5) modifier++;

        item.Quality = Math.Min(item.Quality + modifier, 50);
    }
}