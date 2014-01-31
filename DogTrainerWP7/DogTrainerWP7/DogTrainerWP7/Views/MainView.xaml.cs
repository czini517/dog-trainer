using Microsoft.Phone.Controls;
using Caliburn.Micro;
using DogTrainerWP7.ViewModels;

namespace DogTrainerWP7.Views
{
	public partial class MainView : PhoneApplicationPage
	{
		// Constructor
		public MainView()
		{
			InitializeComponent();
		}

		private void ApplicationBarMenuItem_Click(object sender, System.EventArgs e)
		{
			IoC.Get<INavigationService>().UriFor<AboutViewModel>().Navigate();
		}
	}
}