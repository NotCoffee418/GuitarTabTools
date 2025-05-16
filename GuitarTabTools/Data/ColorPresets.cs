using GuitarTabTools.Model;

namespace GuitarTabTools.Data;

/// <summary>
/// Presets are highest tone to lowest tone (top to bottom on tab)
/// </summary>
public static class ColorPresets
{
    public static readonly NoteColor[] Rocksmith_Guitar_EStandard_Preset = [
        new("e", "#A349A4"),
        new("B", "#0f3"),
        new("G", "#F7941D"),
        new("D", "#00A2E8"),
        new("A", "#D4AC0D"),
        new("E", "#ED1C24"),
    ];
}
