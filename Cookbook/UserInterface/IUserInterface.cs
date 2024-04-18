public interface IUserInterface
{
    public void ShowMessage(string message);
    public void Exit();
    public Recipe PromptNewRecipe();
    public string GetInputFromUser();
    public void ShowRecipes(List<Recipe> recipes);
    public Ingredient GetIngredientFromUser(int id);
    public List<Ingredient> GetIngredientsFromUser();
}