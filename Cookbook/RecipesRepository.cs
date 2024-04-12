
using Cookbook;
using System.Runtime.CompilerServices;

public class RecipesRepository
{
    private readonly StringsRepository _stringsRepository;

    public RecipesRepository(StringsRepository stringsRepository)
    {
        _stringsRepository = stringsRepository;
    }

    private List<Recipe> _recipes;
    const char Separator = ',';
    public List<Ingredient> GetIngredientsFromUser()
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        return ingredients;
    }

    public List<Recipe> GetRecipes(string filePath)
    {
        if (File.Exists(filePath))
            {
            var result = File.ReadAllText(filePath).Split(Environment.NewLine);
            List<Recipe> recipes = new List<Recipe>();
            foreach (var recipe in result)
            {
                string[] ingredientIds = recipe.Split(Separator);
                List<Ingredient> ingredients = new List<Ingredient>();
                foreach (var ingredientID in ingredientIds)
                {
                    ingredients.Add(IngredientRegister.GetIngredient(int.Parse(ingredientID)));
                }
                recipes.Add(new Recipe(ingredients));
                
            }
            return recipes;
        }
        else
        {
            var recipes =new List<Recipe> { new Recipe(new List<Ingredient> { new WheatFlour(), new SpeltFlour() }) };
            Save(filePath, recipes);
            return GetRecipes(filePath);
        }
        
        
        
    }

    internal void Save(string filePath, List<Recipe> allRecipes)
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
