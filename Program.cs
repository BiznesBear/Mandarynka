using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using Google.Apis.YouTube.v3;



class Program
{

    // lista rzeczy do zrobienia:
    // stats channels - bany,ilość użytkowników, ilość członków online {Po częsci ukończone, bo się nieaktualizuje, i tworzy nowy kanał zamiast ustawiać inny}
    // dotart nie powinnien wysyłać bot tylko użytkownik (wiadomość)


    // future roadmap:
    // add intergration with DotBread
    // add website with panel and dc account connecting
    // add youtube api (sending videos and seraching)
    // add more fun commands like /bake /cake /lvl /gift
    // meybe givaways ?
    // meybe radio on vc ?

    static async Task Main(string[] args)
    {
        var discordClient = new DiscordClient(new DiscordConfiguration
        {
            Token = "OTc5MDA0ODQ1MjkxODg0NTg0.GsJwpe.90S6qAaaygAiUeaAZnp0KHpJNmcH0GvjdgI5oA",
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Error, 
        });

        var slashCommands = discordClient.UseSlashCommands();
        slashCommands.RegisterCommands<SlashCommandsModule>();
        await discordClient.ConnectAsync();
        var interactivity = discordClient.UseInteractivity(new InteractivityConfiguration
        {
            Timeout = TimeSpan.FromMinutes(1)
        });


        SlashCommandsModule module = new SlashCommandsModule();
        discordClient.GuildCreated += async (s, e) =>
        {
            await e.Guild.Owner.SendMessageAsync($"Hello! If you see that message you will probaly added me to your server! If you need </help:1181276215122866318> please use that command.\nIf you don't know how to use any of commands please check the documentation");
        };
        discordClient.GuildBanAdded += async (s, e) =>
        {
            GuildSettings guildSettings = module.GetGuildSettings(e.Guild.Id);
            
            if (guildSettings.EventChannelID != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelID);
                var banAddedEmbed = new DiscordEmbedBuilder();
                banAddedEmbed.WithColor(DiscordColor.Red);
                banAddedEmbed.WithTitle("Ban");
                banAddedEmbed.WithThumbnail(e.Member.AvatarUrl);
                banAddedEmbed.AddField($"User {e.Member.Username}",$"{e.Member.Id}");
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
        discordClient.GuildBanRemoved+= async (s, e) =>
        {
            GuildSettings guildSettings = module.GetGuildSettings(e.Guild.Id);

            if (guildSettings.EventChannelID != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelID);
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
            GuildSettings guildSettings = module.GetGuildSettings(e.Guild.Id);

            if (guildSettings.EventChannelID != 0)
            {
                var eventChannel = e.Guild.GetChannel(guildSettings.EventChannelID);
                string message = $"Welcome {e.Member.Mention} to our server! We hope that you have fun! ";
                if (e.Guild.RulesChannel != null) message += $"\nPlease check the {e.Guild.RulesChannel} channel.";
                await eventChannel.SendMessageAsync(message);
            }
        };
        discordClient.ComponentInteractionCreated += async (s, e) =>
        {
            if (e.Id == "help_dropdown")
            {
                await new SlashCommandsModule().HandleDropdown(e);
            }

            await e.Interaction.CreateResponseAsync(
            InteractionResponseType.UpdateMessage,
            new DiscordInteractionResponseBuilder()
            .WithContent($"{e.Interaction.Data.CustomId}").AsEphemeral(true));
        };

        Console.Title = "Mandarynka Console";
        NewConsole();
        while(true)
        {
            var output = Console.ReadLine();
            if (output == null) return;
            var raw = output.ToLower().Split(" ");
            
            
            switch (raw[0])
            {
                case "help":
                    Console.WriteLine($"Command list:\n≫ exit/close (closes the console and shut down the bot)\n≫ clear (clears console)\n≫ client [restart/disconnect/connect]");
                    break;
                case "exit"or"close":
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
    static void NewConsole()
    {
        Console.WriteLine($"||WELCOME TO MANDARYNKA CONSOLE\n||CREATED BY: (C)BIZNESBEAR 2023\n||PLEASE ENTER A COMMAND OR TYPE help FOR COMMAND LIST\n||Environment version: {Environment.Version}");
    } 
}

//JSON DATA 
//JSON DATA 
//JSON DATA 

public class GuildSettings
{
    public ulong Id { get; set; }
    public ulong VerifyRoleId { get; set; }
    public ulong EventChannelID { get; set; }
    public required string Code { get; set; }
    public required string CodeContent { get; set; }
}

public class SlashCommandsModule : ApplicationCommandModule
{
    //special 
    //special 
    //special 

    [SlashCommand("dotart", "Sends dot art")]
    public async Task DotArtCommand(InteractionContext ctx,
        [Choice("Hello","0")]
        [Choice("Wot-doing","1")]
        [Choice("Siuuu","2")]
        [Choice("Nope","3")]
        [Choice("Gigachad","4")]
        [Choice("Wut","5")]
        [Choice("Trollface","6")]
        [Choice("Sus","7")]
        [Choice("Catgun","8")]
        [Choice("Facepalm","9")]
        [Choice("Good-buy-it","10")]
        [Option("Art","Select art")] string selectedArt)
    {
        int selectedArtInt = int.Parse(selectedArt);
        string[] arts =
        {
            "█░█ █▀▀ █░░ █░░ █▀█\r\n█▀█ ██▄ █▄▄ █▄▄ █▄█",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠚⠉⠙⢦⡀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⣴⡯⢤⡀⠀⠀⠀⠀⠈⢧⡀\r\n⠀⠀⠀⠀⠀⠀⣸⢹⢸⢇⡇⠀⣠⠤⠤⣄⡀⢹\r\n⠀⠀⠀⠀⠀⢰⠃⠈⠉⠉⠀⢠⠇⠀⠀⠀⢹⣾\r\n⠀⠀⠀⠀⠀⡞⠀⠀⠀⠀⠀⠀⣇⠀⠀⠀⠀⢸\r\n⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠘⢦⠀⠀⢀⠇\r\n⠀⠀⠀⠀⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠀⣾⠁\r\n⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⢹⠀\r\n⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀\r\n⠀⠀⠀⣸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀\r\n⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀\r\n⠀⢠⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠂\r\n⠸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀wot doing??⠀",
            ".                       ⣴⣿⣦\r\n                         ⢻⣿⣿⠂\r\n                      ⢀⣴⣿⣿⣀\r\n                   ⣾⣿⣿⣿⣿⣿⣿⣦\r\n               ⣴⣿⢿⣷⠒⠲⣾⣾⣿⣿⡄\r\n          ⣴⣿⠟⠁⠀⢿⣿⠁⣿⣿⣿⠻⣿⣄\r\n   ⣠⡾⠟⠁⠀⠀⠀⢸⣿⣸⣿⣿⣿⣆⠙⢿⣷⡀⠀\r\n⡿⠋⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⠀⠀⠉⠻⣿⡭\r\n                        ⢸⣿⣿⣿⣿⣿\r\n⠀                   ⣾⣿⣿⣿⣿⣿⣿⣆⠀⠀ \r\n⠀                   ⣼⣿⣿⣿⡿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⠿⠟⠀⠀⠻⣿⣿⡇⠀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⠀⢀⣾⡿⠃⠀⠀⠀⠀⠀⠘⢿⣿⡀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⣰⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⡀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⢠⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣧⠀⠀⠀⠀\r\n‏⠀⠀⠀⢀⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣆⠀⠀⠀\r\n‏⠀⠀⠠⢾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⡤",
            "⠄⠄⠄⠄⢀⡤⣖⣞⣮⢾⢽⣳⢯⢿⢷⣦⣄⠄⠄⠐⠄\r\n⠐⠄⠄⣴⣯⣯⢷⣻⣺⢽⣫⢾⣝⡵⡯⣾⣽⢷⣄⠄⠄\r\n⠄⢀⣼⢿⡽⣾⢯⣷⣻⣽⢽⣳⣳⢽⡺⡮⣫⢯⢿⣦⠄\r\n⠄⣼⣿⢽⡯⣿⡽⣾⡿⣞⣯⢷⢯⢯⢯⢯⡺⡪⡳⣻⠄\r\n⣴⣿⣿⣽⣟⣷⣟⣯⣿⡽⣞⣯⢿⡽⡽⡵⣝⢮⣫⣺⠄\r\n⠄⠄⠉⠉⠛⠛⠛⠛⠛⠻⠿⠿⠿⣿⣿⡿⣿⣽⣾⣾⡀\r\n⠐⡀⠢⠄⡀⠄⢀⣄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⠣\r\n⡀⠂⠈⣪⣌⡤⢾⠿⠕⢤⣤⣨⣠⢤⠡⠄⠄⡌⠄⡐⡐\r\n⠐⠈⠄⠱⣻⡻⠶⢦⠶⠯⠟⢟⢯⢳⢩⡂⡆⡇⡐⡐⢌\r\n⢁⠐⠄⠈⣾⣓⢝⣛⡛⡗⣞⣗⢕⡕⢕⠕⡸⡀⠂⠌⡂\r\n⡀⠂⡁⠄⡿⣕⢷⣻⢽⢝⢞⢮⢳⠑⠅⢑⢜⠜⣬⢐⢈\r\n⠄⢁⣀⣴⠋⠪⠳⠹⠵⠹⠘⠈⠂⠁⡐⡸⡘⣠⡳⡣⣪\r\n⣽⢟⣿⡣⠄⢸⡄⠠⠠⡠⢠⢐⠨⡐⣴⣹⡨⣞⣎⢎⢺\r\n⠏⠟⠛⠃⠄⠘⠛⠊⠊⠘⠐⠅⠇⠻⠛⠓⠛⠛⠪⠓⠹\nnope",
            "⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠋⠉⠈⠉⠉⠉⠉⠛⠻⢿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡏⣀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿\r\n⣿⣿⣿⢏⣴⣿⣷⠀⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿\r\n⣿⣿⣟⣾⣿⡟⠁⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣷⢢⠀⠀⠀⠀⠀⠀⠀⢸⣿\r\n⣿⣿⣿⣿⣟⠀⡴⠄⠀⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣿⣿⠟⠻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠶⢴⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣁⡀⠀⠀⢰⢠⣦⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⡄⠀⣴⣶⣿⡄⣿\r\n⣿⡋⠀⠀⠀⠎⢸⣿⡆⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠗⢘⣿⣟⠛⠿⣼\r\n⣿⣿⠋⢀⡌⢰⣿⡿⢿⡀⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⡇⠀⢸⣿⣿⣧⢀⣼\r\n⣿⣿⣷⢻⠄⠘⠛⠋⠛⠃⠀⠀⠀⠀⠀⢿⣧⠈⠉⠙⠛⠋⠀⠀⠀⣿⣿⣿⣿⣿\r\n⣿⣿⣧⠀⠈⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠟⠀⠀⠀⠀⢀⢃⠀⠀⢸⣿⣿⣿⣿\r\n⣿⣿⡿⠀⠴⢗⣠⣤⣴⡶⠶⠖⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡸⠀⣿⣿⣿⣿\r\n⣿⣿⣿⡀⢠⣾⣿⠏⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠉⠀⣿⣿⣿⣿\r\n⣿⣿⣿⣧⠈⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡄⠈⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣦⣄⣀⣀⣀⣀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠙⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠁⠀⠀⠹⣿⠃⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢐⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⠿⠛⠉⠉⠁⠀⢻⣿⡇⠀⠀⠀⠀⠀⠀⢀⠈⣿⣿⡿⠉⠛⠛⠛⠉⠉\r\n⣿⡿⠋⠁⠀⠀⢀⣀⣠⡴⣸⣿⣇⡄⠀⠀⠀⠀⢀⡿⠄⠙⠛⠀⣀⣠⣤⣤⠄⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣶⣶⢶⢶⣦⣄⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢀⣤⣶⠶⠾⠶⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠋⢁⢀⣄⣀⠈⢻⣧⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⢰⡟⠃⠀⣀⣤⣤⠈⠹⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⠁⠀⠢⣾⠏⣿⡄⠈⢻⣧⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢠⣿⠁⢀⣾⠟⠁⣿⡆⠀⠘⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠀⠀⢸⡿⠀⠈⣿⡄⠈⣿⡄⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢸⣯⠐⠴⣿⡂⠀⢸⣷⠀⠀⢸⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡆⠀⣿⡇⠀⡀⣘⣿⡄⠸⣷⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢸⣧⠀⠀⠻⠗⠉⠉⠛⠀⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣇⠀⠙⠋⠉⠉⠁⠉⠁⠀⣿⡅⠀⠀⠀\r\n⠀⠀⠀⠀⣈⣿⣢⣤⣤⣤⣤⣤⣶⣶⣶⣾⣿⣤⣴⣶⣶⣦⣶⣶⣶⡶⠶⣶⢶⠶⢾⢿⣶⣶⣶⣶⣦⣤⣤⣤⣄⣿⣇⠀⠀⠀\r\n⠀⠀⣴⡿⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠹⠟⠛⠻⠿⢷\r\n⠀⣸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢰⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢸⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⡿⢿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣶⣿⣿⣻⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠈⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⠛⠉⠀⠀⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠤⢠⣶⣶⣴⣤⣤⣤⣤⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⢿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⠃⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠨⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⢸⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢆⠀⠀⠀⠈⠉⠉⠉⠛⠉⠉⠉⠀⠀⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠒⠠⠠⠀⠠⠤⠤⠤⠤⠤⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣴⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣦⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣿⠟⠉⠁⠀⠀⠀⠀⠀⠀⣀⣀⠠⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠙⠛⠿⠿⣿⣷⣶⣦⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠋⠀⠀⠀⠀⠀⠀⣀⠤⠖⠋⣁⣀⠤⠤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠤⠤⠤⠤⢌⡙⠻⢿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠁⠀⠀⠀⠀⣠⠴⠋⣁⡤⠖⢋⣩⡤⠤⠒⠒⠒⠒⠒⠲⣖⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⣤⣤⣄⠀⠀⠁⠀⠀⠈⠙⢿⣶⡄⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢠⣾⠟⠀⠀⠀⠀⠴⠋⠁⡠⠞⣁⡴⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⡆⠀⠀⠀⠀⠀⠀⠀⠈⢉⡿⠁⠀⠀⠀⠀⠈⠙⢦⡄⠀⠀⠀⠀⠀⠹⣿⡄⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢠⣿⡟⠀⠀⠀⠀⠀⠀⠠⠞⢠⠞⠉⠀⠀⣀⣀⣀⣤⣤⣤⣄⣀⡀⠀⠀⠸⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠹⡄⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢀⣴⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣿⣿⣿⣿⣿⣿⡿⠛⠻⢿⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⣀⣤⣤⣤⣤⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠹⣿⣄⠀⠀⠀\r\n⠀⠀⢀⣴⣿⣿⡿⠯⠭⠥⠤⠀⠀⠀⠴⠶⠋⠀⢾⣿⣵⣾⣿⡿⠿⢿⣿⣷⣶⣤⣀⠈⢻⣿⣧⠀⠀⠀⠀⢀⣀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠀⠶⠶⠦⠴⠤⣤⡈⠻⣿⣦⠀\r\n⠀⣴⣿⢟⡟⠁⠀⣠⣴⣶⡿⠿⢿⣶⣤⣄⡘⠁⠀⠀⠀⠀⠀⣠⣾⡟⠀⠀⠈⠛⠻⢿⣿⠟⠁⠀⠀⠀⠀⠘⠻⢿⣿⠿⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠶⢤⡙⢦⡌⣿⣇\r\n⣼⡿⠁⡼⠀⢀⣾⡿⠋⠁⠀⣰⡆⠈⠙⠻⠿⣷⣶⣶⣶⣶⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⣤⡀⠀⣠⣶⣾⠿⠿⣿⣶⡄⢹⠀⢹⣸⣿\r\n⣿⠃⠀⡇⠀⣼⡿⠁⠀⠀⣠⣿⣿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣷⣄⡀⠀⠀⠀⠻⠿⠿⠿⠟⠀⣼⠀⠀⠉⠁⢸⠄⢸⢻⣿\r\n⣿⡄⠀⣧⠀⢻⣧⠠⠶⠿⣿⣿⡀⠙⠛⠿⣿⣦⣤⣀⡀⠀⠀⠠⠤⠤⠤⠴⠚⢣⣿⠟⠛⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣷⣄⠀⠀⠀⠀⠀⠀⢰⣿⣇⠀⠀⣠⠞⠀⡼⣼⡟\r\n⢻⣿⡀⢸⡀⠘⣿⡆⠀⠀⠈⣿⣷⡄⠀⠀⠈⠙⢿⣿⣿⣷⣶⣤⣄⣀⠀⠀⠀⠸⣿⣦⠀⣿⠿⠿⠿⠖⠀⠀⠀⠀⠀⣴⣿⠿⠛⠋⠓⠲⢤⡀⠀⢀⣾⣿⣿⡇⢀⣠⠴⠚⣱⣿⠃\r\n⠈⠻⣷⣄⠙⠶⣌⡁⠀⠀⠀⠙⣿⣿⣷⣦⣄⡀⢸⣿⡀⠀⠉⠙⠛⠿⠿⣷⣶⣦⣌⣛⣀⠀⠀⠀⠀⠀⠀⠸⣿⣶⣿⠟⠁⠀⠀⠀⠀⠀⣀⣥⣶⣿⢿⣷⣿⣇⠀⠀⠀⣴⣿⠃⠀\r\n⠀⠀⠙⢿⣷⣦⠄⠀⠀⠀⠀⠀⠈⢿⣿⡙⠛⢿⣿⣿⣿⣦⣀⣀⠀⠀⠀⠀⣿⡟⠛⠛⠿⠿⢿⣷⣶⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣶⣿⣿⡿⠛⢻⣿⠈⢿⣿⣿⠀⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠙⣿⣦⠀⠀⠀⠀⠀⠀⠀⠻⣿⣆⠀⢹⣿⠿⢿⣿⣿⣿⣶⣦⣴⣿⡁⠀⠀⠀⠀⠀⠀⢻⣿⠉⠉⠉⠉⢻⣿⠋⠉⠉⠉⠙⣿⡆⠀⢸⣿⣤⣼⣿⣿⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⢿⣧⡀⠀⠀⠀⠀⠀⠀⠘⢿⣷⣼⡿⠀⠀⠀⠉⠛⠿⢿⣿⣿⣿⣿⣶⣶⣶⣤⣤⣾⣿⣦⣤⣤⣤⣾⣿⣦⣤⣶⣶⣶⣿⣷⣾⣿⣿⣿⣿⣿⣿⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠈⢿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣷⣄⡀⠀⠀⠀⠀⢠⣿⡇⠉⠛⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣶⣄⡀⢀⣾⡿⠀⠀⠀⠀⠀⠀⠈⣿⡏⠙⠛⠛⠛⢻⣿⣿⠿⠿⣿⣿⡿⠟⢻⣿⠟⣿⣿⣱⣿⠃⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⣿⣦⡀⠠⣄⡀⠀⠦⣀⡀⠀⠉⠻⢿⣿⣿⣄⣀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀⢸⣿⠁⠀⠀⣼⣿⠀⢠⣿⠏⢀⣻⣷⣿⠃⠀⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣦⣄⡙⠳⠤⣀⡙⠓⠤⣄⡀⠀⠉⠛⠻⠿⠿⢷⣶⣤⣴⣿⣧⣤⣤⣤⣤⣿⣿⣤⣤⣼⣿⣧⣴⣾⣿⠿⠿⠟⠋⠀⠀⠀⠀⠀⠀⣿⡆⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⢿⣶⣤⣈⠙⠒⠤⣌⡉⠓⠲⣤⣄⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⢀⣴⠆⠀⠀⡄⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⣿⣶⣤⣀⠉⠙⠲⠦⢌⣉⣑⡲⠦⢤⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⢀⣀⡠⠶⠋⠀⠀⠀⣰⠃⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⢿⣷⣤⣄⡀⠀⠈⠉⠙⠓⠒⠦⠤⠤⢄⣀⣀⣀⣈⣉⣉⣉⢉⠉⠉⠁⠀⠀⠀⣀⣠⠴⠋⠁⠀⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⢿⣷⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⣴⣿⠃⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠻⠿⣿⣶⣶⣶⣤⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠁⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠛⠿⠿⣷⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣴⣾⡿⠛⠁⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣠⣤⣄⣤⣤⣤⣠⣄⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡿⠿⠋⠙⠋⠙⠋⠉⠉⠛⠛⠛⠿⢿⣷⣦⣀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⢀⡉⠿⣿⣷⡀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⠀⠀⡀⢀⣠⣀⣀⣀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠻⣿⣿⣄⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⡇⠀⣠⣿⣿⡿⠿⠿⠿⠿⠿⠿⠿⣿⣿⣧⡀⢀⠀⢸⣿⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡟⠀⠀⣿⣿⣿⣄⡀⠘⠢⣄⣀⣀⣀⠀⠈⣿⣿⡆⠀⠀⢹⣿⣧⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠃⠀⠀⠹⢿⣿⣽⣿⡶⣶⢶⣶⣾⣾⣿⣿⣿⠟⠁⠀⠀⠈⢹⣿⡄⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⡯⠀⠀⠆⠀⠀⠙⠛⠿⠿⠿⠿⠿⠟⠛⠛⠉⠁⠀⠀⠀⠀⠀⠸⣿⣇⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣯⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡿⠀⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡗\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⠀⠃⠀⠀⠀⠀⣠⣤⣶⣶⣶⣶⣶⣶⣶⣾⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡏⠈⠀⠀⠀⠠⣼⣿⢟⠉⠀⠀⠀⠀⠀⠀⠀⠙⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⢀⣀⣄⡀⠀⠀⣸⣿⡃⠀⠀⠀⠀⠈⢿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⣠⣶⣿⡿⠿⠿⠿⢿⣿⡏⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣇\r\n⣠⣿⡟⠉⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏\r\n⠘⢻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⡏⠀⠀⠀⠀⣀⣤⣤⣴⣾⣿⡇⠂⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠈⠀⠙⢿⣿⣶⣤⣤⣤⣤⣤⣤⣴⣶⣾⣿⡿⠋⠁⠀⠀⠀⣶⣾⡟⠟⠉⠀⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠃\r\n⠀⠀⠀⠀⠀⠉⠙⠛⠛⠋⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠰⣿⣏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣾⡿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣷⣦⣤⣀⣀⣀⣀⣀⣀⣴⣤⣴⣾⡿⠟⠉⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠛⠛⠛⠛⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⠟⠋⠀⠀⠹⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡾⠟⠁⠀⠀⠀⠀⠀⢻⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⡿⠛\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⡿⠋⠁⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣶⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣿⣿⠿⠿⣶⣶⣦⣤⣴⣿⠟⠁⠀⠀⠀⢀⡼\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡟⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⢠⠞⠁⡴⠋⠀⠀⢀⡴⠋⢈⡿⠛⠁⠀⠀⠀⠀⢀⠎⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⡧⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠋⠀⡜⠀⠀⠀⣠⠋⠀⢠⠞⠀⠀⠀⠀⠀⠀⠀⠼⠤⡄\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣄⡼⠁⠀⠀⢰⠃⠀⣠⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠔⠁\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣶⢿⣿⠟⠀⠀⠀⠀⠀⣠⣤⣄⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠘⠷⠴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢦\r\n⠀⠀⠀⠀⠀⣰⡟⠛⢿⣶⣤⣼⡇⠀⠈⠀⠀⠀⠀⢠⣾⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⢀⣴⡶⠿⠿⠀⠀⠘⠿⣿⣿⣷⣦⡀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠇⠀⣀⡤⠤⠤⠤⠤⣀⡀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀\r\n⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠙⢦⣉⠻⢿⣷⣦⣀⠀⠘⠻⠿⠟⠋⡠⢾⠁⠀⠀⠀⠀⠀⠀⠈⠐⠄⠀⠀⢸⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀\r\n⣿⡇⠀⢀⡾⢻⣿⣷⡀⠀⠀⢰⠌⣑⠦⣌⠛⠿⣷⣦⣀⠀⠀⢰⠁⠘⣄⠀⢀⠶⡀⠀⠀⢀⡄⠈⡆⠀⠘⢿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀\r\n⣿⠃⠀⢸⣇⣿⣿⣿⡇⠀⠀⢸⠀⠈⠙⠺⢽⣦⣌⡙⠻⣷⣦⣄⠀⠀⠀⠉⠀⠀⠙⠒⠒⠉⠀⠀⢱⠀⠀⠀⠙⠛⠛⠉⠀⠀⠀⠀⠀⠀\r\n⣿⠀⠀⠀⠙⠿⠿⠋⠀⠀⠀⢸⠀⠀⠀⠀⠀⠈⠙⠂⠀⠀⣿⠻⣿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡄⠀⠀⠀⢀⣄⠀⢀⡤⠒⠺⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⢹⠉⡿⢿⣦⣤⣶⣶⣦⣤⡐⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡇⠀⣦⡀⠘⠛⢀⡼⠀⠀⢠⠀⠈⡗⣦⣄⡀⠀⠀⠀⠀⣿⠀⢸⠀⡇⢸⡏⢹⠿⣄⡉⠛⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⣧⣀⠀⠉⠓⠚⠉⠀⣠⣤⣤⣀⠀⡇⣇⢸⠉⡗⠦⢄⣀⢻⣦⣼⡀⡇⢸⠀⢸⠀⣿⢉⠒⠾⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢻⣿⣌⡙⠲⢤⣴⠶⠚⠧⣌⡛⠿⣿⣷⣷⣸⠀⡇⠀⠀⠈⠙⠺⣝⡻⢿⣾⣦⣸⠀⣿⠀⠉⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⠙⠻⢿⣶⣬⣙⣶⣤⣈⠙⠳⢤⣉⡛⠿⣷⣷⣄⡀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣷⣿⠀⠀⠀⠀⢿⡇⠀⠀⠀⠀⠠⡀⠀⠀⠀⢀⣀⣤\r\n⠀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣿⣧⣄⣀⡈⠙⠳⢦⣍⠛⢿⣷⣦⣄⠀⠀⠀⠀⠀⠈⠙⠻⢤⡀⠀⠀⢸⡇⠐⢦⡀⠀⢀⡌⠲⣄⣠⡼⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⣿⠟⠛⠛⠛⠷⢶⣌⣙⡶⠬⠷⠞⠛⠳⠶⠶⣦⣤⣀⠀⠀⠉⠓⣶⣾⣿⠀⠀⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡇⠀⠀⠀⠀⠀⠀⣿⠋⠀⠀⠀⣠⠔⠁⠀⠀⠀⠉⠻⢷⣦⡀⢀⣿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⢀⠜⠁⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣾⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠿⠀⠀⠀⠀⠀⠀⠀⠻⠦⠠⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠮⠤⠈⠻⠷⠤⠤⠤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡏⠀⣽⠶⣄⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠁⡇⠀⡏⠀⣽⣄⡀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠀⡇⠀⡇⠀⡏⠈⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣼⠀⡇⠀⠑⠀⡇⠀⣿⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡇⣽⠀⠛⠀⠀⠀⠀⠀⢻⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⣿⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣤⡤⠤⢤⣤⣤⣄⡀⣀⡀⠀⠀⢀⣸⣷⣇⣀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⠖⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⣿⡷⠻⣏⣀⣠⠌⠙⢷⡀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡶⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠃⠀⠉⠀⡼⠀⠀⠈⢿⡀⠀⠀⢀⣼⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠸⠷⠤⣄⣀⣼⠗⠚⠛⠋⠁⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⡟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⢀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣈⣙⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣄⠀⠀⠀⣼⠀⠀⠀⢀⡴⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡦⢤⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣯⣻⡶⣤⣹⣤⣄⣠⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⡴⠶⢖⣲⣶⠞⠋⠁⠀⠀⠈⠉⢉⣬⢿⡋⠉⠁⠀⠀⠀⠀⠀⠀⠀⣠⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⣀⡴⠚⢉⣠⡴⠞⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⡞⠁⠀⠉⠀⠀⠀⠀⠀⠀⠀⢀⡼⢯⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢀⣴⠞⢁⣴⠞⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡇⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠋⠀⢸⡏⠉⠙⠓⠶⣤⣀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀\r\n⠀⠀⠀⣠⡞⣡⠾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠞⠉⠉⠂⠀⠀⠀⠀⠀⠀⣰⠋⠀⠀⢠⠟⠀⠀⠀⠀⠀⠀⠉⠛⠛⠛⠛⠉⠉⠉⠉⠋⠉⠉\r\n⠀⠀⣰⠏⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠞⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⡼⠃⠀⣠⡴⠋⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⣰⠏⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠾⣯⡀⠀⠘⢧⣀⠀⠀⠀⢀⣀⣤⣾⣯⡤⠶⠛⠉⠀⠀⠀⠀⠀⠀⢀⡔⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠶⠋⠁⠀⠈⠻⣄⠀⠀⠈⠙⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠸⣧⡀⠀⠀⠀⠀⠀⠀⣀⡴⠟⠁⠀⠀⠀⠀⠀⠀⠙⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⠙⠓⠶⠶⠶⠶⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠒⠚⣿⠛⠛⠛⠛⠛⠛⠛⠛⠛\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⡴⠑⡄⠀⠀⠀⠀⠀⠀⠀ ⣀⣀⣤⣤⣤⣀⡀\r\n⠸⡇⠀⠿⡀⠀⠀⠀⣀⡴⢿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀\r\n⠀⠀⠀⠀⠑⢄⣠⠾⠁⣀⣄⡈⠙⣿⣿⣿⣿⣿⣿⣿⣿⣆ good\r\n⠀⠀⠀⠀⢀⡀⠁⠀⠀⠈⠙⠛⠂⠈⣿⣿⣿⣿⣿⠿⡿⢿⣆\r\n⠀⠀⠀⢀⡾⣁⣀⠀⠴⠂⠙⣗⡀⠀⢻⣿⣿⠭⢤⣴⣦⣤⣹⠀⠀⠀⢀⢴⣶⣆\r\n⠀⠀⢀⣾⣿⣿⣿⣷⣮⣽⣾⣿⣥⣴⣿⣿⡿⢂⠔⢚⡿⢿⣿⣦⣴⣾⠸⣼⡿\r\n⠀⢀⡞⠁⠙⠻⠿⠟⠉⠀⠛⢹⣿⣿⣿⣿⣿⣌⢤⣼⣿⣾⣿⡟⠉\r\n⠀⣾⣷⣶⠇⠀⠀⣤⣄⣀⡀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ Buy it\r\n⠀⠉⠈⠉⠀⠀⢦⡈⢻⣿⣿⣿⣶⣶⣶⣶⣤⣽⡹⣿⣿⣿⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠉⠲⣽⡻⢿⣿⣿⣿⣿⣿⣿⣷⣜⣿⣿⣿⡇\r\n⠀⠀ ⠀⠀⠀⠀⠀⢸⣿⣿⣷⣶⣮⣭⣽⣿⣿⣿⣿⣿⣿⣿⠇\r\n⠀⠀⠀⠀⠀⠀⣀⣀⣈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇\r\n⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿"
        };
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(arts[selectedArtInt]));
    }


    [SlashCommand("embed", "Send's your custom embed")]
    public async Task EmbedCommand(InteractionContext ctx,
    [Option("title", "Title of your embed (text)")] string title,
    [Option("description", "Description of your embed (text)")] string description,
    [Option("isPoll", "False = no emotes")] bool poll,
    [Option("thumbnail", "Miniature of your embed (url)")] string thumbnail = "",
    [Option("footer", "Footer of your embed (text)")] string footer = "",
    [Option("imageurl", "Image of your embed (url)")] string imageUrl = "",
    [Option("field1", "Separe title & description with ;| Example: My Title;Here is my description")] string field1 = "",
    [Option("field2", "Separe title & description with ;| Example: My Title;Here is my description")] string field2 = "",
    [Option("field3", "Separe title & description with ;| Example: My Title;Here is my description")] string field3 = "",
    [Option("field4", "Separe title & description with ;| Example: My Title;Here is my description")] string field4 = "",
    [Option("field5", "Separe title & description with ;| Example: My Title;Here is my description")] string field5 = "",
    [Choice("Black","0;0;0")]
    [Choice("Gray","128;128;128")]
    [Choice("White","255;255;255")]
    [Choice("Red","230;0;0")]
    [Choice("Green","0;230;0")]
    [Choice("Blue","0;0;230")]
    [Choice("Yellow","230;230;0")]
    [Choice("Aqua/Cyan","0;230;230")]
    [Choice("Purple","128;0;128")]
    [Option("color", "Set's the annoucment color from choice")] string color = "",
    [Option("colorRGB", "Set's the annoucment color with RGB | Exaple: 100;200;255")] string colorRGB = "")
    {
        if (!ctx.Member.Permissions.HasPermission(Permissions.Administrator)) return;
        var customEmbed = new DiscordEmbedBuilder
        {
            Title = title,
            Description = description,
            Color = DiscordColor.Blurple,
        };
        if (!string.IsNullOrEmpty(field1))
        {
            var fieldStrings = field1.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            customEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field2))
        {
            var fieldStrings = field2.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            customEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field3))
        {
            var fieldStrings = field3.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            customEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field4))
        {
            var fieldStrings = field4.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            customEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field5))
        {
            var fieldStrings = field5.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            customEmbed.AddField(name, value, false);
        }

