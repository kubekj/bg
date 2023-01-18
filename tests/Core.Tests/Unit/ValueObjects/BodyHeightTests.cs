using Core.Exceptions.ValueObjects.Measurement;
using Core.ValueObjects.Measurement;
using FluentAssertions;

namespace Core.Tests.Unit.ValueObjects;

public class BodyHeightTests
{
    [Fact]
    public void BodyHeight_Should_ThrowException_When_Height_Is_OverTheLimit()
    {
        var exception = Record.Exception(() => new BodyHeight(BodyHeight.MaxHeight + 1));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<InvalidBodyHeightException>();
    }
    
    [Fact]
    public void BodyHeight_Should_BeCreated_When_Height_Is_InTheLimit()
    {
        var bodyHeight = new BodyHeight(BodyHeight.MaxHeight);

        bodyHeight.Should().NotBeNull();
        bodyHeight.Value.Should().Be(BodyHeight.MaxHeight);
    }
    
    [Fact]
    public void BodyHeight_Should_BeCreated_By_ImplicitConversion()
    {
        BodyHeight bodyHeight = BodyHeight.MaxHeight;

        bodyHeight.Should().NotBeNull();
        bodyHeight.Should().BeOfType<BodyHeight>();
    }
}