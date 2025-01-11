using GildedRose.Domain.Enums;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain;

public static class TypeProcessorFactory
{
    public static IItemTypeProcessor GetTypeProcessor(ItemType itemType)
    {
        return itemType switch
        {
            ItemType.Basic => new BasicItemTypeProcessor(),
            ItemType.Legendary => new LegendaryItemTypeProcessor(),
            ItemType.Conjured => new ConjuredItemTypeProcessor(),
            ItemType.BackstagePass => new BackstagePassItemTypeProcessor(),
            ItemType.Appreciating => new AppreciatingItemTypeProcessor(),
            _ => throw new ArgumentException($"Unsupported item type: {itemType}", nameof(itemType))
        };
    }
}