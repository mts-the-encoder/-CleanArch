using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class CategoryTest
{
    [Fact]
    public void CreateCategory_WithSuccess()
    {
        var action = () => new Category(1, "Cat");

        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_WithFailure()
    {
        var action = () => new Category(-1,"Cat");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateCategory_ShortName()
    {
        var action = () => new Category(1,"Aa");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. too short. at least 3 characters");
    }

    [Fact]
    public void CreateCategory_BlankName()
    {
        var action = () => new Category(1,"");

        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create category with name null")]
    public void CreateCategory_NullName()
    {
        var action = () => new Category(1,"");

        action.Should()
            .Throw<DomainExceptionValidation>();
    }
}