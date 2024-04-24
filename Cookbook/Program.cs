using Cookbook;
using Cookbook.DataAccess;
const FileFormat fileFormat = FileFormat.Json;
IStringsRepository stringsRepository;
if (fileFormat == FileFormat.Json)
{
    stringsRepository = new JsonRepository();
}
else if (fileFormat == FileFormat.Txt)
    {
        stringsRepository = new TextRepository();
    }
string filePath = $"recipes{fileFormat}";

var App = new CookbookApp(new RecipesRepository(stringsRepository), new ConsoleUserInterface());

App.Run(filePath);
public class CookbookApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IUserInterface _userInterface;

    public CookbookApp(
        RecipesRepository recipesRepository,
        ConsoleUserInterface userInterface)
        
    {
        _recipesRepository = recipesRepository;
        _userInterface = userInterface;
    }

    public void Run(string filePath)
    {
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