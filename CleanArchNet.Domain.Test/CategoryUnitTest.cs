using CleanArchNet.Domain.Entities;
using FluentAssertions;


namespace CleanArchNet.Domain.Test;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchNet.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Negative Id Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<CleanArchNet.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid - input is too short");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid - input is required");
    }

    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<CleanArchNet.Domain.Validation.DomainExceptionValidation>();
    }
}
