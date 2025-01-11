using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain.Tests.Unit.TypeProcessors;

public class LegendaryItemTypeProcessorTests
{
    private readonly IItemTypeProcessor _itemTypeProcessor = new LegendaryItemTypeProcessor();
    
    [Theory]
    [InlineData(80,1, 80)]
    [InlineData(1,1, 1)]
    [InlineData(1,0, 1)]
    [InlineData(1,-1, 1)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateLegendaryItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var item = new Item("Legendary Item", ItemType.Legendary, sellIn, quality);
        var result = _itemTypeProcessor.Process(item);
        
        //Then
        Assert.Equal(expectedQuality, result.Quality);
    }
}