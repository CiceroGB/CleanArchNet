using CleanArchNet.Domain.Entities;
using FluentAssertions;


namespace CleanArchNet.Domain.Test;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchNet.Domain.Validation.DomainExceptionValidation>();
    }
}