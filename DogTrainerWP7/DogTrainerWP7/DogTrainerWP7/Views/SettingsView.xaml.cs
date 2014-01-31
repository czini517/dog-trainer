using System.Linq;
using Caliburn.Micro;
using DogTrainerWP7.ViewModels;
using Microsoft.Phone.Controls;

namespace DogTrainerWP7.Views
{
	public partial class SettingsView : PhoneApplicationPage
	{
		public SettingsView()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			var lastPage = NavigationService.BackStack.FirstOrDefault();
			
			if (lastPage != null && lastPage.Source.ToString().Contains("Whistle"))
				SettingsPivot.SelectedIndex = SettingsPivot.Items.IndexOf(Whistle);
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			IoC.Get<SettingsViewModel>().DisposeResources();

			base.OnNavigatedFrom(e);
		}
	}
}