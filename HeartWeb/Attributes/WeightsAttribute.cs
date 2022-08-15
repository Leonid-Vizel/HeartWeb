namespace HeartWeb.Attributes
{
    public class WeightsAttribute : Attribute
    {
        public int[] Weights { get; set; }
        public WeightsAttribute(params int[] weights)
        {
            Weights = weights;
        }
    }
}
