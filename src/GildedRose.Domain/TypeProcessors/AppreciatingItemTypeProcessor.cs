using GildedRose.Domain.Models;

namespace GildedRose.Domain.TypeProcessors;

public class AppreciatingItemTypeProcessor : IItemTypeProcessor
{
    public void CalculateQuality(Item item)
    {
        if (item.Quality < 0)
        {
            item.Quality = 0;
            return;
        }
    
        var modifier = item.SellIn < 0 ? 2 : 1;
        item.Quality = Math.Min(item.Quality + modifier, 50);
    }
}