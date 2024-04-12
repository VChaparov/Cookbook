

using System.Net.Http.Headers;

public class UserInterface
{
    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    public Recipe PromptNewRecipe()
    {
       var ingredients = new List<Ingredient>();
        ShowMessage("Choose Ingredients for a new recipe");
        bool finishedChoosing = false;
        var Ingredients = new List<Ingredient>();
        while (!finishedChoosing)
        {
            ShowMessage("Add Ingredient from the following by entering it's ID number:");
            foreach(var ingredient in IngredientRegister.All)
            {
                ShowMessage($"{ingredient.Id}. {ingredient.Name}");
            }

            if (int.TryParse(GetInputFromUser(), out int userInput))
            {
                var ingredient = GetIngredientFromUser(userInput);
                if (ingredient != null)
                {
                    Ingredients.Add(ingredient);
                }
            }
            else{
                finishedChoosing = true;
                ShowMessage("No Ingredient Chosen");
            }
        }
        return new Recipe(Ingredients);
    }

    public Ingredient GetIngredientFromUser(int id)
    {

        foreach (var ingredient in IngredientRegister.All)
        {
            if (id == ingredient.Id)
            {
                return ingredient;
            }
        }
        return null;
    }


    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowRecipes(List<Recipe> recipes)
    {
        int counter = 1;
        foreach(var recipe in recipes)
        {
            Console.WriteLine($"-----{counter}-----");
            Console.WriteLine(recipe);
            counter++;
        }
        Console.WriteLine("------------");
    }

    public string GetInputFromUser()
    {
        return Console.ReadLine();
    }
}