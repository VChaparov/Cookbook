public class Chocolate : Ingredient
{
    public override int Id => 6;
    public override string Name => "Chocolate";

    public override string Preparation()
    {
        return $"Melt in water bath. {base.Preparation()}";
    }
}
