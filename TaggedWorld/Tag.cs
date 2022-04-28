namespace TaggedWorld
{
    /// <summary>
    /// Tag/oznaka/labela. Reč ili fraza preko koje se tagovani objekat pronalazi.
    /// </summary>
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;

        public override string ToString()
            => Name;
    }
}