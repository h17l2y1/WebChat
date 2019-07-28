namespace WebChat.ViewModels.User
{
	public class ResponseUserTokenView
	{
		public string Token { get; set; }

		public ResponseUserTokenView(string token)
		{
			Token = token;
		}
	}
}
