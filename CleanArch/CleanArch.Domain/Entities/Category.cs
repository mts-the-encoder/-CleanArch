using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;
public sealed class Category : BaseEntity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public void Update(string name)
    {
        ValidateDomain(name);
    }
    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation
            .When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

        DomainExceptionValidation
            .When(name.Length < 3,
                "Invalid name. too short. at least 3 characters");

        Name = name;
    }
}
