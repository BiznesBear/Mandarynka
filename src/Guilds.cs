using Newtonsoft.Json;

namespace Mandarynka;

internal class GuildSettings
{
    public ulong Id { get; set; }
    public ulong VerifyRoleId { get; set; }
    public ulong DefalutRoleId { get; set; }
    public ulong EventChannelId { get; set; }
    public ulong WelcomeChannelId { get; set; }
}
internal static class GuildSaver
{
    internal const string SETTINGS_FILEPATH = "guild_settings.json";
    internal static GuildSettings GetGuildSettings(ulong guildId)
    {
        if (File.Exists(SETTINGS_FILEPATH))
        {
            var json = File.ReadAllText(SETTINGS_FILEPATH);
            return JsonConvert.DeserializeObject<GuildSettings>(json);
        }
        else
        {
            return new GuildSettings { Id = guildId, VerifyRoleId = 0, DefalutRoleId = 0, EventChannelId = 0, WelcomeChannelId = 0 };
        }
    }

    internal static void SaveGuildSettings(ulong guildId, GuildSettings settings)
    {
        var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
        File.WriteAllText(SETTINGS_FILEPATH, json);
    }
}