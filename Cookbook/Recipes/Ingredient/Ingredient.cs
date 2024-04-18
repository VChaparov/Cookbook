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

