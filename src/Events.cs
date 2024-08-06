using DSharpPlus;
using DSharpPlus.AsyncEvents;
using DSharpPlus.Entities;

namespace Mandarynka;
internal static class Events
{
    internal static void Init()
    {
        Program.DiscordClient.GuildCreated += async (s, e) =>
        {
            await e.Guild.Owner.SendMessageAsync($"Hello! If you see that message you will probaly added me to your server! If you need </help:1181276215122866318> please use that command.\nIf you don't know how to use any of commands please check the documentation");
        };

        Program.DiscordClient.GuildBanAdded += async (s, e) =>
        {
            GuildSettings guildSettings = GuildSaver.GetGuildSettings(e.Guild.Id);

            if (guildSettings.EventChannelId != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelId);
                var banAddedEmbed = new DiscordEmbedBuilder();
                banAddedEmbed.WithColor(DiscordColor.Red);
                banAddedEmbed.WithTitle("Ban");
                banAddedEmbed.WithThumbnail(e.Member.AvatarUrl);
                banAddedEmbed.AddField($"User {e.Member.Username}", $"{e.Member.Id}");
                await eventChannel.SendMessageAsync(banAddedEmbed);
            }
            try
            {
                await e.Member.SendMessageAsync($"You are banned on {e.Guild.Name}! :no_entry_sign: ");
            }
            catch (Exception)
            {
                throw;
            }
        };
        Program.DiscordClient.GuildBanRemoved += async (s, e) =>
        {
            GuildSettings guildSettings = GuildSaver.GetGuildSettings(e.Guild.Id);

            if (guildSettings.EventChannelId != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelId);
                var banAddedEmbed = new DiscordEmbedBuilder();
                banAddedEmbed.WithColor(DiscordColor.Green);
                banAddedEmbed.WithTitle("Unban");
                banAddedEmbed.WithThumbnail(e.Member.AvatarUrl);
                banAddedEmbed.AddField($"User {e.Member.Username}", $"{e.Member.Id}");
                await eventChannel.SendMessageAsync(banAddedEmbed);
            }

            try
            {
                await e.Member.SendMessageAsync($"From this moment you are not banned from {e.Guild.Name}! Yey :partying_face: ");
            }
            catch (Exception)
            {
                throw;
            }

        };
        Program.DiscordClient.GuildMemberAdded += async (s, e) =>
        {
            GuildSettings guildSettings = GuildSaver.GetGuildSettings(e.Guild.Id);
            var defalutRole = e.Guild.GetRole(guildSettings.DefalutRoleId);
            if (guildSettings.WelcomeChannelId != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.WelcomeChannelId);

                string message = $"Welcome {e.Member.Mention} to our server! We hope that you have fun! ";

                if (e.Guild.RulesChannel != null) message += $"\nPlease check the {e.Guild.RulesChannel.Mention} channel.";

                var newMemberEmbed = new DiscordEmbedBuilder()
                {
                    Title = "New member",
                    Description = message,
                    Color = DiscordColor.Blue
                };
                newMemberEmbed.WithThumbnail(e.Member.AvatarUrl);
                await eventChannel.SendMessageAsync(newMemberEmbed);
            }
            if (defalutRole != null) await e.Member.GrantRoleAsync(defalutRole);
        };
        Program.DiscordClient.MessageCreated += async (s, e) =>
        {
            DiscordMember member = await e.Guild.GetMemberAsync(e.Author.Id);
            string[] bannedWords =
            {
                "@everyone",
                "https://discord.com/invite"
            };
            foreach (string word in bannedWords) if (e.Message.Content.Contains("@everyone") && !member.Permissions.HasPermission(Permissions.Administrator)) await e.Message.DeleteAsync();
        };
        Program.DiscordClient.MessageUpdated += async (s, e) =>
        {
            GuildSettings guildSettings = GuildSaver.GetGuildSettings(e.Guild.Id);

            if (guildSettings.EventChannelId != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelId);

                string message = $"has edited message on {e.Channel.Mention}";
                var updatedMessageEmbed = new DiscordEmbedBuilder()
                {
                    Title = $"{e.Author.Username}",
                    Description = message,
                    Color = DiscordColor.Black
                };
                updatedMessageEmbed.AddField("Before", e.MessageBefore.Content);
                updatedMessageEmbed.AddField("After", e.Message.Content);
                updatedMessageEmbed.WithThumbnail(e.Author.AvatarUrl);
                await eventChannel.SendMessageAsync(updatedMessageEmbed);
            }
        };
        Program.DiscordClient.ComponentInteractionCreated += async (s, e) =>
        {
            if (e.Id == "help_dropdown")
            {
                await Tools.HandleDropdown(e);
            }

            await e.Interaction.CreateResponseAsync(
            InteractionResponseType.UpdateMessage,
            new DiscordInteractionResponseBuilder()
            .WithContent($"{e.Interaction.Data.CustomId}").AsEphemeral(true));
        };
    }
}
