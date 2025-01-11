using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain.Tests.Unit.TypeProcessors;

public class BackstagePassItemTypeProcessorTests
{
    private readonly BackstagePassItemTypeProcessor _itemTypeProcessor = new();
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(1,-1, 0)]
    [InlineData(1,10, 2)]
    [InlineData(1,9, 3)]
    [InlineData(1,5, 3)]
    [InlineData(1,4, 4)]
    [InlineData(1,0, 4)]
    [InlineData(50,10, 50)]
    [InlineData(49,9, 50)]
    [InlineData(48,4, 50)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateBackstagePassItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var item = new Item("Backstage Pass Item", ItemType.BackstagePass, sellIn, quality);
        _itemTypeProcessor.CalculateQuality(item);
        
        //Then
        Assert.Equal(expectedQuality, item.Quality);
    }
}