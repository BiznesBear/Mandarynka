using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;


namespace Mandarynka;

internal class BasicCommands : ApplicationCommandModule
{
    #region BigCommands
    [SlashCommand("dotart", "Sends dot art")]
    internal async Task DotArtCommand(InteractionContext ctx,
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
    internal async Task EmbedCommand(InteractionContext ctx,
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
    [Option("field6", "Separe title & description with ;| Example: My Title;Here is my description")] string field6 = "",
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

        field1.FieldSplit(customEmbed);
        field2.FieldSplit(customEmbed);
        field3.FieldSplit(customEmbed);
        field4.FieldSplit(customEmbed);
        field5.FieldSplit(customEmbed);
        field6.FieldSplit(customEmbed);

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

        await ctx.CreateResponseAsync("Created!", true);
    }

    #endregion
    #region Infos

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

    [SlashCommand("user_info", "Shows informations about the user")]
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

    #endregion
    #region Misc
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
    [SlashRequireGuild]
    [SlashRequirePermissions(Permissions.ManageMessages)]
    [SlashCommand("clear", "Clears amount of messages")]
    internal async Task Clear(InteractionContext ctx,
        [Option("amount", "Amount of messages to clear")] string amountStr)
    {
        DiscordFollowupMessageBuilder followup = new DiscordFollowupMessageBuilder().AsEphemeral(true);
        _ = int.TryParse(amountStr, out int amount);
        var channel = ctx.Channel;
        var messages = await ctx.Channel.GetMessagesAsync(amount);
        if (amount < 1 || amount > 100)
        {
            await ctx.FollowUpAsync(followup.WithContent("Incorrect amount of messages (please select from 1 to 100)").AsEphemeral(true));
            return;
        }
        await ctx.DeferAsync(true);
        await channel.DeleteMessagesAsync(messages);
        await ctx.FollowUpAsync(followup.WithContent($"Deleted {messages.Count} messages").AsEphemeral(true));
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

    [SlashCommand("credits", "Shows credits")]
    internal async Task Credits(InteractionContext ctx)
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
        creditsEmbed.AddField("Version: ", $"The newest as possible :)");

        var dcserverButton = new DiscordLinkButtonComponent("https://discord.gg/c9VExDxEde", "Discord server");
        var addButton = new DiscordLinkButtonComponent("https://discord.com/api/oauth2/authorize?client_id=979004845291884584&permissions=8&scope=applications.commands%20bot", "Add me to your server");
        var rickrollButton = new DiscordLinkButtonComponent("https://youtu.be/dQw4w9WgXcQ?si=aXEKxX-SaPoSTijV", "Click me");

        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
            .AddEmbed(creditsEmbed.Build()).AddComponents(dcserverButton, addButton, rickrollButton));
    }


    [SlashCommand("youtube", "Search youtube videos")]
    internal async Task YoutubeSearch(InteractionContext ctx,
    [Option("search", "Search in youtube")] string target)
    {
        var followup = new DiscordFollowupMessageBuilder();
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = Keys.YoutubeKey,
            ApplicationName = "SearchForMandarynka"
        });

        var search = youtubeService.Search.List("snippet");
        search.Q = target;
        search.MaxResults = 1;
        var result = search.Execute();
        var first = result.Items.First().Snippet;
        string link = result.Items.First().Id.VideoId;

        var videoRequest = youtubeService.Videos.List("statistics");
        videoRequest.Id = link;
        search.MaxResults = 1;
        var videoResponse = videoRequest.Execute();
        var stats = videoResponse.Items.First().Statistics;

        await ctx.DeferAsync();

        DiscordEmbedBuilder youtubeVideoEmbed = new DiscordEmbedBuilder()
        {
            Title = first.Title,
            Url = $"https://www.youtube.com/watch?v={link}",
            Description = first.Description,
            ImageUrl = first.Thumbnails.Medium.Url,
            Timestamp = first.PublishedAtDateTimeOffset,
            Color = DiscordColor.Red
        };
        youtubeVideoEmbed.WithAuthor(first.ChannelTitle.ToString(), $"https://www.youtube.com/channel/{first.ChannelId}");
        youtubeVideoEmbed.AddField("Stats", $"Views: {stats.ViewCount}\nLikes: {stats.LikeCount}\nComments: {stats.CommentCount}");


        await ctx.FollowUpAsync(followup.AddEmbed(youtubeVideoEmbed));
    }



    [SlashCommand("halloween", "A spooky command")]
    internal async Task Halloween(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync("https://tenor.com/view/i-love-tangerines-tangerine-oranges-citrus-fruit-gif-1410742271454258105");
    }



    #endregion
}
