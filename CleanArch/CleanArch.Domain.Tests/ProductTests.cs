using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void CreateProduct_WithSuccess()
    {
        var action = () => new Product(1,"Cat", "Description", 100, 8, "image.png");

        action.Should().NotThrow<DomainExceptionValidation>();
    } 

    [Fact]
    public void CreateProduct_WithFailure()
    {
        var action = () => new Product(-1,"Cat","Description",100,8,"image.png");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateProduct_ShortName()
    {
        var action = () => new Product(1,"Aa","Description",100,8,"image.png");

        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. too short. at least 3 characters");
    }

    [Fact]
    public void CreateProduct_LongImageName()
    {
        var action = () => new Product(1,"AaA","Description",100,8,
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name. too long. max 250 characters");
    }

    [Fact]
    public void CreateProduct_EmptyImage()
    {
        var action = () => new Product(1,"AaA","Description",100,8,"");

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_EmptyImageNull()
    {
        var action = () => new Product(1,"AaA","Description",100,8,"");

        action.Should().NotThrow<NullReferenceException>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStock(int value)
    {
        var action = () => new Product(1,"AaA","Description",100, value,"img.jpeg");

        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}

