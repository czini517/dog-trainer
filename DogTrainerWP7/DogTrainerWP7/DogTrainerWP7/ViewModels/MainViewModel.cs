using System.Windows;
using Caliburn.Micro;
using System.Windows.Media;

namespace DogTrainerWP7.ViewModels 
{
	public class MainViewModel : Screen
	{
		public Brush BackgroundBrush
		{
			get { return (Brush)Application.Current.Resources["PhoneAccentBrush"]; }
		}


		public void GoToClicker()
		{
			IoC.Get<INavigationService>().UriFor<ClickerViewModel>().Navigate();
		}

		public void GoToWhistle()
		{
			IoC.Get<INavigationService>().UriFor<WhistleViewModel>().Navigate();
		}

		public void GoToSettings()
		{
			IoC.Get<INavigationService>().UriFor<SettingsViewModel>().Navigate();
		}
	}
}
