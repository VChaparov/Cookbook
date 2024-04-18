public class Butter : Ingredient
{
    public override int Id => 5;
    public override string Name => "Butter";

    public override string Preparation()
    {
        return $"Melt on low heat. {base.Preparation()}";
    }
}
