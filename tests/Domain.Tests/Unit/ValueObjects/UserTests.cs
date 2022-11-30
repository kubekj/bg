using Core.Entities;
using Core.Exceptions.ValueObjects.User.FirstName;
using FluentAssertions;

namespace Domain.Tests.Unit.ValueObjects;

public class UserTests
{
    [Fact]
    public void User_Should_Be_Created()
    {
        var exception = Record.Exception(() => new Trainer(new Guid(),"JacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacekJacek","Placek","test@wp.pl"));

        exception.Should().NotBeNull();
        exception.Should().BeOfType<FirstNameOutOfRangeException>();
    }
}