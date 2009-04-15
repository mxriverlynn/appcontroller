using ApplicationControllerExample.Model;

namespace ApplicationControllerExample.App
{
	public class SecondaryPresenter: IPartOfTheProcess
	{
		private ISecondaryView View { get; set; }

		public SecondaryPresenter(ISecondaryView view)
		{
			View = view;
			View.Presenter = this;
		}

		public void DoThatThing()
		{
			View.Run();
		}
	}
}