public abstract class Spice : Ingredient
{
    public override string ToString()
    {
        return $"{Name}";
    }
    public override string Preparation()
    {
        return "Take half a tea spoon. " + base.Preparation();
    }
}
