using ApplicationControllerExample.AppController;

namespace ApplicationControllerExample.App
{
	public class SomePresenter
	{
		private ISomeView View { get; set; }
		private IApplicationController AppController { get; set; }

		public SomePresenter(ISomeView view, IApplicationController appController)
		{
			View = view;
			View.Presenter = this;
			AppController = appController;
		}
		
		public void DoSomething()
		{
		}

		public void DoAnotherThing()
		{
			AppController.Execute<AnotherThing>(null);			
		}
	}
}