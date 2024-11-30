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
        slashCommands.RegisterCommands<InfoCommands>();
        // slashCommands.RegisterCommands<ConfigCommands>(); // terminated
        slashCommands.RegisterCommands<DevCommands>();

        await DiscordClient.ConnectAsync();
        var interactivity = DiscordClient.UseInteractivity(new InteractivityConfiguration
        {
            Timeout = TimeSpan.FromMinutes(1)
        });

        Events.Init();

        #endregion
        
        #region Console
        

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
                        $"\n≫ set [index] [value] -- sets bot activity" +
                        $"\n≫ list -- shows list of activities");
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
                    await Restart();
                    break;
                case "disconnect":
                    Disconnect();
                    break;
                case "connect":
                    await Connect();
                    break;
                case "set":
                    if (raw.Length < 3) { Console.WriteLine("Nothing happends"); continue; } 
                    DiscordActivity activity = new DiscordActivity("", ActivityType.Playing);
                    activity.Name = raw[2];
                    activity.ActivityType = (ActivityType)int.Parse(raw[1]);
                    await DiscordClient.UpdateStatusAsync(activity);
                    break;
                case "list":
                    Log("List of activities:");
                    foreach (ActivityType act in (ActivityType[])Enum.GetValues(typeof(ActivityType))) 
                        Log($"≫ {(int)act} - {act.ToString()}");
                    break;
                default:
                    Warring($"Incorrect command: {raw[0]}");
                    break;
            }
        }
        #endregion
    }


    public static async Task Restart()
    {
        Log("Restarting...");
        await DiscordClient.DisconnectAsync();
        Thread.Sleep(1000);
        await DiscordClient.ConnectAsync();
        Thread.Sleep(5000);
        Log("Restarted");
    }
    public static async Task Disconnect()
    {
        await DiscordClient.DisconnectAsync();
        Log("Disconnected");
    }
    public static async Task Connect()
    {
        await DiscordClient.ConnectAsync();
        Thread.Sleep(3000);
        Log("Connected");
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