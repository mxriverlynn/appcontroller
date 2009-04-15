namespace ApplicationControllerExample.Model
{
	public class SomeEventData
	{
		public string Message { get; set; }

		public SomeEventData(string message)
		{
			Message = message;
		}
	}
}