namespace HeartWeb.Attributes
{
    public class WeightsAttribute : Attribute
    {
        public int[] Weights { get; set; }
        public WeightsAttribute(params int[] weights)
        {
            Weights = new int[weights.Length + 1];
            Weights[0] = -1000;
            weights.CopyTo(Weights,1);
        }
    }
}
