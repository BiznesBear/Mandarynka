using System;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

class Program
{
    static async Task Main(string[] args)
    {

        var discordClient = new DiscordClient(new DiscordConfiguration
        {
            Token = "token",
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All

        });

        var slashCommands = discordClient.UseSlashCommands();

        slashCommands.RegisterCommands<SlashCommandsModule>();
        await discordClient.ConnectAsync();

        Console.WriteLine("Enter a random key on your fucking keyboard to exit this shit...");
        Console.ReadKey();
    }
}
public class SlashCommandsModule : ApplicationCommandModule
{
    [SlashCommand("basic", "The most basic command")]
    public async Task BasicCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Now serwer are MANDARYNKOWANY! & have a MANDARYNKA role"));
    }

    [SlashCommand("berry", "Jumping berry")]
    public async Task BerryCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠐⠂⠐⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣼⣿⣿⣿⣷⣶⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣤⣿⣿⣷⣶⣦⣤⣄⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⡁⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡗⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢿⣿⣿⣿⣿⣿⡿⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣿⣿⣿⣿⣿⡿⠟⠁⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠰⠰⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠍⠭⠍⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣾⣿⣿⣿⣿⣷⣶⣶⣤⣤⣄⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⣿⣿⣶⣶⣤⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣶⣶⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠃⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠻⠿⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("mandarynka", "MANDARYNKA")]
    public async Task MandarynkaCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣤⣤⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣶⣶⣶⣶⣾⣿⣿⣿⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⣄⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⢿⣯⣿⡿⠛⡿⢿⡿⣿⣿⣿⣯⣷⣞⢯⣿⣭⣽⣯⣽⣿⢶⠄⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣄⣻⣿⣿⣿⣿⣿⣿⣟⠿⡿⣿⣿⣿⣿⣿⣿⡟⠛⠃⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠄⠀⡒⠊⠯⠍⠛⠱⠞⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣧⣚⡿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⣀⡤⣒⢉⠖⣡⢒⡴⢰⡁⠐⠃⡃⠍⠰⠁⠀⠀⠀⠀⠀⠀⢀⠠⣀⠀⣌⢈⠛⠿⣿⣿⣾⣽⣿⢿⣿⣆⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⣠⡾⣋⡬⠕⠵⡠⠣⢂⠔⠂⢌⡉⡤⢁⢦⡁⢔⠠⠂⠠⠆⠠⢊⢀⡁⡠⠑⢈⠠⣈⠒⠤⢙⡻⢻⣿⣿⣾⣿⡮⡄⠀⠀⠀\r\n⠀⠀⠀⣰⡟⠧⠞⡠⢖⢹⢰⢃⠔⡡⣨⠑⠆⢤⣡⠉⡆⠔⡀⠂⡍⢒⠠⢀⠒⠠⡇⡴⡡⠘⠲⡀⢅⠂⠄⠲⢧⠹⢻⣺⡏⣡⠏⣧⠀⠀\r\n⠀⢀⢪⡕⣧⢚⣌⠇⣫⡁⣎⠦⢒⡰⢦⠫⡈⢴⢁⢚⢱⠀⣑⠂⠌⡉⢰⠁⡌⡅⡐⡜⢂⡯⡑⢝⠢⢉⠊⡤⡑⣹⠸⣼⣻⠳⣊⢐⡣⠀\r\n⠀⡱⡮⡍⡾⢣⠇⡅⡉⣱⠧⣋⠽⣸⠍⠴⠌⠄⡊⢌⢒⠰⡄⠌⢢⡅⢨⠁⡜⠆⡃⢝⠂⡖⢉⢢⣙⠦⠓⡇⡉⢏⠇⣷⡍⢳⢶⢡⢸⣢\r\n⡐⢱⣉⣏⣽⣩⢨⡡⢛⣤⠳⣉⠊⢥⢘⡴⢈⠓⣌⢢⠌⣡⠂⢩⠰⠌⡤⠨⡑⢌⢇⡇⠳⡜⢦⡉⠷⢨⢷⡸⡱⣏⣼⢵⢩⣸⢦⣹⣻⢸\r\n⡇⣷⡏⣶⢦⠿⡚⡑⠧⡴⠋⢡⠎⣎⠸⡘⢬⠱⢪⡉⡔⣤⠋⢶⡙⢳⠍⠧⣌⣃⡶⡙⣧⡸⣴⠯⣂⠿⡈⡷⣱⣿⣾⣟⢺⢡⣞⡮⢼⢸\r\n⣑⢳⢝⣧⢺⣒⢵⣼⢮⠓⣇⢡⠆⡝⠢⣕⢎⡲⢧⠻⣳⣾⣿⣶⣙⡎⡿⢡⢼⡃⠧⡵⡜⡆⡷⣸⡋⣴⡚⣏⡞⢻⡿⢎⠿⡨⣝⠧⢫⡜\r\n⢳⣾⢸⡝⡻⣜⣚⡴⣿⣇⠳⡢⡌⣇⠣⡧⣚⢥⣣⢫⢓⠿⣿⠻⣡⡝⢫⣸⣳⣗⣳⢍⢧⢝⡞⣵⢟⡗⡿⢮⢽⣵⢞⡞⣷⣽⣋⣧⢛⠃\r\n⢸⢇⣷⣳⠟⡾⣜⢖⡥⣣⠏⡗⡱⡝⣣⠝⣎⡵⣹⢫⣻⡳⣧⣖⣽⣻⢽⡻⣼⡶⣏⡮⣷⣚⣽⣚⣿⢿⡝⣿⣳⣟⣞⣳⣫⠜⡧⠾⠎⠀\r\n⠀⢞⡼⡜⢾⢣⡏⣞⡺⡍⣧⢙⠳⣬⢳⠟⣜⡎⣟⢾⣸⢳⢖⡾⣖⣯⡗⣿⣭⡻⣶⣷⣧⣯⣷⣟⢯⣿⣻⣞⣟⣾⣽⣼⣵⡋⢔⠞⠀⠀\r\n⠀⠀⠳⡙⢮⢳⢕⡬⣹⣝⠶⡝⣳⢩⡻⢺⡌⢷⢺⡸⢧⣻⣻⣵⢿⣽⣿⣷⣯⣷⣯⣷⣫⣟⣮⣿⣿⢷⣿⣻⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀\r\n⠀⠀⠀⠈⠨⣣⠧⢷⣜⢮⣓⠝⣦⠳⣹⠆⣟⢮⡻⣝⣯⡽⣷⣿⣿⣿⣿⠿⣿⣮⡿⣷⢿⣽⣻⣷⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣷⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠛⠯⣮⣏⣯⣞⡾⣥⢻⡜⣭⡶⣹⢮⣷⢿⡝⣾⣿⣿⣿⣿⣿⣿⣟⣽⣿⡽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠂⠀⠂⠓⣯⢻⡟⣿⣷⣿⣽⣶⣽⢻⡟⣾⣿⣯⣿⣿⣿⣿⣿⣿⣿⣷⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠉⠀⠃⠉⠛⠙⠛⠻⠟⠿⢿⣿⣾⣿⣿⣿⣿⣾⣿⠳⠿⠿⠻⠛⠟⠛⠻⣿⣿⣿⣶⣿⣿⡿⠁⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢫⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠻⠟⠛⠋⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("siuuu", "Siuuuuuuu")]
    public async Task SiuCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(".                       ⣴⣿⣦\r\n                         ⢻⣿⣿⠂\r\n                      ⢀⣴⣿⣿⣀\r\n                   ⣾⣿⣿⣿⣿⣿⣿⣦\r\n               ⣴⣿⢿⣷⠒⠲⣾⣾⣿⣿⡄\r\n          ⣴⣿⠟⠁⠀⢿⣿⠁⣿⣿⣿⠻⣿⣄\r\n   ⣠⡾⠟⠁⠀⠀⠀⢸⣿⣸⣿⣿⣿⣆⠙⢿⣷⡀⠀\r\n⡿⠋⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⠀⠀⠉⠻⣿⡭\r\n                        ⢸⣿⣿⣿⣿⣿\r\n⠀                   ⣾⣿⣿⣿⣿⣿⣿⣆⠀⠀ \r\n⠀                   ⣼⣿⣿⣿⡿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⠿⠟⠀⠀⠻⣿⣿⡇⠀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⠀⢀⣾⡿⠃⠀⠀⠀⠀⠀⠘⢿⣿⡀⠀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⠀⣰⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⡀⠀⠀⠀⠀\r\n‏⠀⠀⠀⠀⢠⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣧⠀⠀⠀⠀\r\n‏⠀⠀⠀⢀⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣆⠀⠀⠀\r\n‏⠀⠀⠠⢾⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⡤"));
    }

    [SlashCommand("nope", "Send's NOPE")]
    public async Task NopeCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠄⠄⠄⠄⢀⡤⣖⣞⣮⢾⢽⣳⢯⢿⢷⣦⣄⠄⠄⠐⠄\r\n⠐⠄⠄⣴⣯⣯⢷⣻⣺⢽⣫⢾⣝⡵⡯⣾⣽⢷⣄⠄⠄\r\n⠄⢀⣼⢿⡽⣾⢯⣷⣻⣽⢽⣳⣳⢽⡺⡮⣫⢯⢿⣦⠄\r\n⠄⣼⣿⢽⡯⣿⡽⣾⡿⣞⣯⢷⢯⢯⢯⢯⡺⡪⡳⣻⠄\r\n⣴⣿⣿⣽⣟⣷⣟⣯⣿⡽⣞⣯⢿⡽⡽⡵⣝⢮⣫⣺⠄\r\n⠄⠄⠉⠉⠛⠛⠛⠛⠛⠻⠿⠿⠿⣿⣿⡿⣿⣽⣾⣾⡀\r\n⠐⡀⠢⠄⡀⠄⢀⣄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⠣\r\n⡀⠂⠈⣪⣌⡤⢾⠿⠕⢤⣤⣨⣠⢤⠡⠄⠄⡌⠄⡐⡐\r\n⠐⠈⠄⠱⣻⡻⠶⢦⠶⠯⠟⢟⢯⢳⢩⡂⡆⡇⡐⡐⢌\r\n⢁⠐⠄⠈⣾⣓⢝⣛⡛⡗⣞⣗⢕⡕⢕⠕⡸⡀⠂⠌⡂\r\n⡀⠂⡁⠄⡿⣕⢷⣻⢽⢝⢞⢮⢳⠑⠅⢑⢜⠜⣬⢐⢈\r\n⠄⢁⣀⣴⠋⠪⠳⠹⠵⠹⠘⠈⠂⠁⡐⡸⡘⣠⡳⡣⣪\r\n⣽⢟⣿⡣⠄⢸⡄⠠⠠⡠⢠⢐⠨⡐⣴⣹⡨⣞⣎⢎⢺\r\n⠏⠟⠛⠃⠄⠘⠛⠊⠊⠘⠐⠅⠇⠻⠛⠓⠛⠛⠪⠓⠹\nnope"));
    }

    [SlashCommand("gigachad", "Send's gigachad")]
    public async Task GigacahdCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠋⠉⠈⠉⠉⠉⠉⠛⠻⢿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡏⣀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿\r\n⣿⣿⣿⢏⣴⣿⣷⠀⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿\r\n⣿⣿⣟⣾⣿⡟⠁⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣷⢢⠀⠀⠀⠀⠀⠀⠀⢸⣿\r\n⣿⣿⣿⣿⣟⠀⡴⠄⠀⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣿⣿⠟⠻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠶⢴⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⣿\r\n⣿⣁⡀⠀⠀⢰⢠⣦⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⡄⠀⣴⣶⣿⡄⣿\r\n⣿⡋⠀⠀⠀⠎⢸⣿⡆⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⣿⠗⢘⣿⣟⠛⠿⣼\r\n⣿⣿⠋⢀⡌⢰⣿⡿⢿⡀⠀⠀⠀⠀⠀⠙⠿⣿⣿⣿⣿⣿⡇⠀⢸⣿⣿⣧⢀⣼\r\n⣿⣿⣷⢻⠄⠘⠛⠋⠛⠃⠀⠀⠀⠀⠀⢿⣧⠈⠉⠙⠛⠋⠀⠀⠀⣿⣿⣿⣿⣿\r\n⣿⣿⣧⠀⠈⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠟⠀⠀⠀⠀⢀⢃⠀⠀⢸⣿⣿⣿⣿\r\n⣿⣿⡿⠀⠴⢗⣠⣤⣴⡶⠶⠖⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡸⠀⣿⣿⣿⣿\r\n⣿⣿⣿⡀⢠⣾⣿⠏⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠉⠀⣿⣿⣿⣿\r\n⣿⣿⣿⣧⠈⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡄⠈⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣦⣄⣀⣀⣀⣀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠙⣿⣿⡟⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠁⠀⠀⠹⣿⠃⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⢐⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⠿⠛⠉⠉⠁⠀⢻⣿⡇⠀⠀⠀⠀⠀⠀⢀⠈⣿⣿⡿⠉⠛⠛⠛⠉⠉\r\n⣿⡿⠋⠁⠀⠀⢀⣀⣠⡴⣸⣿⣇⡄⠀⠀⠀⠀⢀⡿⠄⠙⠛⠀⣀⣠⣤⣤⠄⠀"));
    }

    [SlashCommand("wut", "What")]
    public async Task WutCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣶⣶⢶⢶⣦⣄⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢀⣤⣶⠶⠾⠶⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠋⢁⢀⣄⣀⠈⢻⣧⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⢰⡟⠃⠀⣀⣤⣤⠈⠹⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⠁⠀⠢⣾⠏⣿⡄⠈⢻⣧⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢠⣿⠁⢀⣾⠟⠁⣿⡆⠀⠘⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠀⠀⢸⡿⠀⠈⣿⡄⠈⣿⡄⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢸⣯⠐⠴⣿⡂⠀⢸⣷⠀⠀⢸⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡆⠀⣿⡇⠀⡀⣘⣿⡄⠸⣷⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢸⣧⠀⠀⠻⠗⠉⠉⠛⠀⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣇⠀⠙⠋⠉⠉⠁⠉⠁⠀⣿⡅⠀⠀⠀\r\n⠀⠀⠀⠀⣈⣿⣢⣤⣤⣤⣤⣤⣶⣶⣶⣾⣿⣤⣴⣶⣶⣦⣶⣶⣶⡶⠶⣶⢶⠶⢾⢿⣶⣶⣶⣶⣦⣤⣤⣤⣄⣿⣇⠀⠀⠀\r\n⠀⠀⣴⡿⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠹⠟⠛⠻⠿⢷\r\n⠀⣸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢰⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢸⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⡿⢿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣶⣿⣿⣻⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠈⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⠛⠉⠀⠀⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡤⠤⢠⣶⣶⣴⣤⣤⣤⣤⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⢿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⠃⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠨⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⢸⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢆⠀⠀⠀⠈⠉⠉⠉⠛⠉⠉⠉⠀⠀⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠒⠠⠠⠀⠠⠤⠤⠤⠤⠤⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("trollface", ">:)")]
    public async Task TrollfaceCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣴⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣦⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣿⠟⠉⠁⠀⠀⠀⠀⠀⠀⣀⣀⠠⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠙⠛⠿⠿⣿⣷⣶⣦⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠋⠀⠀⠀⠀⠀⠀⣀⠤⠖⠋⣁⣀⠤⠤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠤⠤⠤⠤⢌⡙⠻⢿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠁⠀⠀⠀⠀⣠⠴⠋⣁⡤⠖⢋⣩⡤⠤⠒⠒⠒⠒⠒⠲⣖⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⣤⣤⣄⠀⠀⠁⠀⠀⠈⠙⢿⣶⡄⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⢠⣾⠟⠀⠀⠀⠀⠴⠋⠁⡠⠞⣁⡴⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⡆⠀⠀⠀⠀⠀⠀⠀⠈⢉⡿⠁⠀⠀⠀⠀⠈⠙⢦⡄⠀⠀⠀⠀⠀⠹⣿⡄⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢠⣿⡟⠀⠀⠀⠀⠀⠀⠠⠞⢠⠞⠉⠀⠀⣀⣀⣀⣤⣤⣤⣄⣀⡀⠀⠀⠸⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠹⡄⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢀⣴⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣿⣿⣿⣿⣿⣿⡿⠛⠻⢿⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⣀⣤⣤⣤⣤⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠹⣿⣄⠀⠀⠀\r\n⠀⠀⢀⣴⣿⣿⡿⠯⠭⠥⠤⠀⠀⠀⠴⠶⠋⠀⢾⣿⣵⣾⣿⡿⠿⢿⣿⣷⣶⣤⣀⠈⢻⣿⣧⠀⠀⠀⠀⢀⣀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠀⠶⠶⠦⠴⠤⣤⡈⠻⣿⣦⠀\r\n⠀⣴⣿⢟⡟⠁⠀⣠⣴⣶⡿⠿⢿⣶⣤⣄⡘⠁⠀⠀⠀⠀⠀⣠⣾⡟⠀⠀⠈⠛⠻⢿⣿⠟⠁⠀⠀⠀⠀⠘⠻⢿⣿⠿⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠶⢤⡙⢦⡌⣿⣇\r\n⣼⡿⠁⡼⠀⢀⣾⡿⠋⠁⠀⣰⡆⠈⠙⠻⠿⣷⣶⣶⣶⣶⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⣤⡀⠀⣠⣶⣾⠿⠿⣿⣶⡄⢹⠀⢹⣸⣿\r\n⣿⠃⠀⡇⠀⣼⡿⠁⠀⠀⣠⣿⣿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣷⣄⡀⠀⠀⠀⠻⠿⠿⠿⠟⠀⣼⠀⠀⠉⠁⢸⠄⢸⢻⣿\r\n⣿⡄⠀⣧⠀⢻⣧⠠⠶⠿⣿⣿⡀⠙⠛⠿⣿⣦⣤⣀⡀⠀⠀⠠⠤⠤⠤⠴⠚⢣⣿⠟⠛⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣷⣄⠀⠀⠀⠀⠀⠀⢰⣿⣇⠀⠀⣠⠞⠀⡼⣼⡟\r\n⢻⣿⡀⢸⡀⠘⣿⡆⠀⠀⠈⣿⣷⡄⠀⠀⠈⠙⢿⣿⣿⣷⣶⣤⣄⣀⠀⠀⠀⠸⣿⣦⠀⣿⠿⠿⠿⠖⠀⠀⠀⠀⠀⣴⣿⠿⠛⠋⠓⠲⢤⡀⠀⢀⣾⣿⣿⡇⢀⣠⠴⠚⣱⣿⠃\r\n⠈⠻⣷⣄⠙⠶⣌⡁⠀⠀⠀⠙⣿⣿⣷⣦⣄⡀⢸⣿⡀⠀⠉⠙⠛⠿⠿⣷⣶⣦⣌⣛⣀⠀⠀⠀⠀⠀⠀⠸⣿⣶⣿⠟⠁⠀⠀⠀⠀⠀⣀⣥⣶⣿⢿⣷⣿⣇⠀⠀⠀⣴⣿⠃⠀\r\n⠀⠀⠙⢿⣷⣦⠄⠀⠀⠀⠀⠀⠈⢿⣿⡙⠛⢿⣿⣿⣿⣦⣀⣀⠀⠀⠀⠀⣿⡟⠛⠛⠿⠿⢿⣷⣶⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣶⣿⣿⡿⠛⢻⣿⠈⢿⣿⣿⠀⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠙⣿⣦⠀⠀⠀⠀⠀⠀⠀⠻⣿⣆⠀⢹⣿⠿⢿⣿⣿⣿⣶⣦⣴⣿⡁⠀⠀⠀⠀⠀⠀⢻⣿⠉⠉⠉⠉⢻⣿⠋⠉⠉⠉⠙⣿⡆⠀⢸⣿⣤⣼⣿⣿⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⢿⣧⡀⠀⠀⠀⠀⠀⠀⠘⢿⣷⣼⡿⠀⠀⠀⠉⠛⠿⢿⣿⣿⣿⣿⣶⣶⣶⣤⣤⣾⣿⣦⣤⣤⣤⣾⣿⣦⣤⣶⣶⣶⣿⣷⣾⣿⣿⣿⣿⣿⣿⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠈⢿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣷⣄⡀⠀⠀⠀⠀⢠⣿⡇⠉⠛⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣶⣄⡀⢀⣾⡿⠀⠀⠀⠀⠀⠀⠈⣿⡏⠙⠛⠛⠛⢻⣿⣿⠿⠿⣿⣿⡿⠟⢻⣿⠟⣿⣿⣱⣿⠃⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⣿⣦⡀⠠⣄⡀⠀⠦⣀⡀⠀⠉⠻⢿⣿⣿⣄⣀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀⢸⣿⠁⠀⠀⣼⣿⠀⢠⣿⠏⢀⣻⣷⣿⠃⠀⠀⠀⠀⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣦⣄⡙⠳⠤⣀⡙⠓⠤⣄⡀⠀⠉⠛⠻⠿⠿⢷⣶⣤⣴⣿⣧⣤⣤⣤⣤⣿⣿⣤⣤⣼⣿⣧⣴⣾⣿⠿⠿⠟⠋⠀⠀⠀⠀⠀⠀⣿⡆⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⢿⣶⣤⣈⠙⠒⠤⣌⡉⠓⠲⣤⣄⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⢀⣴⠆⠀⠀⡄⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⣿⣶⣤⣀⠉⠙⠲⠦⢌⣉⣑⡲⠦⢤⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⢀⣀⡠⠶⠋⠀⠀⠀⣰⠃⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⢿⣷⣤⣄⡀⠀⠈⠉⠙⠓⠒⠦⠤⠤⢄⣀⣀⣀⣈⣉⣉⣉⢉⠉⠉⠁⠀⠀⠀⣀⣠⠴⠋⠁⠀⠀⠀⣿⡇⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⢿⣷⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⣴⣿⠃⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠻⠿⣿⣶⣶⣶⣤⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠁⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠛⠿⠿⣷⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣴⣾⡿⠛⠁⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("amogus", "SUS")]
    public async Task AmogusCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⣠⣤⣄⣤⣤⣤⣠⣄⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡿⠿⠋⠙⠋⠙⠋⠉⠉⠛⠛⠛⠿⢿⣷⣦⣀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⢀⡉⠿⣿⣷⡀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⠀⠀⡀⢀⣠⣀⣀⣀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠻⣿⣿⣄⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⡇⠀⣠⣿⣿⡿⠿⠿⠿⠿⠿⠿⠿⣿⣿⣧⡀⢀⠀⢸⣿⣿⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡟⠀⠀⣿⣿⣿⣄⡀⠘⠢⣄⣀⣀⣀⠀⠈⣿⣿⡆⠀⠀⢹⣿⣧⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠃⠀⠀⠹⢿⣿⣽⣿⡶⣶⢶⣶⣾⣾⣿⣿⣿⠟⠁⠀⠀⠈⢹⣿⡄⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⡯⠀⠀⠆⠀⠀⠙⠛⠿⠿⠿⠿⠿⠟⠛⠛⠉⠁⠀⠀⠀⠀⠀⠸⣿⣇⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣯⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡿⠀⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡗\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⠀⠃⠀⠀⠀⠀⣠⣤⣶⣶⣶⣶⣶⣶⣶⣾⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡏⠈⠀⠀⠀⠠⣼⣿⢟⠉⠀⠀⠀⠀⠀⠀⠀⠙⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⠀⠀⢀⣀⣄⡀⠀⠀⣸⣿⡃⠀⠀⠀⠀⠈⢿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠀⣠⣶⣿⡿⠿⠿⠿⢿⣿⡏⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣇\r\n⣠⣿⡟⠉⠀⠀⠀⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏\r\n⠘⢻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⡏⠀⠀⠀⠀⣀⣤⣤⣴⣾⣿⡇⠂⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇\r\n⠈⠀⠙⢿⣿⣶⣤⣤⣤⣤⣤⣤⣴⣶⣾⣿⡿⠋⠁⠀⠀⠀⣶⣾⡟⠟⠉⠀⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠃\r\n⠀⠀⠀⠀⠀⠉⠙⠛⠛⠋⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠰⣿⣏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣾⡿⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣷⣦⣤⣀⣀⣀⣀⣀⣀⣴⣤⣴⣾⡿⠟⠉⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠛⠛⠛⠛⠛⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("catgun", "Send's cat gun ")]
    public async Task CatgunCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⠟⠋⠀⠀⠹⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⡾⠟⠁⠀⠀⠀⠀⠀⢻⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⡿⠛\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⡿⠋⠁⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣶⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣿⣿⠿⠿⣶⣶⣦⣤⣴⣿⠟⠁⠀⠀⠀⢀⡼\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡟⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⢠⠞⠁⡴⠋⠀⠀⢀⡴⠋⢈⡿⠛⠁⠀⠀⠀⠀⢀⠎⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⡧⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠋⠀⡜⠀⠀⠀⣠⠋⠀⢠⠞⠀⠀⠀⠀⠀⠀⠀⠼⠤⡄\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣄⡼⠁⠀⠀⢰⠃⠀⣠⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠔⠁\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣶⢿⣿⠟⠀⠀⠀⠀⠀⣠⣤⣄⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠘⠷⠴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢦\r\n⠀⠀⠀⠀⠀⣰⡟⠛⢿⣶⣤⣼⡇⠀⠈⠀⠀⠀⠀⢠⣾⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⢀⣴⡶⠿⠿⠀⠀⠘⠿⣿⣿⣷⣦⡀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠇⠀⣀⡤⠤⠤⠤⠤⣀⡀⠀⠀⠀⠀⢀⣶⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀\r\n⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠙⢦⣉⠻⢿⣷⣦⣀⠀⠘⠻⠿⠟⠋⡠⢾⠁⠀⠀⠀⠀⠀⠀⠈⠐⠄⠀⠀⢸⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀\r\n⣿⡇⠀⢀⡾⢻⣿⣷⡀⠀⠀⢰⠌⣑⠦⣌⠛⠿⣷⣦⣀⠀⠀⢰⠁⠘⣄⠀⢀⠶⡀⠀⠀⢀⡄⠈⡆⠀⠘⢿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀\r\n⣿⠃⠀⢸⣇⣿⣿⣿⡇⠀⠀⢸⠀⠈⠙⠺⢽⣦⣌⡙⠻⣷⣦⣄⠀⠀⠀⠉⠀⠀⠙⠒⠒⠉⠀⠀⢱⠀⠀⠀⠙⠛⠛⠉⠀⠀⠀⠀⠀⠀\r\n⣿⠀⠀⠀⠙⠿⠿⠋⠀⠀⠀⢸⠀⠀⠀⠀⠀⠈⠙⠂⠀⠀⣿⠻⣿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡄⠀⠀⠀⢀⣄⠀⢀⡤⠒⠺⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⢹⠉⡿⢿⣦⣤⣶⣶⣦⣤⡐⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⡇⠀⣦⡀⠘⠛⢀⡼⠀⠀⢠⠀⠈⡗⣦⣄⡀⠀⠀⠀⠀⣿⠀⢸⠀⡇⢸⡏⢹⠿⣄⡉⠛⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⣿⣧⣀⠀⠉⠓⠚⠉⠀⣠⣤⣤⣀⠀⡇⣇⢸⠉⡗⠦⢄⣀⢻⣦⣼⡀⡇⢸⠀⢸⠀⣿⢉⠒⠾⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢻⣿⣌⡙⠲⢤⣴⠶⠚⠧⣌⡛⠿⣿⣷⣷⣸⠀⡇⠀⠀⠈⠙⠺⣝⡻⢿⣾⣦⣸⠀⣿⠀⠉⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⠙⠻⢿⣶⣬⣙⣶⣤⣈⠙⠳⢤⣉⡛⠿⣷⣷⣄⡀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣷⣿⠀⠀⠀⠀⢿⡇⠀⠀⠀⠀⠠⡀⠀⠀⠀⢀⣀⣤\r\n⠀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣿⣧⣄⣀⡈⠙⠳⢦⣍⠛⢿⣷⣦⣄⠀⠀⠀⠀⠀⠈⠙⠻⢤⡀⠀⠀⢸⡇⠐⢦⡀⠀⢀⡌⠲⣄⣠⡼⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⣿⠟⠛⠛⠛⠷⢶⣌⣙⡶⠬⠷⠞⠛⠳⠶⠶⣦⣤⣀⠀⠀⠉⠓⣶⣾⣿⠀⠀⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡇⠀⠀⠀⠀⠀⠀⣿⠋⠀⠀⠀⣠⠔⠁⠀⠀⠀⠉⠻⢷⣦⡀⢀⣿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⢀⠜⠁⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣾⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠿⠀⠀⠀⠀⠀⠀⠀⠻⠦⠠⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠮⠤⠈⠻⠷⠤⠤⠤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀"));
    }
    [SlashCommand("facepalm", "The most basic command")]
    public async Task FacepalmCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡏⠀⣽⠶⣄⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠁⡇⠀⡏⠀⣽⣄⡀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠀⡇⠀⡇⠀⡏⠈⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣼⠀⡇⠀⠑⠀⡇⠀⣿⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡇⣽⠀⠛⠀⠀⠀⠀⠀⢻⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⣿⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣤⡤⠤⢤⣤⣤⣄⡀⣀⡀⠀⠀⢀⣸⣷⣇⣀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⠖⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⣿⡷⠻⣏⣀⣠⠌⠙⢷⡀⠀⠀⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡶⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠃⠀⠉⠀⡼⠀⠀⠈⢿⡀⠀⠀⢀⣼⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠸⠷⠤⣄⣀⣼⠗⠚⠛⠋⠁⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⡟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⢀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣈⣙⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣄⠀⠀⠀⣼⠀⠀⠀⢀⡴⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡦⢤⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣯⣻⡶⣤⣹⣤⣄⣠⡎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⡴⠶⢖⣲⣶⠞⠋⠁⠀⠀⠈⠉⢉⣬⢿⡋⠉⠁⠀⠀⠀⠀⠀⠀⠀⣠⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⣀⡴⠚⢉⣠⡴⠞⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⡞⠁⠀⠉⠀⠀⠀⠀⠀⠀⠀⢀⡼⢯⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢀⣴⠞⢁⣴⠞⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡇⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠋⠀⢸⡏⠉⠙⠓⠶⣤⣀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀\r\n⠀⠀⠀⣠⡞⣡⠾⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⠞⠉⠉⠂⠀⠀⠀⠀⠀⠀⣰⠋⠀⠀⢠⠟⠀⠀⠀⠀⠀⠀⠉⠛⠛⠛⠛⠉⠉⠉⠉⠋⠉⠉\r\n⠀⠀⣰⠏⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⠞⢹⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⡼⠃⠀⣠⡴⠋⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⣰⠏⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠾⣯⡀⠀⠘⢧⣀⠀⠀⠀⢀⣀⣤⣾⣯⡤⠶⠛⠉⠀⠀⠀⠀⠀⠀⢀⡔⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠶⠋⠁⠀⠈⠻⣄⠀⠀⠈⠙⠛⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠸⣧⡀⠀⠀⠀⠀⠀⠀⣀⡴⠟⠁⠀⠀⠀⠀⠀⠀⠙⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠈⠙⠓⠶⠶⠶⠶⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠒⠚⣿⠛⠛⠛⠛⠛⠛⠛⠛⠛\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"));
    }

    [SlashCommand("hello", "Send's anti normal hello text")]
    public async Task HelloCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("█░█ █▀▀ █░░ █░░ █▀█\r\n█▀█ ██▄ █▄▄ █▄▄ █▄█"));
    }

    [SlashCommand("send", "Send's your messege from bot")]
    public async Task SendCommand(InteractionContext ctx, [Option("message", "enter your message here")] string message)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"{message}"));
    }

    [SlashCommand("annoucment", "Send's your custom embed")]
    public async Task AnnoucmentCommand(InteractionContext ctx,
    [Option("title", "Title of your embed (text)")] string title,
    [Option("description", "Description of your embed (text)")] string description,
    [Option("thumbnail", "Miniature of your embed (url)")] string thumbnail = null,
    [Option("footer", "Footer of your embed (text)")] string footer = null,
    [Option("imageurl", "Image of your embed (url)")] string imageUrl = null,
    [Option("field1", "Separe title & description with ;| Example: My Title;Here is my description")] string field1 = null,
    [Option("field2", "Separe title & description with ;| Example: My Title;Here is my description")] string field2 = null,
    [Option("field3", "Separe title & description with ;| Example: My Title;Here is my description")] string field3 = null,
    [Option("field4", "Separe title & description with ;| Example: My Title;Here is my description")] string field4 = null,
    [Option("field5", "Separe title & description with ;| Example: My Title;Here is my description")] string field5 = null,
    [Option("color", "Set's the annoucment color with geting a role color")] DiscordRole color = null)
    {
        if (!ctx.Member.Permissions.HasPermission(Permissions.Administrator)) return;
        var annoucmentEmbed = new DiscordEmbedBuilder
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
            annoucmentEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field2))
        {
            var fieldStrings = field2.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            annoucmentEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field3))
        {
            var fieldStrings = field3.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            annoucmentEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field4))
        {
            var fieldStrings = field4.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            annoucmentEmbed.AddField(name, value, false);
        }
        if (!string.IsNullOrEmpty(field5))
        {
            var fieldStrings = field5.Split(';');
            string name = fieldStrings[0];
            string value = fieldStrings[1];
            annoucmentEmbed.AddField(name, value, false);
        }

        if (!string.IsNullOrEmpty(thumbnail)) annoucmentEmbed.WithThumbnail(thumbnail);
        if (!string.IsNullOrEmpty(footer)) annoucmentEmbed.WithFooter(footer);
        if (!string.IsNullOrEmpty(imageUrl)) annoucmentEmbed.WithImageUrl(imageUrl);
        if (color != null) annoucmentEmbed.WithColor(color.Color);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(annoucmentEmbed.Build()));
    }

    [SlashCommand("dice", "Return the random number (defalut from 1 to 6)")]
    public async Task RandomCommand(InteractionContext ctx,
        [Option("min", "Minimum value (default: 1)")] string minStr = "1",
        [Option("max", "Maximum value (default: 6)")] string maxStr = "6")
    {
        int min = int.Parse(minStr);
        int max = int.Parse(maxStr);
        Random random = new Random();
        int randomNumber = random.Next(min, max + 1);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,new DiscordInteractionResponseBuilder().WithContent($"Dice saying: {randomNumber}"));
    }

    [SlashCommand("coin","Returns a head or a eagle")]
    public async Task CoinCommand(InteractionContext ctx)
    {
        string result = "";
        Random random = new Random();
        int randomNumber = random.Next(1,3);
        if(randomNumber == 1) { result = "Head"; } else { result = "Eagle"; }
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Your coin: {result}"));
    }

    [SlashCommand("iq", "Returns your small iq")]
    public async Task IqCommand(InteractionContext ctx)
    {
        Random random = new Random();
        int iq = random.Next(-100, 200);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Your iq: {iq}"));
    }

    // help center
    [SlashCommand("commands", "Show's all commands")]
    public async Task Commands(InteractionContext ctx)
    {
        var commandshelpEmbed = new DiscordEmbedBuilder
        {
            Title = "Command's list",
            Description = "Commands for Mandarynka bot.",
            Color = DiscordColor.Orange,
        };

        commandshelpEmbed.AddField("BASIC COMMANDS", "----------");

        commandshelpEmbed.AddField("/basic", "Send's basic message", inline: true);
        commandshelpEmbed.AddField("/send", "Send's your message", inline: true);
        commandshelpEmbed.AddField("/send_dm", "Send's your message to the user", inline: true);
        
        commandshelpEmbed.AddField("/ping", "Show's bot ping", inline: true);
        commandshelpEmbed.AddField("/server_info", "Show's info about server", inline: true);
        commandshelpEmbed.AddField("/user_info", "Show's info about user", inline: true);
        commandshelpEmbed.AddField("/verify", "Verify yourself", inline: true);

        commandshelpEmbed.AddField("FUN ", "----------");

        commandshelpEmbed.AddField("/dice", "Send's random number (defalut: from 1 to 6)", inline: true);
        commandshelpEmbed.AddField("/rickroll", "Send's user DM with rickroll >:)", inline: true);
        commandshelpEmbed.AddField("/coin", "Send's eagle or head", inline: true);
        commandshelpEmbed.AddField("/iq", "Return's your very small iq", inline: true);
        commandshelpEmbed.AddField("/random_gif", "Send's random gif", inline: true);

        commandshelpEmbed.AddField("ADMIN ", "----------");

        commandshelpEmbed.AddField("/clear", "Clear amount of messeges", inline: true);
        commandshelpEmbed.AddField("/annoucment", "Send's annoucment", inline: true);
        commandshelpEmbed.AddField("/copy_role", "Copy role", inline: true);
        commandshelpEmbed.AddField("/config_botname", "Set's new server bot name", inline: true);
        commandshelpEmbed.AddField("/config_resetbotname", "Set's new server bot name", inline: true);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(commandshelpEmbed.Build()));
    }

    [SlashCommand("arts", "Show's art's commands")]
    public async Task Arts(InteractionContext ctx)
    {
        var artsEmbed = new DiscordEmbedBuilder
        {
            Title = "Art's list",
            Description = "Arts from Mandarynka bot.",
            Color = DiscordColor.Magenta,
        };


        artsEmbed.AddField("ARTS ", "----------");

        artsEmbed.AddField("/amogus", "Send's amogus art",inline:true);
        artsEmbed.AddField("/gigachad", "Send's gigachad art", inline: true);
        artsEmbed.AddField("/wut", "Send's wut art", inline: true);
        artsEmbed.AddField("/facepalm", "Send's facepalm art", inline: true);
        artsEmbed.AddField("/siuuu", "Send's siuuu art", inline: true);
        artsEmbed.AddField("/nope", "Send's nope art", inline: true);
        artsEmbed.AddField("/trollface", "Send's trollface art", inline: true);
        artsEmbed.AddField("/berry", "Send's berry art", inline: true);
        artsEmbed.AddField("/mandarynka", "Send's mandarynka art", inline: true);


        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(artsEmbed.Build()));
    }

    [SlashCommand("server_info", "Server info")]
    public async Task ServerInfoCommand(InteractionContext ctx)
    {
        var serverinfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"{ctx.Guild.Name}",
            Color = DiscordColor.Green,
        };

        serverinfoEmbed.AddField("Server name:", $"{ctx.Guild.Name}");
        serverinfoEmbed.AddField("Owner:", $"{ctx.Guild.Owner.DisplayName}");
        serverinfoEmbed.AddField("Member's count:", $"{ctx.Guild.MemberCount}");


        serverinfoEmbed.WithImageUrl($"{ctx.Guild.IconUrl}");

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(serverinfoEmbed.Build()));
    }

    [SlashCommand("user_info", "Pokaż informacje o użytkowniku.")]
    public async Task UserInfoCommand(InteractionContext ctx,
    [Option("user", "User | Exaple: @Mandarynka")] DiscordUser user)
    {
        var userinfoEmbed = new DiscordEmbedBuilder
        {
            Title = $"Info about {user.Username}",
            Color = DiscordColor.Green, 
        };

        userinfoEmbed.AddField("User name", user.Mention, false);
        userinfoEmbed.AddField("User ID", user.Id.ToString(), false);
        userinfoEmbed.AddField("Avatar URL", user.AvatarUrl, true);
        userinfoEmbed.AddField("Is bot ?", user.IsBot.ToString(), false);

        userinfoEmbed.WithThumbnail(user.GetAvatarUrl(ImageFormat.Auto));

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(userinfoEmbed.Build()));
    }

    [SlashCommand("clear", "Clear a specified number of messages")]
    public async Task ClearCommand(InteractionContext ctx,
        [Option("amount", "Number of messages to clear")]string amountStr)
    {
        if (!ctx.Member.Permissions.HasPermission(Permissions.ManageMessages))
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent("You don't have permission to manage messages."));
            return;
        }
        int amount = int.Parse(amountStr);

        amount = Math.Min(amount, 100); 

        var channel = ctx.Channel;

        var messages = await channel.GetMessagesAsync(amount);

        await channel.DeleteMessagesAsync(messages);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder().AsEphemeral(true)
                .WithContent($"Cleared {amount} messeges"));
    }

    [SlashCommand("random_gif", "Send's random gif")]
    public async Task SendGifCommand(InteractionContext ctx)
    {
        string randomGifUrl = GetRandomGifUrl();
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"{randomGifUrl}"));
    }

    [SlashCommand("config_botname", "Change bot name")]
    public async Task ConfigureBotNameCommand(InteractionContext ctx, [Option("newname", "New bot name")] string newNickname)
    {
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];

        if (ctx.Member.Permissions.HasPermission(Permissions.Administrator))
        {
            var oldNickname = botMember.Nickname;

            await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = newNickname);

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                .WithContent($"Chaned bot name '{oldNickname}' for '{newNickname}'."));
        }
        else
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent("You don't have permission to manage messages."));
        }

    }
    [SlashCommand("config_resetbotname", "Reset bot name")]
    public async Task ResetBotNameCommand(InteractionContext ctx)
    {
        var guild = ctx.Guild;
        var botMember = guild.Members[ctx.Client.CurrentUser.Id];

        if (ctx.Member.Permissions.HasPermission(Permissions.Administrator))
        {
            var oldNickname = botMember.Nickname;

            await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = botMember.Username);

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
                .WithContent($"Reset bot nickname form {oldNickname}"));
        }
        else
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent("You don't have permission to manage messages."));
        }
    }
    private string GetRandomGifUrl()
    {
        Random rand = new Random();
        string[] gifBase =
        {
            "https://tenor.com/view/tangerine-amusable-pet-petpet-gif-24326973",
            "https://tenor.com/view/your-mom-spy-tf2-team-fortress2-sheesh-gif-21838783",
            "https://tenor.com/view/big-brain-genius-math-mega-brain-tek-gif-27194141",
            "https://tenor.com/view/freddy-dance-freddy-dance-gif-20078036",
            "https://tenor.com/view/tf2-engi-jr-engineer-fortnite-gif-8047413327940476912",
            "https://tenor.com/view/memes-dancing-stone-thumbs-up-gif-15282741",
            "https://tenor.com/view/sus-gif-24048467",
            "https://tenor.com/view/ip-i-have-your-ip-address-address-ip-address-dox-gif-19850626",
            "https://tenor.com/view/angry-panda-mascot-mad-%E7%8B%82%E8%BA%81-gif-3456638",
            "https://tenor.com/view/teddy-bear-cute-gif-15253299",
            "https://tenor.com/view/rickroll-rick-roll-gif-gif-23727670"
        };
        var resultInt = rand.Next(gifBase.Length);

        return gifBase[resultInt];
    }
    [SlashCommand("ping", "Show's bot ping")]
    public async Task PingCommand(InteractionContext ctx)
    {
        var ping = ctx.Client.Ping;
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .WithContent($"Pong! : {ping}ms"));
    }

    [SlashCommand("verify", "Be verified")]
    public async Task VerifyUser(InteractionContext ctx)
    {
        var verifyRole = ctx.Guild.Roles.Values.FirstOrDefault(role => role.Name == "Verified");

        if (verifyRole == null)
        {
            await ctx.Guild.CreateRoleAsync("Verified", color:DiscordColor.DarkGreen);
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent("You aren't verifed jet. Please try again (type: /verify)"));
            return;
        }
        await ctx.Member.GrantRoleAsync(verifyRole);

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true)
            .WithContent("Now you are verified"));
        await ctx.DeferAsync();
    }


    [SlashCommand("credits", "Show's credits")]
    public async Task Credits(InteractionContext ctx)
    {
        var creditsEmbed = new DiscordEmbedBuilder
        {
            Title = "Credits",
            Description = " ",
            Color = DiscordColor.Red,
        };
        int guildCount = ctx.Client.ShardCount;

        creditsEmbed.AddField("I'm on ", guildCount.ToString() + " servers");

        creditsEmbed.AddField("Created by: ", "BiznesBear");
        creditsEmbed.AddField("Made in: ", "C# - DSharpPlus");
        creditsEmbed.AddField("Beta tester's: ", $"Cringe2137\nDorain28029");


        var dcserverButton = new DiscordLinkButtonComponent("https://discord.gg/c9VExDxEde", "Discord server");
        var addButton = new DiscordLinkButtonComponent("https://discord.com/api/oauth2/authorize?client_id=979004845291884584&permissions=8&scope=applications.commands%20bot", "Add me to your server");
        var rickrollButton = new DiscordLinkButtonComponent("https://youtu.be/dQw4w9WgXcQ?si=aXEKxX-SaPoSTijV", "Click me");

        //creditsEmbed.WithUrl("https://discord.gg/c9VExDxEde");
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(creditsEmbed.Build()).AddComponents(dcserverButton,addButton,rickrollButton));
    }


    [SlashCommand("rickroll", "Send a direct message to a user.")]
    public async Task SendRickroll(InteractionContext ctx, [Option("user", "Rickroll that user")] DiscordUser user)
    {
        var server = ctx.Guild;
        var member = await server.GetMemberAsync(user.Id);
        await member.SendMessageAsync("https://youtu.be/dQw4w9WgXcQ?si=aXEKxX-SaPoSTijV");
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Sended >:)").AsEphemeral(true));
    }

    [SlashCommand("send_dm", "Send a direct message to a user.")]
    public async Task SendDM(InteractionContext ctx, [Option("user", "Sending message to ")] DiscordUser user, [Option("message","Enter a text")] string dmMessage)
    {
        var server = ctx.Guild;
        var member = await server.GetMemberAsync(user.Id);
        await member.SendMessageAsync($"{dmMessage}");
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Sended >:)").AsEphemeral(true));
    }

    [SlashCommand("copy_role", "Copy a role (admin only)")]
    public async Task CopyRole(InteractionContext ctx, [Option("role", "Role to copy")] DiscordRole role, [Option("name", "Name for the copied role")] string roleName)
    {
        if (!ctx.Member.Permissions.HasPermission(Permissions.Administrator)) return;

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
}
