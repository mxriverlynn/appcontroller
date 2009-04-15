using ApplicationControllerExample.AppController;

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

	}

}