using DSharpPlus.Entities;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.SlashCommands;
using DSharpPlus;

namespace Mandarynka;
internal class InfoCommands : ApplicationCommandModule
{
    // info commands 
    [SlashCommand("server_info", "Server info")]
    [SlashRequireGuild]
    internal async Task ServerInfoCommand(InteractionContext ctx)
    {
        var serverinfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"{ctx.Guild.Name}",
            Color = DiscordColor.Rose,
        };

        DateTimeOffset add = ctx.Guild.JoinedAt;
        var guild = ctx.Guild;
        var bans = await guild.GetBansAsync();
        serverinfoEmbed.AddField("Owner:", $"{guild.Owner.Mention}");
        serverinfoEmbed.AddField("Created date:", Tools.TimestampBuilder(add));
        serverinfoEmbed.AddField("Members count:", $"{guild.MemberCount}");
        serverinfoEmbed.AddField("Bans count:", $"{bans.Count}");
        serverinfoEmbed.AddField("Mfa level:", $"{guild.MfaLevel}");
        serverinfoEmbed.AddField("Verification level:", $"{guild.VerificationLevel}");
        serverinfoEmbed.AddField("Afk channel:", $"{guild.AfkChannel}");
        serverinfoEmbed.AddField("Rules channel:", $"{guild.RulesChannel}");
        serverinfoEmbed.AddField("Channels:", $"{guild.Channels.Count}");
        serverinfoEmbed.AddField("Roles:", $"{guild.Roles.Count}");
        serverinfoEmbed.AddField("Boosts:", $"{guild.PremiumSubscriptionCount}");
        serverinfoEmbed.AddField("Premium tier:", $"{guild.PremiumTier}");


        serverinfoEmbed.WithImageUrl($"{ctx.Guild.IconUrl}");

        var serverIconUrlBtn = new DiscordLinkButtonComponent($"{ctx.Guild.IconUrl}", "Icon");
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(serverinfoEmbed.Build()).AddComponents(serverIconUrlBtn));
    }

    [SlashCommand("user_info", "Shows info about the user")]
    internal async Task UserInfoCommand(InteractionContext ctx,
    [Option("user", "User | Exaple: @Mandarynka")] DiscordUser user)
    {
        var userinfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"Info about {user.Username}",
            Color = DiscordColor.Green,
        };

        var member = await ctx.Guild.GetMemberAsync(user.Id);
        var perms = member.Permissions.ToPermissionString();
        var permsList = perms.Split(",");

        DateTimeOffset add = user.CreationTimestamp;
        DateTimeOffset join = member.JoinedAt.DateTime;

        userinfoEmbed.AddField("User name", user.Username, false);

        userinfoEmbed.AddField("User ID", user.Id.ToString(), false);
        userinfoEmbed.AddField("Is bot ?", user.IsBot.ToString(), false);

        userinfoEmbed.AddField("Joined server at", Tools.TimestampBuilder(join), false);
        userinfoEmbed.AddField("Joined discord at", Tools.TimestampBuilder(add), false);

        if (!Array.Exists(permsList, element => element == " All permissions")) userinfoEmbed.AddField("Permissions ", perms, false);
        else userinfoEmbed.AddField("Permissions ", "All permisions", false);

        userinfoEmbed.WithThumbnail(user.AvatarUrl);

        var avatarURL = new DiscordLinkButtonComponent($"{user.AvatarUrl}", "Avatar");


        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(userinfoEmbed.Build()).AddComponents(avatarURL));
    }

    [SlashCommand("role_info", "Shows informations about the role")]
    [SlashRequireGuild]
    internal async Task RoleInfoCommand(InteractionContext ctx,
    [Option("role", "Role")] DiscordRole role)
    {
        var roleInfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"{role.Name}",
            Color = role.Color,
        };

        var perms = role.Permissions.ToPermissionString();
        var permsList = perms.Split(",");


        roleInfoEmbed.AddField("Role ID", role.Id.ToString(), false);
        roleInfoEmbed.AddField("Creation date", Tools.TimestampBuilder(role.CreationTimestamp));
        roleInfoEmbed.AddField("Hierarchy", role.Position.ToString());
        if (role.IconUrl != null) roleInfoEmbed.WithThumbnail(role.IconUrl);

        if (!Array.Exists(permsList, element => element == " All permissions")) roleInfoEmbed.AddField("Permissions ", perms, false);
        else roleInfoEmbed.AddField("Permissions ", "All permisions", false);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(roleInfoEmbed.Build()));
    }

    [SlashCommand("ping", "Show's bot ping")]
    public async Task PingCommand(InteractionContext ctx)
    {
        int ping = ctx.Client.Ping;
        await ctx.CreateResponseAsync($"Pong! Current ping is {ping} ms", true);
    }
}