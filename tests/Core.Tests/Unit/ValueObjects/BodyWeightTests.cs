using Core.Exceptions.ValueObjects.Measurement;
using Core.ValueObjects.Measurement;
using FluentAssertions;

namespace Core.Tests.Unit.ValueObjects;

public class BodyWeightTests
{
    [Fact]
    public void BodyWeight_Should_ThrowException_When_Weight_Is_OverTheLimit()
    {
        var exception = Record.Exception(() => new BodyWeight(BodyWeight.MaxWeight + 1));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<IncorrectBodyWeightException>();
    }
    
    [Fact]
    public void BodyWeight_Should_BeCreated_When_Weight_Is_InTheLimit()
    {
        var bodyWeight = new BodyWeight(BodyWeight.MaxWeight);

        bodyWeight.Should().NotBeNull();
        bodyWeight.Value.Should().Be(BodyWeight.MaxWeight);
    }
    
    [Fact]
    public void BodyWeight_Should_BeCreated_By_ImplicitConversion()
    {
        BodyWeight bodyWeight = BodyWeight.MaxWeight;

        bodyWeight.Should().NotBeNull();
        bodyWeight.Should().BeOfType<BodyWeight>();
    }
}