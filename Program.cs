using Newtonsoft.Json;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Mandarynka
{
    class Program
    {
        private static readonly string token = "OTc5MDA0ODQ1MjkxODg0NTg0.GsJwpe.90S6qAaaygAiUeaAZnp0KHpJNmcH0GvjdgI5oA";
        internal static readonly string youtubeKey = "AIzaSyCSYhCLlyS2TnXOc99za1BTydmNKey0e0w";

        static void NewConsole() { Console.WriteLine($"||WELCOME TO MANDARYNKA CONSOLE\n||CREATED BY: (C)BIZNESBEAR 2023\n||PLEASE ENTER A COMMAND OR TYPE help FOR COMMAND LIST\n||Environment version: {Environment.Version}"); }
        static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Critical,
            });

            //slash commands register
            var slashCommands = discordClient.UseSlashCommands();
            slashCommands.RegisterCommands<BasicCommands>();
            slashCommands.RegisterCommands<ConfigCommands>();


            await discordClient.ConnectAsync();
            var interactivity = discordClient.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(1)
            });

            // events
            discordClient.GuildCreated += async (s, e) =>
            {
                await e.Guild.Owner.SendMessageAsync($"Hello! If you see that message you will probaly added me to your server! If you need </help:1181276215122866318> please use that command.\nIf you don't know how to use any of commands please check the documentation");
            };
            discordClient.GuildBanAdded += async (s, e) =>
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
            discordClient.GuildBanRemoved += async (s, e) =>
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
            discordClient.GuildMemberAdded += async (s, e) =>
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
            discordClient.MessageCreated += async (s, e) =>
            {
                DiscordMember member = await e.Guild.GetMemberAsync(e.Author.Id);
                string[] bannedWords =
                {
                "@everyone",
                "https://discord.com/invite"
            };
                foreach (string word in bannedWords) if (e.Message.Content.Contains("@everyone") && !member.Permissions.HasPermission(Permissions.Administrator)) await e.Message.DeleteAsync();
            };
            discordClient.MessageUpdated += async (s, e) =>
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
            discordClient.ComponentInteractionCreated += async (s, e) =>
            {
                if (e.Id == "help_dropdown")
                {
                    await new BasicCommands().HandleDropdown(e);
                }

                await e.Interaction.CreateResponseAsync(
                InteractionResponseType.UpdateMessage,
                new DiscordInteractionResponseBuilder()
                .WithContent($"{e.Interaction.Data.CustomId}").AsEphemeral(true));
            };




            // console things
            Console.Title = "Mandarynka Console";
            NewConsole();
            while (true)
            {
                var output = Console.ReadLine();
                if (output == null) return;
                var raw = output.ToLower().Split(" ");
                switch (raw[0])
                {
                    case "help":
                        Console.WriteLine($"Command list:\n≫ exit/close (closes the console and shut down the bot)\n≫ clear (clears console)\n≫ client [restart/disconnect/connect]");
                        break;
                    case "exit" or "close":
                        await discordClient.DisconnectAsync();
                        Environment.Exit(0);
                        break;
                    case "clear":
                        Console.Clear();
                        NewConsole();
                        break;
                    case "restart":

                        break;
                    case "client":
                        switch (raw[1])
                        {
                            case "restart":
                                Console.WriteLine("Restarting...");
                                await discordClient.DisconnectAsync();
                                Thread.Sleep(3000);
                                await discordClient.ConnectAsync();
                                Thread.Sleep(3000);
                                Console.WriteLine("Restarted");
                                break;
                            case "disconnect":
                                await discordClient.DisconnectAsync();
                                Console.WriteLine("Disconnected");
                                break;
                            case "connect":
                                await discordClient.ConnectAsync();
                                Thread.Sleep(3000);
                                Console.WriteLine("Connected");
                                break;
                            default:
                                Console.WriteLine("Nothing happends");
                                break;
                        }
                        break;

                    case "":
                        break;
                    default:
                        Console.WriteLine($"{Environment.CommandLine} - Incorrect command: {raw[0]}");
                        break;
                }
            }


        }


    }
    public class GuildSettings
    {
        public ulong Id { get; set; }
        public ulong VerifyRoleId { get; set; }
        public ulong DefalutRoleId { get; set; }
        public ulong EventChannelId { get; set; }
        public ulong WelcomeChannelId { get; set; }
    }
    public static class GuildSaver
    {
        public static string SettingsFilePath = "guild_settings.json";
        public static GuildSettings GetGuildSettings(ulong guildId)
        {
            if (File.Exists(SettingsFilePath))
            {
                var json = File.ReadAllText(SettingsFilePath);
                return JsonConvert.DeserializeObject<GuildSettings>(json);
            }
            else
            {
                return new GuildSettings { Id = guildId, VerifyRoleId = 0, DefalutRoleId = 0, EventChannelId = 0, WelcomeChannelId = 0 };
            }
        }

        public static void SaveGuildSettings(ulong guildId, GuildSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(SettingsFilePath, json);
        }
    }
}

