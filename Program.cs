using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.EventArgs;


class Program
{
    static async Task Main(string[] args)
    {
        // Inicjalizacja klienta Discord i modułu obsługującego polecenia slash
        var discordClient = new DiscordClient(new DiscordConfiguration
        {
            Token = "OTc5MDA0ODQ1MjkxODg0NTg0.GsJwpe.90S6qAaaygAiUeaAZnp0KHpJNmcH0GvjdgI5oA",
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.Guilds | DiscordIntents.GuildMessages
        });

        var slashCommands = discordClient.UseSlashCommands();

        slashCommands.RegisterCommands<SlashCommandsModule>();

        // Obsługa zdarzenia po zalogowaniu bota
        //discordClient.Ready += ClientOnReady;
        
        // Logowanie bota
        await discordClient.ConnectAsync();

        // Oczekiwanie na zamknięcie aplikacji
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
    public async Task FacepalCommand(InteractionContext ctx)
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

    [SlashCommand("dice", "Return the random number (defalut from 1 to 6)")]
    public async Task RandomCommand(InteractionContext ctx,
        [Option("min", "Minimum value (default: 1)")] string minStr = "1",
        [Option("max", "Maximum value (default: 6)")] string maxStr = "6")
    {
        // Sprawdzenie, czy min i max są w prawidłowym zakresie

        int min = int.Parse(minStr);
        int max = int.Parse(maxStr);
        // Generowanie losowej liczby w podanym zakresie
        Random random = new Random();
        int randomNumber = random.Next(min, max + 1);

        // Wysłanie wyniku jako wiadomość slash
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
    public async Task iq(InteractionContext ctx)
    {
        Random random = new Random();
        int iq = random.Next(-100, 200);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Your iq: {iq}"));
    }

    [SlashCommand("help", "All commands - help center")]
    public async Task HelpCommand(InteractionContext ctx)
    {
        // Tworzenie obiektu DiscordEmbedBuilder
        var embed = new DiscordEmbedBuilder
        {
            Title = "Help - Commands list",
            Description = "All commands from Mandarynka bot.",
            Color = DiscordColor.Orange, // Kolor ramki
        };

        // Dodawanie pól do embed
        embed.AddField("/help", "List of all commands");
        embed.AddField("/basic", "Start basic command");
        embed.AddField("/dice", "Returns random number");
        embed.AddField("/clear", "Clear amount of messeges");
        embed.AddField("/iq", "Return's your small iq");
        embed.AddField("/coin", "Return's head or eagle");
        embed.AddField("/mandarynka", "Send's mandarynka art");
        embed.AddField("/gigacahd", "Send's gigachad art");
        embed.AddField("/nope", "Send's enginner tf2 art");
        embed.AddField("/ohitsyours", "Send's Oh it's your art");
        embed.AddField("/siuuu", "Send's siuu art");
        embed.AddField("/wut", "Send's wut the hel art");
        embed.AddField("/send", "Send's your message form bot");
        embed.AddField("/hello", "Send's special hello message form bot");
        

        // Dodawanie obrazka do embed
        embed.WithImageUrl("https://www.ladne-rzeczy.com.pl/wp-content/uploads/2023/01/Zabawna-Mandarynka-20-cm-550x550.jpg");

        // Wysłanie embed jako odpowiedzi na komendę slash
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(embed.Build()));
    }


    [SlashCommand("serverinfo", "Server info")]
    public async Task ServerInfo(InteractionContext ctx)
    {
        // Tworzenie obiektu DiscordEmbedBuilder
        var embed = new DiscordEmbedBuilder
        {
            Title = $"{ctx.Guild.Name}",
            Color = DiscordColor.Green,
        };

        embed.AddField("Server name:", $"{ctx.Guild.Name}");
        embed.AddField("Owner:", $"{ctx.Guild.Owner.DisplayName}");
        embed.AddField("Member's count:", $"{ctx.Guild.MemberCount}");


        embed.WithImageUrl($"{ctx.Guild.IconUrl}");

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(embed.Build()));
    }

    [SlashCommand("clear", "Clear a specified number of messages")]
    public async Task ClearCommand(InteractionContext ctx,
        [Option("amount", "Number of messages to clear")]
        string amountStr)
    {
        // Upewnij się, że użytkownik ma odpowiednie uprawnienia do zarządzania wiadomościami
        if (!ctx.Member.Permissions.HasPermission(Permissions.Administrator))
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AsEphemeral(true)
                    .WithContent("You don't have permission to manage messages."));
            return;
        }

        int amount = int.Parse(amountStr);
        // Ogranicz liczbę wiadomości do usuwania
        amount = Math.Min(amount, 100); // Discord ogranicza usuwanie do 100 wiadomości naraz

        var channel = ctx.Channel;

        var messages = await channel.GetMessagesAsync(amount);

        await channel.DeleteMessagesAsync(messages);
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
            new DiscordInteractionResponseBuilder().AsEphemeral(true)
                .WithContent($"Cleared {amount} messeges"));
        //await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
        // new DiscordInteractionResponseBuilder()
        //   .WithContent($"Cleared {messages} messeges"));
    }


    [SlashCommand("randommeme", "Send's random meme")]
    public async Task SendMemeCommand(InteractionContext ctx)
    {
        // Tutaj dodaj logikę do pobrania losowego mema z bazy memów
        string randomMemeUrl = GetRandomMemeUrl(); // Załóżmy, że masz funkcję do pobierania URL-a losowego mema

        var embed = new DiscordEmbedBuilder
        {
            Title = "That's your random meme",
            ImageUrl = randomMemeUrl,
            Color = DiscordColor.Teal
        };

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AddEmbed(embed));
    }

    [SlashCommand("randomgif", "Send's random gif")]
    public async Task SendGifCommand(InteractionContext ctx)
    {
        // Tutaj dodaj logikę do pobrania losowego mema z bazy memów
        string randomGifUrl = GetRandomGifUrl();// Załóżmy, że masz funkcję do pobierania URL-a losowego mema
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

    private string GetRandomMemeUrl()
    {
        Random rand = new Random();
        string[] memBase =
        {
            "https://pbs.twimg.com/media/F0OBAWxXgAcwoaf.jpg",
            "https://images3.memedroid.com/images/UPLOADED546/644113b1485ac.jpeg",
            "https://miro.medium.com/v2/resize:fit:1080/1*dFgrBrC0iZzXaePa9T0cQg.png",
            "https://i.pinimg.com/736x/21/f5/07/21f5073071e7b4139a950f1c5f164994.jpg",
            "https://cdn.discordapp.com/attachments/1111987746416885851/1163538213684662382/Mein_kampf.png?ex=653ff067&is=652d7b67&hm=0baa492dcffbcda53df7ac562168e051d709e196b88711e0e350b8abb78c2865&",
            "https://cdn.discordapp.com/attachments/1111987746416885851/1150098086593564722/SPOILER_SPOILER_d8718ca90aeeabd04f96c0ca6bf901ad.jpg?ex=653d2fcf&is=652abacf&hm=62f38e9b087ba16ad62246b615bea73b185eb7e55d26d7a11e378affe9ae514e&",
        };
        var resultInt = rand.Next(memBase.Length);

        return memBase[resultInt];
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

}