        if (!string.IsNullOrEmpty(thumbnail)) customEmbed.WithThumbnail(thumbnail);
        if (!string.IsNullOrEmpty(footer)) customEmbed.WithFooter(footer);
        if (!string.IsNullOrEmpty(imageUrl)) customEmbed.WithImageUrl(imageUrl);

        if (!string.IsNullOrEmpty(colorRGB))
        {
            bool rgbIsCorrect = true;
            var colorRBGs = colorRGB.Split(";");

            byte red = byte.Parse(colorRBGs[0]);
            byte green = byte.Parse(colorRBGs[1]);
            byte blue = byte.Parse(colorRBGs[2]);

            if (red > 255 || red < 0 || green > 255 || green < 0 || blue > 255 || blue < 0)
                rgbIsCorrect = false;

            if (rgbIsCorrect) customEmbed.WithColor(new DiscordColor(red, green, blue));
            else await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Incorrect RGB").AsEphemeral(true));
        }
        if (!string.IsNullOrEmpty(color))
        {
            var colorRBGs = color.Split(";");

            byte red = byte.Parse(colorRBGs[0]);
            byte green = byte.Parse(colorRBGs[1]);
            byte blue = byte.Parse(colorRBGs[2]);
            customEmbed.WithColor(new DiscordColor(red, green, blue));
        }
        var message = await ctx.Channel.SendMessageAsync(customEmbed.Build());

