public abstract class Flour :Ingredient
{
    public override string ToString()
    {
        return $"{Name}";
    }
    public override string Preparation()
    {
        return "Sieve. "+base.Preparation();
    }
}

