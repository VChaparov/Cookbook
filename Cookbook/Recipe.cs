public class Recipe
{
    public readonly List<Ingredient> Ingredients;
    private readonly string Separator = Environment.NewLine;

    public Recipe(List<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
    public List<Ingredient> GetIngredients()
    {
        return Ingredients;
    }

    public override string ToString()
    {
        List<string> recipe = new List<string>();
        foreach(var ingredient in Ingredients)
            recipe.Add(ingredient.ToString());
        return string.Join(Separator,recipe);
    }
}