        if (poll)
        {
            await message.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":white_check_mark:"));
            await message.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, ":no_entry_sign:"));
        }

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder().AsEphemeral(true).WithContent("Created !"));
    }

    [SlashCommand("code", "Unlock code")]
    public async Task CodeCommand(InteractionContext ctx,
        [Option("code", "Code")] string code)
    {
        if (ctx.Guild == null) return;
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        if (guildSettings.Code != null)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"{ctx.User.Mention} use {guildSettings.Code}:\n{guildSettings.CodeContent}").AsEphemeral(true));
        }
        else
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Code doesn't exits").AsEphemeral(true));
        }
    }

    //info center
    //info center
    //info center


    [SlashCommand("server_info", "Server info")]
    public async Task ServerInfoCommand(InteractionContext ctx)
    {
        if (ctx.Guild == null) return;
        var serverinfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"{ctx.Guild.Name}",
            Color = DiscordColor.Rose,
        };
        DateTimeOffset add = ctx.Guild.JoinedAt;
        var guild = ctx.Guild;
        var bans = await guild.GetBansAsync();
        serverinfoEmbed.AddField("Owner:", $"{guild.Owner.Mention}");
        serverinfoEmbed.AddField("Created date:", TimestampBuilder(add));
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

    [SlashCommand("user_info", "Shows informations about the user")]
    public async Task UserInfoCommand(InteractionContext ctx,
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

        userinfoEmbed.AddField("Joined server at", TimestampBuilder(join), false);
        userinfoEmbed.AddField("Joined discord at", TimestampBuilder(add), false);

        if (!Array.Exists(permsList, element => element == " All permissions")) userinfoEmbed.AddField("Permissions ", perms, false);
        else userinfoEmbed.AddField("Permissions ", "All permisions", false);

        userinfoEmbed.WithThumbnail(user.AvatarUrl);

        var avatarURL = new DiscordLinkButtonComponent($"{user.AvatarUrl}", "Avatar");


        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(userinfoEmbed.Build()).AddComponents(avatarURL));
    }

    [SlashCommand("role_info", "Shows informations about the role")]
    public async Task RoleInfoCommand(InteractionContext ctx,
    [Option("role", "Role")] DiscordRole role)
    {
        if (ctx.Guild == null) return;
        var roleInfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"{role.Name}",
            Color = role.Color,
        };

        var perms = role.Permissions.ToPermissionString();
        var permsList = perms.Split(",");


        roleInfoEmbed.AddField("Role ID", role.Id.ToString(), false);
        roleInfoEmbed.AddField("Creation date", TimestampBuilder(role.CreationTimestamp));
        roleInfoEmbed.AddField("Hierarchy", role.Position.ToString());
        if(role.IconUrl!=null)roleInfoEmbed.WithThumbnail(role.IconUrl);

        if (!Array.Exists(permsList, element => element == " All permissions")) roleInfoEmbed.AddField("Permissions ", perms, false);
        else roleInfoEmbed.AddField("Permissions ", "All permisions", false);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(roleInfoEmbed.Build()));
    }
    [SlashCommand("ping", "Show's bot ping")]
    public async Task PingCommand(InteractionContext ctx)
    {
        var ping = ctx.Client.Ping;
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .WithContent($"Pong! : {ping}ms").AsEphemeral(true));
    }

    // suggests
    // suggests
    // suggests 
    // suggests
    
    [SlashCommand("suggest", "Sends your suggest on the official discord bot server ")]
    public async Task SuggestDotArt(InteractionContext ctx, [Option("suggest","Suggest message here")] string suggestMessage)
    {
        var guild = await ctx.Client.GetGuildAsync(1162036287642021939);
        var channel = guild.GetChannel(1180918365485813780);
        if(suggestMessage.Length > 20) await channel.SendMessageAsync($"From {ctx.User.Username}:\n{suggestMessage}");
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Sended !").AsEphemeral(true));
    }


    // admin
    // admin
    // admin
    // admin


    [SlashRequireUserPermissions(Permissions.Administrator)]
    [SlashCommand("config_botname", "Change bot name")]
    public async Task ConfigureBotNameCommand(InteractionContext ctx, [Option("newname", "New bot name")] string newNickname)
    {
        if (ctx.Guild == null) return;
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];

        var oldNickname = botMember.Nickname;

        await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = newNickname);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent($"Chaned bot name '{oldNickname}' for '{newNickname}'."));

    }

    [SlashCommand("config_verifyrole", "Set the verification role")]
    [SlashRequireUserPermissions(Permissions.Administrator)]
    public async Task SetVerifyRole(InteractionContext ctx, [Option("role", "The verification role")] DiscordRole role)
    {
        if (ctx.Guild == null) return;
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        guildSettings.VerifyRoleId = role.Id;
        SaveGuildSettings(ctx.Guild.Id, guildSettings);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Verification role set to {role.Name}").AsEphemeral(true));
    }

    [SlashRequireUserPermissions(Permissions.Administrator)]
    [SlashCommand("config_code", "Change server code")]
    public async Task ConfigureServerCode(InteractionContext ctx, [Option("newcode", "New code (What ever you like)")] string newCode,
        [Option("message", "Message in the code")] string content)
    {
        if (ctx.Guild == null) return;
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        guildSettings.Code = newCode;
        guildSettings.CodeContent = content;
        SaveGuildSettings(ctx.Guild.Id, guildSettings);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent($"Created new code ||{guildSettings.Code} with content {guildSettings.CodeContent}||"));

    }

    [SlashCommand("config_resetvalue", "Reset value")]
    [SlashRequireUserPermissions(Permissions.Administrator)]
    public async Task ResetValue(InteractionContext ctx,
        [Choice("VerifyRole","verify")]
        [Choice("BotName","botname")]
        [Choice("EventChannel","event")]
        [Choice("Code","code")]
        [Option("value","value to reset")] string value)
    {
        if (ctx.Guild == null) return;
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        switch (value)
        {
            case"verify":
                guildSettings.VerifyRoleId = 0;
                SaveGuildSettings(ctx.Guild.Id, guildSettings);
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Verify role now is disabled (beacosue verify role equals null)"));
                break;

            case "botname":
                var oldNickname = botMember.Nickname;

                await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = botMember.Username);

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Reset bot nickname form {oldNickname}"));
                break;

            case "code":
                guildSettings.Code = "";
                guildSettings.CodeContent = "";
                SaveGuildSettings(ctx.Guild.Id, guildSettings);

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Code is not enabled from now"));
                break;

            case"event":
                guildSettings.EventChannelID = 0;
                SaveGuildSettings(ctx.Guild.Id, guildSettings);

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent($"Event channel is not enabled from now"));
                break;
            default:
                break;
        }
    }

    [SlashCooldown(10,5,SlashCooldownBucketType.User)]
    [SlashCommand("verify", "Be verified")]
    public async Task VerifyUser(InteractionContext ctx)
    {
        if (ctx.Guild == null) return;
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        //var verifyRole = ctx.Guild.Roles.Values.FirstOrDefault(role => role.Name == "Verified");

        var verifyRole = ctx.Guild.GetRole(guildSettings.VerifyRoleId);
        if (verifyRole == null)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent("Verification is not enabled on this server"));
            return;
        }
        var hasRole = ctx.Member.Roles.Any(role => role.Id == guildSettings.VerifyRoleId);
        if (hasRole) return;
        await ctx.Member.GrantRoleAsync(verifyRole);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent("Now you are verified"));
        await ctx.DeferAsync();
    }

    [SlashCommand("guild_copyrole", "Copy a role (admin only)")]
    [SlashRequireUserPermissions(Permissions.Administrator)]
    public async Task CopyRole(InteractionContext ctx, [Option("role", "Role to copy")] DiscordRole role, [Option("name", "Name for the copied role")] string roleName)
    {
        //if (!ctx.Member.Permissions.HasPermission(Permissions.Administrator)) return;
        if (ctx.Guild == null) return;

        if (role == null)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent("Please specify a valid role to copy.").AsEphemeral(true));
            return;
        }
        try
        {
            var copiedRole = await ctx.Guild.CreateRoleAsync(roleName, role.Permissions, role.Color, role.IsHoisted, role.IsMentionable);

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Role '{role.Name}' has been copied to '{copiedRole.Name}' with a new name.").AsEphemeral(true));
        }
        catch (Exception ex)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"An error occurred: {ex.Message}").AsEphemeral(true));
        }
    }

    [SlashCooldown(1,60,SlashCooldownBucketType.Guild)]
    [SlashCommand("guild_getstat", "Gets guild stat and send it(in file or discord message)")]
    public async Task GetStat(InteractionContext ctx,
        [Choice("Users-list","users")]
        [Choice("Bans-list","bans")]
        [Choice("Channels-list","channels")]
        [Choice("Roles-list","roles")]
        [Choice("AllGuildStats","all")]
        [Option("Stat","stat")] string stat)
    {
        if (ctx.Guild == null) return;
        await ctx.DeferAsync();

        var members = await ctx.Guild.GetAllMembersAsync();
        var bans = await ctx.Guild.GetBansAsync();
        var channels = await ctx.Guild.GetChannelsAsync();
        var roles = ctx.Guild.Roles;
        var content = new StringBuilder();
        switch (stat)
        {
            case"users": foreach (var member in members) content.AppendLine(member.Username); break;
            case"bans": foreach (var ban in bans) content.AppendLine(ban.User.Username); break;
            case"channels": foreach (var channel in channels) content.AppendLine(channel.Name); break;
            case"roles": foreach (var role in roles) content.AppendLine(role.Value.Name); break;
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
        await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent($"The users list of {ctx.Guild.Name}:").AddFile(fileStream));
        File.Delete(filePath);
    }

    [SlashRequirePermissions(Permissions.Administrator)]
    [SlashCommand("config_statchannel", "BETA")]
    public async Task AddStatChannel(InteractionContext ctx,
        [Choice("Users","users")]
        [Choice("Bans","bans")]
        [Option("stat","Stat")] string stat,
        [Option("customName","Set custom name")] string customName = "")
    {
        if (ctx.Guild == null) return;
        string name=stat;
        string display="";
        switch (stat)
        {
            case"users":
                display = ctx.Guild.MemberCount.ToString();
                break;
            case "bans":
                var bans = await ctx.Guild.GetBansAsync();
                display = bans.Count.ToString();
                break;
            default:
                break;
        }
        if (!string.IsNullOrEmpty(customName)) name = customName; 
        var channel = await ctx.Guild.CreateVoiceChannelAsync($"{display} {name}");
        await ctx.CreateResponseAsync($"Succesful created new stat channel ({channel.Mention}). \nIf it don't show on list please check showing that channel.",true);
    }


    [SlashRequirePermissions(Permissions.Administrator)]
    [SlashCommand("config_eventchannel", "Sets new Event channel")]
    public async Task SetEventChannel(InteractionContext ctx, 
        [Option("channel","channel")] DiscordChannel channel)
    {
        if (ctx.Guild == null) return;
        var guildSettings = GetGuildSettings(ctx.Guild.Id);
        guildSettings.EventChannelID= channel.Id;
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Event channel is now set to the {channel.Mention}").AsEphemeral(true));
        SaveGuildSettings(guildSettings.Id,guildSettings);
    }

    [SlashCommand("clear", "Clears amount of messages")]
    public async Task Clear(InteractionContext ctx,
        [Option("amount","Amount of messages to clear")] string amountStr)
    {
        if (ctx.Guild == null) return;
        int amount;
        var channel = ctx.Channel;
        
        try
        {
            amount = int.Parse(amountStr);
        }
        catch (Exception)
        {
            throw;
        }
        var messages = await ctx.Channel.GetMessagesAsync(amount);
        if (amount < 1 || amount > 100)
        {
            await ctx.CreateResponseAsync("Incorrect amount of messages", true);
            await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder());
            return;
        }
        await ctx.DeferAsync();
        try
        {
            await channel.DeleteMessagesAsync(messages);
            await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent($"Deleted {messages.Count} messages").AsEphemeral(true));
        }
        catch (Exception)
        {
            await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent($"Error").AsEphemeral(true));
            throw;
        }
    }
    //HELP
    //HELP
    //HELP
    [SlashRequireOwner]
    [SlashCommand("help","Bot help center")]
    public async Task Help(InteractionContext ctx)
    {
        await ctx.DeferAsync();
        var helpOptions = new List<DiscordSelectComponentOption>()
        {
            new DiscordSelectComponentOption(
                "Commands",
                "help_commands",
                "If you don't know!"
                ),
            new DiscordSelectComponentOption(
                "Bot functions",
                "help_func",
                "Read how it works!"),
            new DiscordSelectComponentOption(
                "Admin",
                "help_admin",
                "Traning for admin!"),
            new DiscordSelectComponentOption(
                "Bot setuping",
                "help_setuping",
                "Try fantastic server functions!"),
        };

        // Make the dropdown
        var helpDropdown = new DiscordSelectComponent("help_dropdown", null, helpOptions, false,1,1);
        
        await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent("How can i help you today?").AddComponents(helpDropdown));
    }
    [SlashCommand("commands", "Show's all commands")]
    public async Task Commands(InteractionContext ctx)
    {
        var commandshelpEmbed = new DiscordEmbedBuilder
        {
            Title = "Command's list",
            Color = DiscordColor.Cyan,
        };
        //commandshelpEmbed.AddField("CATEGORY NAME","DESCRIPTION");
        //commandshelpEmbed.AddField("</command:000>", "** **",true);

        commandshelpEmbed.AddField("COMMON", "common commands (not admin)");
        commandshelpEmbed.AddField("</help:1181276215122866318>", "** **", true);
        commandshelpEmbed.AddField("</commands:1178716973597732978>", "** **", true);
        commandshelpEmbed.AddField("</ping:1178716973438353515>", "** **", true);
        commandshelpEmbed.AddField("</credits:1178716973597732979>", "** **", true);
        commandshelpEmbed.AddField("</verify:1178716973597732976>", "** **", true);
        commandshelpEmbed.AddField("</suggest:1181276215122866317>", "** **", true);
        commandshelpEmbed.AddField("</user_info:1178716973438353513>", "** **", true);
        commandshelpEmbed.AddField("</server_info:1178716973438353512>", "** **", true);
        commandshelpEmbed.AddField("</role_info:1178716973438353514>", "** **", true);
        commandshelpEmbed.AddField("</dotart:1178716973438353508>", "** **", true);
        commandshelpEmbed.AddField("</embed:1178716973438353509>", "** **", true);
        commandshelpEmbed.AddField("</code:1178716973597732981>", "** **", true);

        commandshelpEmbed.AddField("GUILD", "guild commands");
        commandshelpEmbed.AddField("</guild_getstat:1187847895651725403>", "** **", true);
        commandshelpEmbed.AddField("</guild_copyrole:1187847895651725402>", "(admin only)", true);

        commandshelpEmbed.AddField("ADMIN", "admin commands only");
        commandshelpEmbed.AddField("</clear:1188445497095106560>", "** **", true);

        commandshelpEmbed.AddField("BOT CONFIG", "admin only");
        commandshelpEmbed.AddField("</config_resetvalue:1178716973597732975>", "** **", true);
        commandshelpEmbed.AddField("</config_botname:1178716973438353516>", "** **", true);
        commandshelpEmbed.AddField("</config_code:1180824326358962197>", "** **", true);
        commandshelpEmbed.AddField("</config_verifyrole:1180824326358962196>", "** **", true);
        commandshelpEmbed.AddField("</config_eventchannel:1187109879597518869>", "** **", true);
        commandshelpEmbed.AddField("</config_statchannel:1187847895651725404>", "** **", true);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(commandshelpEmbed.Build()));
    }
     
    [SlashCommand("credits", "Shows credits")]
    public async Task Credits(InteractionContext ctx)
    {
        var creditsEmbed = new DiscordEmbedBuilder
        {
            Title = "Credits",
            Description = " ",
            Color = DiscordColor.Red,
        };
        int guildCount = ctx.Client.Guilds.Count;
        creditsEmbed.AddField("I'm on ", guildCount.ToString() + " servers");
        creditsEmbed.AddField("Created by: ", "BiznesBear");
        creditsEmbed.AddField("Made in: ", "C# - DSharpPlus");
        creditsEmbed.AddField("Beta tester's: ", $"Cringe2137\nDorain28029");
        creditsEmbed.AddField("About: ", $"Version: Beta testing");

        var dcserverButton = new DiscordLinkButtonComponent("https://discord.gg/c9VExDxEde", "Discord server");
        var addButton = new DiscordLinkButtonComponent("https://discord.com/api/oauth2/authorize?client_id=979004845291884584&permissions=8&scope=applications.commands%20bot", "Add me to your server");
        var rickrollButton = new DiscordLinkButtonComponent("https://youtu.be/dQw4w9WgXcQ?si=aXEKxX-SaPoSTijV", "Click me");

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(creditsEmbed.Build()).AddComponents(dcserverButton, addButton, rickrollButton));
    }

    // dev center 
    // dev center 
    // dev center 

    [SlashRequireOwner]
    [SlashCommand("dev_setactivity","Nope-you cant do it")]
    private async Task setactivity(InteractionContext ctx,
        
        [Choice("Playing","0")]
        [Choice("ListeningTo","2")]
        [Choice("Watching","3")]
        [Choice("Competeting","5")]
        [Option("type","Select type")] string activityTypeStr,
        [Option("activity", "What are you doing today")] string activityName,
        [Choice("online","1")]
        [Choice("idle","2")]
        [Choice("doNotDisturb","4")]
        [Choice("invisible","5")]
        [Option("status","status")] string status="")
    {
        int activityTypeInt = int.Parse(activityTypeStr);
        ActivityType activityType = (ActivityType)activityTypeInt;
        
        DiscordActivity activity = new DiscordActivity("",ActivityType.Streaming);
        UserStatus clientStatus = UserStatus.Online;
        DiscordClient discord = ctx.Client;
        activity.Name = activityName;
        activity.ActivityType = activityType;
        if (string.IsNullOrEmpty(status))
        {
            int statusIndex = int.Parse(status);
            clientStatus = (UserStatus)statusIndex;
        }

        await discord.UpdateStatusAsync(activity,clientStatus);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent($"Bot now {activityType} **{activityName}** ").AsEphemeral(true));
        return;
    }


    // beta functions 
    // beta functions 
    // beta functions 

    [SlashRequireOwner]
    [SlashCommand("testing","Dev test command")]
    public async Task Testing(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync("Nothing here",true);
    }


    // CONTEX MENUS
    // CONTEX MENUS
    // CONTEX MENUS
    // CONTEX MENUS



    // OTHER
    // OTHER 
    // OTHER


    public static string SettingsFilePath = "guild_settings.json";
    public GuildSettings GetGuildSettings(ulong guildId)
    {
        if (File.Exists(SettingsFilePath))
        {
            var json = File.ReadAllText(SettingsFilePath);
            return JsonConvert.DeserializeObject<GuildSettings>(json);
        }
        else
        {
            return new GuildSettings { Id = guildId, VerifyRoleId = 0, EventChannelID = 0 , Code = "",CodeContent=""};
        }
    }

    public void SaveGuildSettings(ulong guildId, GuildSettings settings)
    {
        var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
        File.WriteAllText(SettingsFilePath, json);
    }

    public string TimestampBuilder(DateTimeOffset dateTime)
    {
        var timestamp = new DateTimeOffset(dateTime.Year, dateTime.Month,dateTime.Day,dateTime.Hour,dateTime.Minute,dateTime.Second, TimeSpan.Zero);
        string formattedTimestamp = $"<t:{timestamp.ToUnixTimeSeconds()}:R>";
        return formattedTimestamp;
    }


    public async Task HandleDropdown(ComponentInteractionCreateEventArgs e)
    {
        string selectedOption = e.Values.FirstOrDefault();
        var dropdownEmbed = new DiscordEmbedBuilder
        {
            Color = DiscordColor.Cyan
        };
        string message = "";
        switch (selectedOption)
        {
            case "help_commands":
                message = "";
                dropdownEmbed.WithTitle("Commands");
                dropdownEmbed.WithDescription("</commands:1178716973597732978>");
                break;

            case "help_func":
                message = "Try out functions ! ";
                dropdownEmbed.WithTitle("Bot functions");
                dropdownEmbed.AddField("","");
                break;

            case "help_admin":
                message = "Admins tutorial";
                dropdownEmbed.WithTitle("Bot functions");
                dropdownEmbed.AddField("", "");
                break;

            case "help_setuping":
                message = "Setuping for owners";
                dropdownEmbed.WithTitle("Bot functions");
                dropdownEmbed.AddField("", "");
                break;
            default:
                message = "Don't working";
                break;
        }
        await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage,
                    new DiscordInteractionResponseBuilder().WithContent(message).AddEmbed(dropdownEmbed));
    }
}
