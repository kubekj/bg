using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string WebAppNamespace = "WebApp";
    
    [Fact]
    public void Domain_Should_Not_Be_Dependent_On_Any_Project()
    {
        //Arrange
        var domainAssembly = Core.AssemblyReference.Assembly;;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            WebAppNamespace
        };
        
        //Act
        var sut = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //Assert
        sut.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Application_Should_Not_Be_Dependent_On_Infra_Or_WebApp()
    {
        //Arrange
        var applicationAssembly = Application.AssemblyReference.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace, WebAppNamespace
        };
        
        //Act
        var sut = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //Assert
        sut.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Infrastructure_Should_Not_Be_Dependent_On_WebApp()
    {
        //Arrange
        var infrastructureAssembly = Infrastructure.AssemblyReference.Assembly;

        //Act
        var sut = Types
            .InAssembly(infrastructureAssembly)
            .ShouldNot()
            .HaveDependencyOn(WebAppNamespace)
            .GetResult();

        //Assert
        sut.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void WebApp_Should_Not_Be_Dependent_On_Infrastructure()
    {
        //Arrange
        var webAppAssembly = WebApp.AssemblyReference.Assembly;

        //Act
        var sut = Types
            .InAssembly(webAppAssembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        //Assert
        sut.IsSuccessful.Should().BeTrue();
    }
}