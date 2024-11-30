using DSharpPlus.Entities;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System.Text;

namespace Mandarynka;


[SlashCommandGroup("config", "Config commands only for admins"), SlashCommandPermissions(Permissions.Administrator)]
public class ConfigCommands : ApplicationCommandModule
{
    #region ConfigCommands
    

    [SlashCommand("resetvalue", "Reset value")]
    [SlashRequireGuild]
    internal async Task ResetValue(InteractionContext ctx,
        [Choice("VerifyRole","verify")]
        [Choice("DefalutRole","defalutrole")]
        [Choice("BotName","botname")]
        [Choice("EventChannel","event")]
        [Choice("WelcomeChannel","welcome")]
        [Option("value","value to reset")] string value)
    {
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
        switch (value)
        {
            case "verify":
                guildSettings.VerifyRoleId = 0;
                GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
                await ctx.CreateResponseAsync("Succesful disabled verification on this server");
                break;
            case "defalutrole":
                guildSettings.DefalutRoleId = 0;
                GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
                await ctx.CreateResponseAsync("Succesful disabled defalut role on this server");
                break;

            case "botname":
                var oldNickname = botMember.Nickname;

                await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = botMember.Username);

                await ctx.CreateResponseAsync($"Reset bot nickname form {oldNickname}", true);
                break;

            case "event":
                guildSettings.EventChannelId = 0;
                GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Event channel is not enabled from now"));
                break;
            case "welcome":
                guildSettings.WelcomeChannelId = 0;
                GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Welcome channel is not enabled from now"));
                break;
            default:
                break;
        }
    }



    [SlashRequireGuild]
    [SlashCommand("botname", "Change bot name")]
    internal async Task ConfigureBotNameCommand(InteractionContext ctx, [Option("newname", "New bot name")] string newNickname)
    {
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];

        var oldNickname = botMember.Nickname;

        await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = newNickname);

        await ctx.CreateResponseAsync($"Chaned bot name '{oldNickname}' for '{newNickname}'.", true);

    }

    [SlashCommand("verifyrole", "Set the verification role")]
    [SlashRequireGuild]
    internal async Task SetVerifyRole(InteractionContext ctx, [Option("role", "The verification role")] DiscordRole role)
    {
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
        guildSettings.VerifyRoleId = role.Id;
        GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
        await ctx.CreateResponseAsync($"Verification role is now set to: {role.Mention}", true);
    }

    [SlashCommand("defalutrole", "Set the defalut role for every member")]
    [SlashRequireGuild]
    internal async Task SetDefalutRole(InteractionContext ctx, [Option("role", "The verification role")] DiscordRole role)
    {
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
        guildSettings.DefalutRoleId = role.Id;
        GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
        await ctx.CreateResponseAsync($"Defalut role is now set to: {role.Mention}", true);
    }

    [SlashRequireGuild]
    [SlashCommand("getstat", "Gets guild stat and send it(in file or discord message)")]
    internal async Task GetStat(InteractionContext ctx,
       [Choice("Users-list","users")]
        [Choice("Bans-list","bans")]
        [Choice("Channels-list","channels")]
        [Choice("Roles-list","roles")]
        [Choice("AllGuildStats","all")]
        [Option("Stat","stat")] string stat)
    {
        var followup = new DiscordFollowupMessageBuilder();
        await ctx.DeferAsync();

        var members = await ctx.Guild.GetAllMembersAsync();
        var bans = await ctx.Guild.GetBansAsync();
        var channels = await ctx.Guild.GetChannelsAsync();
        var roles = ctx.Guild.Roles;
        var content = new StringBuilder();
        switch (stat)
        {
            case "users": foreach (var member in members) content.AppendLine(member.Username); break;
            case "bans": foreach (var ban in bans) content.AppendLine(ban.User.Username); break;
            case "channels": foreach (var channel in channels) content.AppendLine(channel.Name); break;
            case "roles": foreach (var role in roles) content.AppendLine(role.Value.Name); break;
            case "all":
                content.AppendLine($"Name: {ctx.Guild.Name}");
                content.AppendLine($"Id: {ctx.Guild.Id}");
                content.AppendLine($"Created at: {ctx.Guild.CreationTimestamp.UtcDateTime}");
                content.AppendLine($"Owner: {ctx.Guild.Owner.Username}");
                content.AppendLine($"Users: {members.Count}");
                content.AppendLine($"Channels: {channels.Count}");
                content.AppendLine($"Bans: {bans.Count}");
                content.AppendLine($"Afk channel: {ctx.Guild.AfkChannel.Name}");
                content.AppendLine($"Rules channel: {ctx.Guild.RulesChannel.Name}");
                content.AppendLine($"Roles: {roles.Count}");
                content.AppendLine($"Verification level: {ctx.Guild.VerificationLevel.GetName()}");
                content.AppendLine($"Mfa level: {ctx.Guild.MfaLevel.GetName()}");
                content.AppendLine($"Boosts: {ctx.Guild.PremiumSubscriptionCount}");
                break;
            default:
                return;
        }

        string filePath = "members_list.txt";
        File.WriteAllText(filePath, content.ToString());
        var fileStream = new FileStream(filePath, FileMode.Open);
        await ctx.FollowUpAsync(followup.WithContent($"The users list of {ctx.Guild.Name}:").AddFile(fileStream));
        File.Delete(filePath);
    }



    [SlashRequireGuild]
    [SlashCommand("eventchannel", "Sets new Event channel")]
    internal async Task SetEventChannel(InteractionContext ctx,
        [Option("channel", "channel")] DiscordChannel channel)
    {
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
        guildSettings.EventChannelId = channel.Id;
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Event channel is now set to the {channel.Mention}").AsEphemeral(true));
        GuildSaver.SaveGuildSettings(guildSettings.Id, guildSettings);
    }

    [SlashRequireGuild]
    [SlashCommand("welcomechannel", "Sets new Event channel")]
    internal async Task SetWelcomeChannel(InteractionContext ctx,
    [Option("channel", "channel")] DiscordChannel channel)
    {
        var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
        guildSettings.WelcomeChannelId = channel.Id;
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Welcome channel is now set to the {channel.Mention}").AsEphemeral(true));
        GuildSaver.SaveGuildSettings(guildSettings.Id, guildSettings);
    }


    [SlashRequireGuild]
    [SlashCommand("current", "Shows current config")]
    internal async Task SeeCurrentConfig(InteractionContext ctx)
    {
        var guild = ctx.Guild;
        GuildSettings guildSettings = GuildSaver.GetGuildSettings(guild.Id);

        var configEmbed = new DiscordEmbedBuilder()
        {
            Title = "Current config",
            Description = "Here is the current config\nplease use </config_resetvalue:1178716973597732975> if need to reset/disable function",
            Color = DiscordColor.Magenta
        };

        var verifyRole = guild.GetRole(guildSettings.VerifyRoleId);
        var defalutRole = guild.GetRole(guildSettings.DefalutRoleId);
        var eventChannel = guild.GetChannel(guildSettings.EventChannelId);
        var welcomeChannel = guild.GetChannel(guildSettings.WelcomeChannelId);

        configEmbed.AddField("Server id", guildSettings.Id.ToString());
        if (verifyRole != null) configEmbed.AddField("Verify role", verifyRole.Mention.ToString());
        if (defalutRole != null) configEmbed.AddField("Verify role", defalutRole.Mention.ToString());
        if (eventChannel != null) configEmbed.AddField("Event channel", eventChannel.Mention.ToString());
        if (welcomeChannel != null) configEmbed.AddField("Welcome channel", welcomeChannel.Mention.ToString());

        await ctx.CreateResponseAsync(configEmbed.Build(), true);
    }
    #endregion
}
