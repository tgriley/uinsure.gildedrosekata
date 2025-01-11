using GildedRose.Domain.Enums;
using GildedRose.Domain.Models;
using GildedRose.Domain.TypeProcessors;

namespace GildedRose.Domain.Tests.Unit.TypeProcessors;

public class AppreciatingItemTypeProcessorTests
{
    private readonly AppreciatingItemTypeProcessor _itemTypeProcessor = new();
    
    [Theory]
    [InlineData(-1,1, 0)]
    [InlineData(0,1, 1)]
    [InlineData(1,1, 2)]
    [InlineData(0,0, 1)]
    [InlineData(49,0, 50)]
    [InlineData(50,0, 50)]
    [InlineData(49,-1, 50)]
    public void GivenProvidedQualityAndSellIn_WhenUpdateAppreciatingItemQualityIsCalled_ThenExpectedValueIsReturned(int quality, int sellIn, int expectedQuality)
    {
        //When
        var item = new Item("Appreciating Item", ItemType.Appreciating, sellIn, quality);
        _itemTypeProcessor.CalculateQuality(item);
        
        //Then
        Assert.Equal(expectedQuality, item.Quality);
    }
}