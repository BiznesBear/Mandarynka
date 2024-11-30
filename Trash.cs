using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;

namespace Mandarynka;
/// <summary>
/// Terminated functions from mandarynka bot FOREVER.
/// </summary>
public class Trash : ApplicationCommandModule
{
    [SlashRequireGuild]
    [SlashCommand("verify", "Be verified")]
    internal async Task VerifyUser(InteractionContext ctx)
    {
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);

        var verifyRole = ctx.Guild.GetRole(guildSettings.VerifyRoleId);
        if (verifyRole == null)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent("Verification is not enabled on this server"));
            return;
        }
        var hasRole = ctx.Member.Roles.Any(role => role.Id == guildSettings.VerifyRoleId);
        if (hasRole)
        {
            await ctx.CreateResponseAsync("You are already verificated", true);
            return;
        }

        await ctx.Member.GrantRoleAsync(verifyRole);
        await ctx.CreateResponseAsync("Verifyed succesful", true);
    }

    [SlashCommand("help", "Bot help center")] // please take look at this teriable thing.
    internal async Task Help(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        var helpOptions = new List<DiscordSelectComponentOption>()
        {
            new (
                "Commands",
                "help_commands",
                "If you don't know!"
                ),
            new (
                "Bot functions",
                "help_func",
                "Read how it works!"),
            new (
                "Admin",
                "help_admin",
                "Admin commands and tricks!"),
            new (
                "Bot setuping",
                "help_setuping",
                "Try fantastic server functions!"),
        };
        var helpDropdown = new DiscordSelectComponent("help_dropdown", null, helpOptions, false, 1, 1);

        await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent("How can i help you today?").AddComponents(helpDropdown));
    }

    [SlashCommand("commands", "Show's all commands")] // pls update this
    internal async Task Commands(InteractionContext ctx,
        [Choice("Common","common")]
        [Choice("Config","config")]
        [Option("helpType","idk")] string option)
    {
        var commandsEmbed = new DiscordEmbedBuilder();
        bool inline = false;
        switch (option)
        {
            case "common":
                commandsEmbed = new DiscordEmbedBuilder
                {
                    Title = "Common commands",
                    Color = DiscordColor.Gray,
                };
                commandsEmbed.AddField("</help:1216767203043442840>", "** **", inline);
                commandsEmbed.AddField("</commands:1216767203043442841>", "** **", inline);
                commandsEmbed.AddField("</ping:1216767202565296238>", "** **", inline);
                commandsEmbed.AddField("</credits:1216767203043442843>", "** **", inline);
                commandsEmbed.AddField("</verify:1216767202565296233>", "** **", inline);
                commandsEmbed.AddField("</user_info:1216767202565296236>", "** **", inline);
                commandsEmbed.AddField("</server_info:1216767202565296235>", "** **", inline);
                commandsEmbed.AddField("</role_info:1216767202565296237>", "** **", inline);
                commandsEmbed.AddField("</dotart:1216767202565296231>", "** **", inline);
                commandsEmbed.AddField("</embed:1216767202565296232>", "** **", inline);
                break;
            case "config":
                commandsEmbed = new DiscordEmbedBuilder
                {
                    Title = "Config commands",
                    Color = DiscordColor.Magenta,
                };
                commandsEmbed.AddField("</current:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</resetvalue:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</botname:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</verifyrole:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</eventchannel:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</defalutrole:0>", "** **", inline);
                commandsEmbed.AddField("</clear:1216767203043442839>", "** **", inline);
                commandsEmbed.AddField("</getstat:1216767203043442846>", "** **", inline);
                commandsEmbed.AddField("</copyrole:1216767203043442846>", "** **", inline);
                break;
            default:
                break;
        }
        await ctx.CreateResponseAsync(new DiscordInteractionResponseBuilder().AddEmbed(commandsEmbed));
    }

    [SlashCommand("halloween", "A spooky command")]
    internal async Task Halloween(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync("https://tenor.com/view/i-love-tangerines-tangerine-oranges-citrus-fruit-gif-1410742271454258105");
    }
}
