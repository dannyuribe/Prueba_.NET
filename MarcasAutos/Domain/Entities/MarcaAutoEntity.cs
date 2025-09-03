namespace MarcasAutos.Domain.Entities;

public class MarcaAutoEntity : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    protected MarcaAutoEntity() { }

    public MarcaAutoEntity(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la marca no puede estar vacío.", nameof(name));

        Name = name;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre de la marca no puede estar vacío.", nameof(name));

        Name = name;
        MarkAsUpdated();
    }
}
