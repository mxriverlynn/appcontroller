namespace ApplicationControllerExample.App
{
	public interface IMainView
	{
		MainPresenter Presenter { get; set; }
		void Run();
		void SaySomething(string something);
	}
}