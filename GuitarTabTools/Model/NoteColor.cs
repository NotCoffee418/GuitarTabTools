namespace GuitarTabTools.Model;

public record NoteColor
{
    public NoteColor() { }
    public NoteColor(string noteName, string colorCode)
    {
        NoteName = noteName;
        ColorCode = colorCode;
    }
    public string NoteName { get; set; } = string.Empty;
    public string ColorCode { get; set; } = string.Empty;
}
