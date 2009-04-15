using ApplicationControllerExample.App;
using StructureMap;

namespace ApplicationControllerExample.AppController
{

	public class ApplicationController : IApplicationController
	{

		private IContainer Container { get; set; }

		public ApplicationController(IContainer container)
		{
			Container = container;
		}

	}

}