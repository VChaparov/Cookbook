using Cookbook;

var App = new CookbookApp(new RecipesRepository(new StringsRepository()), new UserInterface());
App.Run();

public class CookbookApp
{
    private readonly RecipesRepository _recipesRepository;
    private readonly UserInterface _userInterface;

    public CookbookApp(RecipesRepository recipesRepository,
        UserInterface userInterface)
    {
        _recipesRepository = recipesRepository;
        _userInterface = userInterface;
    }

    public void Run()
    {
        string filePath = "recipes.txt";
        var allRecipes = _recipesRepository.GetRecipes(filePath);
        _userInterface.ShowRecipes(allRecipes);
        var Recipe =_userInterface.PromptNewRecipe();

        if( Recipe.GetIngredients().Count > 0 ) 
        {
            allRecipes.Add(Recipe);
            _recipesRepository.Save(filePath,allRecipes);
            _userInterface.ShowMessage("New Recipe added:");
            _userInterface.ShowMessage(Recipe.ToString());
        }
        else
        {
            _userInterface.ShowMessage("No Ingredients Selected. No recipe saved");
        }
        _userInterface.Exit();
    }
}