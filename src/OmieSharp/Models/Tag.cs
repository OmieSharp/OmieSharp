namespace OmieSharp.Models;

public class Tag
{
    public string tag { get; set; }

    public Tag()
    {
        this.tag = "";
    }

    public Tag(string tag)
    {
        this.tag = tag;
    }
}
