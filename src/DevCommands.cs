using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace Mandarynka;
[SlashCommandGroup("dev","command developers")]
public class DevCommands : ApplicationCommandModule
{
    [SlashRequireOwner]
    [SlashCommand("setactivity", "Nope-you cant do it")]
    internal static async Task DevSetActivity(InteractionContext ctx,

        [Choice("Playing","0")]
            [Choice("ListeningTo","2")]
            [Choice("Watching","3")]
            [Choice("Streaming","1")]
            [Choice("Competeting","5")]
            [Option("type","Select type")] string activityTypeStr,
        [Option("activity", "What are you doing today")] string activityName,
        [Option("streamurl", "url")] string url = "")
    {
        int activityTypeInt = int.Parse(activityTypeStr);
        ActivityType activityType = (ActivityType)activityTypeInt;

        DiscordActivity activity = new DiscordActivity("", ActivityType.Streaming);

        DiscordClient discord = ctx.Client;
        activity.Name = activityName;
        activity.ActivityType = activityType;
        if (url != "") activity.StreamUrl = url;

        await discord.UpdateStatusAsync(activity);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Bot now {activityType} **{activityName}** ").AsEphemeral(true));
        return;
    }

    [SlashRequireOwner]
    [SlashCommand("client", "Reset value")]
    internal async Task DevResetValue(InteractionContext ctx,
        [Choice("ResetActivity","activity")]
        [Option("value","Do something with bot")] string value)
    {
        switch (value)
        {
            case "activity":
                await ctx.Client.UpdateStatusAsync();
                await ctx.CreateResponseAsync("Reseted", true);
                break;
            default:
                await ctx.CreateResponseAsync("Something went wrong !", true);
                break;
        }
    }
}
