using System.Text.Json;
using static System.Environment;

namespace Windowee.Settings;

public class Settings
{
    public static Setting? Parse()
    {
        var file = $"{GetFolderPath(SpecialFolder.UserProfile)}\\.windoweerc";
        var json = File.ReadAllText(file);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new MarginConverter());
        options.Converters.Add(new ModeConverter());

        var setting = JsonSerializer.Deserialize<Setting>(json, options);

        setting?.Windows.ForEach(window =>
        {
            if (window.Margin == null || window.Margin.IsDefault())
            {
                window.Margin = setting.Margin;
            }
        });

        return setting;
    }
}