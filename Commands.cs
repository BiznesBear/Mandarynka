using System.Text;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Mandarynka
{
    public class BasicCommands : ApplicationCommandModule
    {
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
            if (!string.IsNullOrEmpty(field6))
            {
                var fieldStrings = field6.Split(';');
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

            await ctx.CreateResponseAsync("Created!", true);
        }

        [SlashRequireGuild]
        [SlashCommand("verify", "Be verified")]
        public async Task VerifyUser(InteractionContext ctx)
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

        // info commands 
        [SlashCommand("server_info", "Server info")]
        [SlashRequireGuild]
        public async Task ServerInfoCommand(InteractionContext ctx)
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
        [SlashRequireGuild]
        public async Task RoleInfoCommand(InteractionContext ctx,
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
            roleInfoEmbed.AddField("Creation date", TimestampBuilder(role.CreationTimestamp));
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
            var ping = ctx.Client.Ping;
            await ctx.CreateResponseAsync($"Pong! Current ping is {ping} ms", true);
        }


        [SlashRequireGuild]
        [SlashRequirePermissions(Permissions.ManageMessages)]
        [SlashCommand("clear", "Clears amount of messages")]
        public async Task Clear(InteractionContext ctx,
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

        [SlashCommand("help", "Bot help center")]
        public async Task Help(InteractionContext ctx)
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

        [SlashCommand("commands", "Show's all commands")]
        public async Task Commands(InteractionContext ctx,
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
            creditsEmbed.AddField("Version: ", $"Beta testing (In progress)");

            var dcserverButton = new DiscordLinkButtonComponent("https://discord.gg/c9VExDxEde", "Discord server");
            var addButton = new DiscordLinkButtonComponent("https://discord.com/api/oauth2/authorize?client_id=979004845291884584&permissions=8&scope=applications.commands%20bot", "Add me to your server");
            var rickrollButton = new DiscordLinkButtonComponent("https://youtu.be/dQw4w9WgXcQ?si=aXEKxX-SaPoSTijV", "Click me");

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .AddEmbed(creditsEmbed.Build()).AddComponents(dcserverButton, addButton, rickrollButton));
        }


        [SlashRequireOwner]
        [SlashCommand("dev_setactivity", "Nope-you cant do it")]
        private async Task dev_setactivity(InteractionContext ctx,

            [Choice("Playing","0")]
            [Choice("ListeningTo","2")]
            [Choice("Watching","3")]
            [Choice("Streaming","1")]
            [Choice("Competeting","5")]
            [Option("type","Select type")] string activityTypeStr,
            [Option("activity", "What are you doing today")] string activityName,
            [Option("streamurl", "url")] string url = "")
        {
            int activityTypeInt = int.Parse(activityTypeStr);
            ActivityType activityType = (ActivityType)activityTypeInt;

            DiscordActivity activity = new DiscordActivity("", ActivityType.Streaming);

            DiscordClient discord = ctx.Client;
            activity.Name = activityName;
            activity.ActivityType = activityType;
            if (url != "") activity.StreamUrl = url;

            await discord.UpdateStatusAsync(activity);
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                    .WithContent($"Bot now {activityType} **{activityName}** ").AsEphemeral(true));
            return;
        }

        [SlashRequireOwner]
        [SlashCommand("dev_client", "Reset value")]
        private async Task dev_resetvalue(InteractionContext ctx,
            [Choice("ResetActivity","activity")]
        [Option("value","Do something with bot")] string value)
        {
            switch (value)
            {
                case "activity":
                    await ctx.Client.UpdateStatusAsync();
                    await ctx.CreateResponseAsync("Reseted", true);
                    break;
                default:
                    await ctx.CreateResponseAsync("Something went wrong !", true);
                    break;
            }
        }

        public string TimestampBuilder(DateTimeOffset dateTime)
        {
            var timestamp = new DateTimeOffset(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, TimeSpan.Zero);
            string formattedTimestamp = $"<t:{timestamp.ToUnixTimeSeconds()}:R>";
            return formattedTimestamp;
        }

        public async Task HandleDropdown(ComponentInteractionCreateEventArgs e)
        {
            string selectedOption = e.Values.FirstOrDefault();
            DiscordInteractionResponseBuilder responseBuilder = new DiscordInteractionResponseBuilder().AsEphemeral(true);

            switch (selectedOption)
            {
                case "help_commands":
                    responseBuilder.WithContent("You can also check all commands in the </commands:1178716973597732978>\nBut if you wanna check what command doing please use that command. Realy.");
                    break;

                case "help_func":
                    responseBuilder.WithContent("All bot function are in commands. Like </config_eventchannel:1187109879597518869> sets the event channel (bans,new members annouce)");
                    break;

                case "help_admin":
                    responseBuilder.WithContent("This is not admin bot, but have some function that helps admins stay server clear like </clear:1188445497095106560> ");
                    break;

                case "help_setuping":
                    responseBuilder.WithContent("Im very helpful for creating server like </guild_copyrole:1187847895651725402> can help you with creating roles.\n or</config_verifyrole:1180824326358962196> that adds verifycation to your server");
                    break;
                default:
                    break;
            }

            await e.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, responseBuilder);
        }



        [SlashCommand("youtube", "Search youtube videos")]
        public async Task YoutubeSearch(InteractionContext ctx,
        [Option("search", "Search in youtube")] string target)
        {
            var followup = new DiscordFollowupMessageBuilder();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Program.youtubeKey,
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
    }







    [SlashCommandGroup("config", "Config commands only for admins"), SlashCommandPermissions(Permissions.Administrator)]
    public class ConfigCommands : ApplicationCommandModule
    {
        [SlashRequireGuild]
        [SlashCommand("botname", "Change bot name")]
        public async Task ConfigureBotNameCommand(InteractionContext ctx, [Option("newname", "New bot name")] string newNickname)
        {
            var guild = ctx.Guild;
            var botMember = guild.Members[ctx.Client.CurrentUser.Id];

            var oldNickname = botMember.Nickname;

            await botMember.ModifyAsync(memberEdit => memberEdit.Nickname = newNickname);

            await ctx.CreateResponseAsync($"Chaned bot name '{oldNickname}' for '{newNickname}'.", true);

        }

        [SlashCommand("verifyrole", "Set the verification role")]
        [SlashRequireGuild]
        public async Task SetVerifyRole(InteractionContext ctx, [Option("role", "The verification role")] DiscordRole role)
        {
            var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
            guildSettings.VerifyRoleId = role.Id;
            GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
            await ctx.CreateResponseAsync($"Verification role is now set to: {role.Mention}", true);
        }

        [SlashCommand("defalutrole", "Set the defalut role for every member")]
        [SlashRequireGuild]
        public async Task SetDefalutRole(InteractionContext ctx, [Option("role", "The verification role")] DiscordRole role)
        {
            var guildSettings = GuildSaver.GetGuildSettings(ctx.Guild.Id);
            guildSettings.DefalutRoleId = role.Id;
            GuildSaver.SaveGuildSettings(ctx.Guild.Id, guildSettings);
            await ctx.CreateResponseAsync($"Defalut role is now set to: {role.Mention}", true);
        }

        [SlashCommand("resetvalue", "Reset value")]
        [SlashRequireGuild]
        public async Task ResetValue(InteractionContext ctx,
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
        [SlashCommand("copyrole", "Copy a role (admin only)")]
        public async Task CopyRole(InteractionContext ctx, [Option("role", "Role to copy")] DiscordRole role, [Option("name", "Name for the copied role")] string roleName)
        {
            if (role == null)
            {
                await ctx.CreateResponseAsync("Please specify a valid role to copy.", true);
                return;
            }
            try
            {
                var copiedRole = await ctx.Guild.CreateRoleAsync(roleName, role.Permissions, role.Color, role.IsHoisted, role.IsMentionable);

                await ctx.CreateResponseAsync($"Role '{role.Name}' has been copied to '{copiedRole.Name}' with a new name.", true);
            }
            catch (Exception ex)
            {
                await ctx.CreateResponseAsync($"An error occurred: {ex.Message}", true);
            }
        }

        [SlashRequireGuild]
        [SlashCommand("getstat", "Gets guild stat and send it(in file or discord message)")]
        public async Task GetStat(InteractionContext ctx,
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
        public async Task SetEventChannel(InteractionContext ctx,
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
        public async Task SetWelcomeChannel(InteractionContext ctx,
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
        public async Task SeeCurrentConfig(InteractionContext ctx)
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
    }
}
