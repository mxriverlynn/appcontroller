namespace ApplicationControllerExample.App
{
	public interface ISecondaryView
	{
		SecondaryPresenter Presenter { get; set; }
		void Run();
	}
}