using System.Collections.Generic;
using GildedRose.Domain;

namespace GildedRose
{
    public class GildedRose(IList<GildedRoseKata.Item> items, IItemProcessor itemProcessor)
    {
        public void ProcessItems()
        {
            foreach (var item in items)
            {
                var processedItem = itemProcessor.Process(item.Name, item.SellIn, item.Quality);
                
                item.Quality = processedItem.Quality;
                item.SellIn = processedItem.SellIn;
            }
        }
    }
}