using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CHAT
{
	public class ChatHub : Hub
	{
		public const string HubUrl = "/chat";
		public const string PrivateUrld = "/private";

		public async Task Broadcast(string username, string message)
		{
			await Clients.All.SendAsync("Broadcast", username, message);
		
		}
		public Task SendPrivateMessage(string user, string message)
		{
			return Clients.User(user).SendAsync("ReceiveMessage", message);
		}
		public async Task SendMessageToGroup(string user, string message)
		{
			await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
		}
		public override Task OnConnectedAsync()
		{
			Console.WriteLine($"{Context.ConnectionId} connected");
			return base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception e)
		{
			Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
			await base.OnDisconnectedAsync(e);
		}
	}
}