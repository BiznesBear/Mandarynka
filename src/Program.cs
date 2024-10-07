using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;

namespace Mandarynka;
internal class Program
{
    internal static DiscordClient DiscordClient { get; private set; } = new(new DiscordConfiguration
    {
        Token = Keys.BotToken,
        TokenType = TokenType.Bot,
        Intents = DiscordIntents.All,
        MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Critical,
    });
    private static async Task Main(string[] args)
    {
        #region Startup
        Log("Loading...");

        //register commands
        var slashCommands = DiscordClient.UseSlashCommands();
        slashCommands.RegisterCommands<BasicCommands>();
        slashCommands.RegisterCommands<ConfigCommands>();
        slashCommands.RegisterCommands<DevCommands>();

        await DiscordClient.ConnectAsync();
        var interactivity = DiscordClient.UseInteractivity(new InteractivityConfiguration
        {
            Timeout = TimeSpan.FromMinutes(1)
        });

        Events.Init();

        #endregion
        
        #region Console
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
                    Log($"Command list:" +
                        $"\n≫ exit/close -- closes the console and shut down the bot" +
                        $"\n≫ clear -- clears console" +
                        $"\n≫ restart/disconnect/connect -- does exacly what it says" +
                        $"\n≫ setactivity [index] [value] -- sets bot activity" +
                        $"\n≫ activities -- shows list of activities");
                    break;
                case "exit" or "close":
                    await DiscordClient.DisconnectAsync();
                    Log("Bye!!");
                    Environment.Exit(0);
                    break;
                case "clear":
                    Console.Clear();
                    NewConsole();
                    break;
                case "restart":
                    Log("Restarting...");
                    await DiscordClient.DisconnectAsync();
                    Thread.Sleep(1500);
                    await DiscordClient.ConnectAsync();
                    Thread.Sleep(4000);
                    Log("Restarted");
                    break;
                case "disconnect":
                    await DiscordClient.DisconnectAsync();
                    Log("Disconnected");
                    break;
                case "connect":
                    await DiscordClient.ConnectAsync();
                    Thread.Sleep(3000);
                    Log("Connected");
                    break;
                case "setactivity":
                    if (raw.Length < 3) { Console.WriteLine("Nothing happends"); continue; } 
                    DiscordActivity activity = new DiscordActivity("", ActivityType.Playing);
                    activity.Name = raw[2];
                    activity.ActivityType = (ActivityType)int.Parse(raw[1]);
                    await DiscordClient.UpdateStatusAsync(activity);
                    break;
                case "activities":
                    Log("List of activities:");
                    foreach (ActivityType act in (ActivityType[])Enum.GetValues(typeof(ActivityType))) 
                        Log($"≫ {(int)act} - {act.ToString()}");
                    break;
                case "":
                    break;
                default:
                    Warring($"Incorrect command: {raw[0]}");
                    break;
            }
        }
        #endregion
    }

    public static void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public static void Warring(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    private static void NewConsole() { Log($"WELCOME TO MANDARYNKA CONSOLE\nCREATED BY: (C)BIZNESBEAR 2023\nPLEASE ENTER A COMMAND OR TYPE help FOR COMMAND LIST\nEnvironment version: {Environment.Version}"); }
}