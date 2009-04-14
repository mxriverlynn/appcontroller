using System.Windows.Forms;

namespace ApplicationControllerExample.App
{
	public class AnotherThing: ICommand<AnotherThing>
	{
	    public void Execute(AnotherThing someData)
	    {
	        MessageBox.Show("You clicked a button!");
	    }
	}

}