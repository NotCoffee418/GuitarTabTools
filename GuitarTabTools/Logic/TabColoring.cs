using GuitarTabTools.Data;
using GuitarTabTools.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace GuitarTabTools.Logic;

public static class TabColoring
{
    // Checks for | followed by - followed by | with optionally any characters in between
    public static readonly Regex IsTabStringRx = new Regex(@"\|[^|]*-[^|]*\|");


    public static string GenerateColoredTabHtml(string tab, NoteColor[] colorPreset)
    {
        int currStringIdx = 0;
        int maxStringIdx = colorPreset.Length - 1;
        int pageLines = 0;
        string[] lines = tab.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        StringBuilder sb = new StringBuilder();
        string openPrintGroup = "<div style='break-inside: avoid; page-break-inside: avoid;'>";
        string closePrintGroup = "</div>";
        sb.Append(openPrintGroup); // Open group
        foreach (string line in lines)
        {
            pageLines++;
            // Handle empty lines
            if (string.IsNullOrWhiteSpace(line))
            {
                // Handle empty lines
                sb.AppendLine("<br/>");
                currStringIdx = 0;
                continue;
            }
            // Handle non-tab line
            if (!IsTabStringRx.IsMatch(line))
            {
                // Reset the current string index if we encounter an empty line
                currStringIdx = 0;
                sb.AppendLine($"<div style='display:block'>{line}</div>");
                continue;
            }

            // Valid tab string found
            sb.Append($"<div style='display:block; color: {colorPreset[currStringIdx].ColorCode};'>{line}</div>");

            // Prepare next string.
            currStringIdx++;
            if (currStringIdx > maxStringIdx)
            {
                // Reset to initial string
                currStringIdx = 0;

                // Set up next print group
                sb.Append(closePrintGroup);
                sb.Append(openPrintGroup);
            }
        }
        sb.Append(closePrintGroup);

        return sb.ToString();
    }

}
