using Cookbook;
using System.Xml;

public interface IRecipesRepository
{
    public List<Recipe> GetRecipes(string filePath);
    public void Save(string filePath, List<Recipe> allRecipes);
}