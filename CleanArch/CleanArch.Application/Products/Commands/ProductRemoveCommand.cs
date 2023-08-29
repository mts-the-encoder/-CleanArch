namespace CleanArch.Application.Products.Commands;

public class ProductRemoveCommand
{
    public int Id { get; set; }
    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}