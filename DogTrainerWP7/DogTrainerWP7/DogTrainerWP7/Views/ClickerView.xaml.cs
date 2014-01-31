using Caliburn.Micro;
using DogTrainerWP7.ViewModels;
using Microsoft.Phone.Controls;
using System.Windows;

namespace DogTrainerWP7.Views
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