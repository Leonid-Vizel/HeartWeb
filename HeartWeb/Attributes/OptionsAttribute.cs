namespace HeartWeb.Attributes
{
    public class OptionsAttribute : Attribute
    {
        public string[] Options { get; set; }
        public OptionsAttribute(params string[] options)
        {
            Options = new string[options.Length + 1];
            Options[0] = "Неизвестно";
            options.CopyTo(Options, 1);
        }
    }
}
