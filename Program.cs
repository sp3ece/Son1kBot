using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Son1kBot1k
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsyc().GetAwaiter().GetResult();

        private async Task MainAsyc()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "OTQxNzU2NTk4NzI3MDg2MjAx.YgalLg.ATxnVqEt5mpGhzxpkXwfgR_s7l0";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage nya)
        {
            Console.WriteLine(nya.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage nya)
        {
            if(!nya.Author.IsBot)
                switch(nya.Content)
                {
                    case "!привет":
                        {
                            nya.Channel.SendMessageAsync($"Привет, {nya.Author}");
                            break;
                        }
                    case "!рандом":
                        {
                            Random rnd = new Random();
                            nya.Channel.SendMessageAsync($"Выпало число: {rnd.Next(0, 100)}");
                            break;
                        }
                }
            return Task.CompletedTask;
        }
    }
}
