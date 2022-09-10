namespace CHAT
{
	public class Message
	{
		public DateTime Send_time { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; } = "";
	}
}
