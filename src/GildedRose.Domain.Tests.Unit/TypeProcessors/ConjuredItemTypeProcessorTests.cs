using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain.Tests.Unit.TypeProcessors;

public class ConjuredItemTypeProcessorTests
{
    private readonly ConjuredItemTypeProcessor _itemTypeProcessor = new();
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(10,1, 8)]
    [InlineData(10,0, 8)]
    [InlineData(10,-1, 6)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateConjuredItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var item = new Item("Conjured Item", ItemType.Conjured, sellIn, quality);
        _itemTypeProcessor.CalculateQuality(item);
        
        //Then
        Assert.Equal(expectedQuality, item.Quality);
    }
}