using CleanArchNet.Domain.Validation;

namespace CleanArchNet.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidateDomain(name);

    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name);

    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    public ICollection<Product> Products { get; set; }


    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid - input is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid - input is too short");

        Name = name;
    }


}