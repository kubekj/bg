using Core.Exceptions.Shared;
using Core.ValueObjects.Common;
using FluentAssertions;

namespace Core.Tests.Unit.ValueObjects;

public class BodyPartTests
{
    [Fact]
    public void BodyPart_Should_ThrowException_When_Part_IsUnrecognized()
    {
        var exception = Record.Exception(() => new BodyPart("Head"));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<IncorrectBodyPartException>();
    }
    
    [Theory]
    [InlineData(BodyPart.Core)]
    [InlineData(BodyPart.Shoulders)]
    [InlineData(BodyPart.Chest)]
    public void BodyPart_Should_BeCreated_When_Part_Is_InTheScope(string part)
    {
        var bodyPart = new BodyPart(part);

        bodyPart.Should().NotBeNull();
        bodyPart.Value.Should().Be(part);
    }
    
    [Fact]
    public void BodyPart_Should_BeCreated_By_ImplicitConversion()
    {
        BodyPart bodyPart = BodyPart.Core;

        bodyPart.Should().NotBeNull();
        bodyPart.Should().BeOfType<BodyPart>();
    }
}