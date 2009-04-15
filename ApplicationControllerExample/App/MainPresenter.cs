using ApplicationControllerExample.AppController;
using ApplicationControllerExample.Model;

namespace ApplicationControllerExample.App
{

	public class MainPresenter
	{

		private IMainView View { get; set; }
		private IApplicationController AppController { get; set; }

		public MainPresenter(IMainView mainView, IApplicationController appController)
		{
			View = mainView;
			AppController = appController;
			View.Presenter = this;
		}

		public void Run()
		{
			View.Run();
		}

		public void DoSomething()
		{
			AppController.Execute(new SomeCommandData());
		}

		public void SomethingElseIsHappening()
		{
			AppController.Raise<SomeEventData>(new SomeEventData());
		}

	}

}