public static class IngredientRegister
{
    public static IEnumerable<Ingredient> All { get; } = 
        new List<Ingredient> 
        {
            new WheatFlour(),
            new SpeltFlour()
        }; 
    
    public static Ingredient GetIngredient(int index)
    {
        foreach(var ingredient in IngredientRegister.All)
        {
            if(ingredient.Id == index)
                return ingredient;
        }
        return null;
    }

}