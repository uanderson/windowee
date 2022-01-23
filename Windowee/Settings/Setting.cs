using System.Text.Json.Serialization;

namespace Windowee.Settings;

public class Setting
{
    public Mode Mode { get; set; }
    public Margin Margin { get; set; }
    public List<Window> Windows { get; set; }
}