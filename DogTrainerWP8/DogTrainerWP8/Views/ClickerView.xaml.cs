using Caliburn.Micro;
using DogTrainerWP8.ViewModels;
using Microsoft.Phone.Controls;

namespace DogTrainerWP8.Views
{
	public partial class ClickerView : PhoneApplicationPage
	{
		public ClickerView()
		{
			InitializeComponent();
		}

		private void ApplicationBarIconButton_Click(object sender, System.EventArgs e)
		{
			IoC.Get<INavigationService>().UriFor<SettingsViewModel>().Navigate();
		}
	}
}