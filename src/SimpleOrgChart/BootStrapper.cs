using System.Windows.Forms;
using StructureMap;

namespace SimpleOrgChart
{
	public class BootStrapper
	{

		private IContainer Container { get; set; }

		public BootStrapper(IContainer container)
		{
			Container = container;
		}

		public ApplicationContext GetAppContext()
		{
			Container.Configure(c => c.AddRegistry<DefaultRegistry>());
			return Container.GetInstance<ApplicationContext>();
		}

	}
}