using System;
using System.Collections.Generic;
using GildedRose.Domain;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        private ItemQualityProcessor _itemQualityProcessor;
        IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
            _itemQualityProcessor = new ItemQualityProcessor();
        }

        public void ProcessItems()
        {
            foreach (var item in Items)
            {
                UpdateItemSellIn(item);
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }

        private void UpdateItemQuality(Item item)
        {
            
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = _itemQualityProcessor.UpdateBackstagePassItemQuality(item.Quality, item.SellIn);
                    return;
                case "Aged Brie":
                    item.Quality = _itemQualityProcessor.UpdateAppreciatingItemQuality(item.Quality, item.SellIn);
                    return;
                case "Sulfuras, Hand of Ragnaros":
                    item.Quality = _itemQualityProcessor.UpdateLegendaryItemQuality(item.Quality, item.SellIn);
                    return;
                default:
                    item.Quality = _itemQualityProcessor.UpdateBasicItemQuality(item.Quality, item.SellIn);
                    break;
            }
        }
    }
}