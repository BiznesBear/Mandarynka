using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus;

namespace Mandarynka;
internal static class Tools
{
    public static string TimestampBuilder(DateTimeOffset dateTime)
    {
        var timestamp = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, TimeSpan.Zero);
        string formattedTimestamp = $"<t:{timestamp.ToUnixTimeSeconds()}:R>";
        return formattedTimestamp;
    }

    public static async Task HandleDropdown(ComponentInteractionCreateEventArgs e)
    {
        string selectedOption = e.Values.FirstOrDefault();
        DiscordInteractionResponseBuilder responseBuilder = new DiscordInteractionResponseBuilder().AsEphemeral(true);

        switch (selectedOption)
        {
            case "help_commands":
                responseBuilder.WithContent("You can also check all commands in the /commands");
                break;

            case "help_func":
                responseBuilder.WithContent("All bot functions are in /commands. Like config_eventchannel sets the event channel (bans,new members annouce)");
                break;

            case "help_admin":
                responseBuilder.WithContent("This is not admin bot. Only command that can help with administrating server is /clear");
                break;

            case "help_setuping":
                responseBuilder.WithContent("Im very helpful for creating server like guild_copyrole can help you with creating roles.\n or config_verifyrole that adds verification to your server");
                break;
            default:
                break;
        }

        await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, responseBuilder);
    }

    public static void FieldSplit(this string field,DiscordEmbedBuilder builder)
    {
        if (!string.IsNullOrEmpty(field))
        {
            var fieldStrings = field.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            builder.AddField(name, value, false);
        }
    }
}