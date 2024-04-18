public static class IngredientRegister
{
    public static IEnumerable<Ingredient> All { get; } = 
        new List<Ingredient> 
        {
            new WheatFlour(),
            new SpeltFlour(),
            new Cinnamon(),
            new Cardamom(),
            new Butter(),
            new Chocolate(),
            new Sugar()
        }; 
    
    public static Ingredient GetIngredientById(int index)
    {
        foreach(var ingredient in IngredientRegister.All)
        {
            if(ingredient.Id == index)
                return ingredient;
        }
        return null;
    }

}