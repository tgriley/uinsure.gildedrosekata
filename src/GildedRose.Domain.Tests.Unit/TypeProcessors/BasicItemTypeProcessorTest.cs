using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain.Tests.Unit.TypeProcessors;

public class BasicItemTypeProcessorTests
{
    private readonly BasicItemTypeProcessor _itemTypeProcessor = new();
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(10,1, 9)]
    [InlineData(10,0, 9)]
    [InlineData(10,-1, 8)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateBasicItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var item = new Item("Basic Item", ItemType.Basic, sellIn, quality);
        _itemTypeProcessor.CalculateQuality(item);
        
        //Then
        Assert.Equal(expectedQuality, item.Quality);
    }
}