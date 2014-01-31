using System;
using System.Windows;
using Caliburn.Micro;
using DogTrainerWP7.ViewModels;
using Microsoft.Phone.Controls;

namespace DogTrainerWP7.Views
{
	public partial class WhistleView : PhoneApplicationPage
	{
		public WhistleView()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
		{
			IoC.Get<WhistleViewModel>().DisposeResources();

			base.OnNavigatedFrom(e);
		}

		private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			IoC.Get<INavigationService>().UriFor<SettingsViewModel>().Navigate();
		}
	}
}