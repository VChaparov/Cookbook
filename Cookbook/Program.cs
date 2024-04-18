using Cookbook;

var App = new CookbookApp(new RecipesRepository(new StringsRepository()), new ConsoleUserInterface());
App.Run();

public class CookbookApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUserInterface _userInterface;

    public CookbookApp(RecipesRepository recipesRepository,
        ConsoleUserInterface userInterface)
    {
        _recipesRepository = recipesRepository;
        _userInterface = userInterface;
    }

    public void Run()
    {
        string filePath = "recipes.txt";
        var allRecipes = _recipesRepository.GetRecipes(filePath);
        if(allRecipes.Count() >0)
        {
            _userInterface.ShowRecipes(allRecipes);
        }
        else
        {
            _userInterface.ShowMessage("No recipes are saved in the file.");
            _userInterface.ShowMessage("-----------");

        }

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