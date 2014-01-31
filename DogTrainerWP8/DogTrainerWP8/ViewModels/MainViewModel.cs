using System.Windows;
using Caliburn.Micro;
using System.Windows.Media;

namespace DogTrainerWP8.ViewModels 
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

		public void GoToTutorial()
		{
			IoC.Get<INavigationService>().UriFor<TutorialViewModel>().Navigate();
		}

		public void GoToSettings()
		{
			IoC.Get<INavigationService>().UriFor<SettingsViewModel>().Navigate();
		}

		public void Back()
		{
			if (!IoC.Get<bool>("IsPurchaseNotificationNeeded")) 
				return;

			IoC.Get<INavigationService>().UriFor<TrialViewModel>().Navigate();
			IoC.Get<INavigationService>().RemoveBackEntry();
		}
		
	}
}
