using ApplicationControllerExample.AppController;
using ApplicationControllerExample.Model;
using EventAggregator;

namespace ApplicationControllerExample.App
{

	public class MainPresenter: IEventHandler<SomeEventData>
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
			AppController.Raise(new SomeEventData("you clicked something"));
		}

		public void Handle(SomeEventData eventData)
		{
			View.SaySomething(eventData.Message);
		}
	}

}