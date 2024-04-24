using Cookbook.DataAccess;
using System.Runtime.CompilerServices;

public class RecipesRepository:IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;

    public RecipesRepository(IStringsRepository stringsRepository)
    {
        _stringsRepository = stringsRepository;
    }

    private List<Recipe> _recipes = new List<Recipe>();
    const char Separator = ',';
    

    public List<Recipe> GetRecipes(string filePath)
    {
        if (File.Exists(filePath))
            {
            var result = _stringsRepository.Read(filePath);
            foreach (var recipe in result)
            {
                string[] ingredientIds = recipe.Split(Separator);
                var ingredients = new List<Ingredient>();
                foreach (var ingredientID in ingredientIds)
                {
                    ingredients.Add(IngredientRegister.GetIngredientById(int.Parse(ingredientID)));
                }
                _recipes.Add(new Recipe(ingredients));
                
            }
            
        }
        if (_recipes.Count > 0)
        {
            return _recipes;
        }
        return new List<Recipe>();


    }

    public void Save(string filePath, List<Recipe> allRecipes)
    {
        List<string> recipesAsString = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var Ids = new List<int>();
            foreach(var ingredient in recipe.Ingredients)
            {
                Ids.Add(ingredient.Id);
            }
            recipesAsString.Add(string.Join(',',Ids));
        }
        _stringsRepository.Write(filePath, recipesAsString);

    }

}
