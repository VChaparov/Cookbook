public abstract class Ingredient
{
    public abstract string Name { get; }
    public abstract int Id { get; }

    public override string ToString()
    {
        return Name;
    }
    public virtual string Preparation()
    {
        return "Add to other ingridients";
    }
}

public abstract class Flour :Ingredient
{
    public override string ToString()
    {
        return $"{Name}. {Preparation()}";
    }
    public override string Preparation()
    {
        return "Sieve. "+base.Preparation();
    }
}

public  class WheatFlour : Flour
{
    public override int Id => 1;
    public override string Name => "Wheat Flour";


}public  class SpeltFlour : Flour
{
    public override int Id => 2;
    public override string Name => "Spelt Flour";


}

