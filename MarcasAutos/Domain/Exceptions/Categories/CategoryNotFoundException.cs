namespace MarcasAutos.Domain.Exceptions.Categories;

public class CategoryNotFoundException(Guid id) : Exception($"No se encontró ninguna categoría con el ID: {id}") { }
