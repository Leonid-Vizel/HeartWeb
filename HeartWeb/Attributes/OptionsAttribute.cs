namespace HeartWeb.Attributes
{
    public class OptionsAttribute : Attribute
    {
        public string[] Options { get; set; }
        public OptionsAttribute(params string[] options)
        {
            Options = options;
        }
    }
}
