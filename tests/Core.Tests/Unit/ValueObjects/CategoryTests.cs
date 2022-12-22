using Core.Exceptions.Shared;
using Core.ValueObjects.Common;
using FluentAssertions;

namespace Core.Tests.Unit.ValueObjects;

public class CategoryTests
{
    [Fact]
    public void Category_Should_ThrowException_When_CategoryName_IsUnrecognized()
    {
        var exception = Record.Exception(() => new Category(string.Empty));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<IncorrectCategoryException>();
    }
    
    [Theory]
    [InlineData(Category.Cardio)]
    [InlineData(Category.Full)]
    [InlineData(Category.Upper)]
    [InlineData(Category.Lower)]
    public void Category_Should_BeCreated_When_Part_Is_InTheScope(string part)
    {
        var category = new Category(part);

        category.Should().NotBeNull();
        category.Value.Should().Be(part);
    }
    
    [Fact]
    public void Category_Should_BeCreated_By_ImplicitConversion()
    {
        Category category = Category.Cardio;

        category.Should().NotBeNull();
        category.Should().BeOfType<Category>();
    }
}