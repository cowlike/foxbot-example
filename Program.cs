﻿using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace MyBot
{
	public class Program
	{
		public static void Main(string[] args)
			=> new Program().MainAsync(args[0]).GetAwaiter().GetResult();

		public async Task MainAsync(string token)
		{
			var client = new DiscordSocketClient();

			client.Log += Log;
			client.MessageReceived += MessageReceived;

			await client.LoginAsync(TokenType.Bot, token);
			await client.StartAsync();

			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

		private async Task MessageReceived(SocketMessage message)
		{
			if (message.Content == "!ping")
			{
				await message.Channel.SendMessageAsync("Pong!");
			}
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}
}