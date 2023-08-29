using System.Text;

public class CharacterData
{
    int Index { get; }
    string Name { get; }

    public CharacterData(int index, string name)
    {
        Index = index;
        Name = name;
    }

    public string GetFileName()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(Index);
        sb.Append("_");
        sb.Append(Name);
        sb.Append(".dat");

        return sb.ToString();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(Index.ToString().PadRight(3, ' '));
        sb.Append(" | ");
        sb.Append(Name.PadLeft(10, ' '));

        return sb.ToString();
    }
}