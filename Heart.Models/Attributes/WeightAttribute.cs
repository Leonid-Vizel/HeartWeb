namespace Heart.Models.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class WeightAttribute : Attribute
{
    public int Weight { get; private set; }
    public WeightAttribute(int weight)
    {
        Weight = weight;
    }
}
