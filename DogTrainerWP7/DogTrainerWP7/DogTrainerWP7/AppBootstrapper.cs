using System.Windows;
using System.Windows.Navigation;
using DogTrainerWP7.Utils;
using DogTrainerWP7.ViewModels;
using Microsoft.Phone.Marketplace;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Caliburn.Micro;
using System.Diagnostics;
using Microsoft.Phone.Shell;

namespace DogTrainerWP7 
{
	public class AppBootstrapper : PhoneBootstrapper
	{
		PhoneContainer container;

        public LocalyticsSession appSession;

		private static LicenseInformation licenseInfo = new LicenseInformation();

		protected override void Configure()
		{
			container = new PhoneContainer(RootFrame);

			container.RegisterPhoneServices();

            container.RegisterInstance(typeof(bool), "IsTrial", CheckLicense());

			container.PerRequest<MainViewModel>();
			container.PerRequest<ClickerViewModel>();
			container.Instance(new WhistleViewModel());
			container.PerRequest<AboutViewModel>();
			container.PerRequest<SettingsViewModel>();
			container.PerRequest<TrialViewModel>();

            AddCustomConventions();
		}

		protected override object GetInstance(Type service, string key)
		{
			return container.GetInstance(service, key);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			container.BuildUp(instance);
		}

		protected override void OnUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				e.Handled = true;
			}
			else
			{
				MessageBox.Show("An unexpected error occured, sorry about the troubles.", "Oops...", MessageBoxButton.OK);
				e.Handled = true;
			}

			var attributes = new Dictionary<string, string> {{"exception", e.ExceptionObject.Message}};
			appSession.tagEvent("App crash", attributes);

			base.OnUnhandledException(sender, e);
		}

		static void AddCustomConventions()
		{
			ConventionManager.AddElementConvention<Pivot>(Pivot.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
				(viewModelType, path, property, element, convention) => {
					if (ConventionManager
						.GetElementConvention(typeof(ItemsControl))
						.ApplyBinding(viewModelType, path, property, element, convention))
					{
						ConventionManager
							.ConfigureSelectedItem(element, Pivot.SelectedItemProperty, viewModelType, path);
						ConventionManager
							.ApplyHeaderTemplate(element, Pivot.HeaderTemplateProperty, null, viewModelType);
						return true;
					}

					return false;
				};

			ConventionManager.AddElementConvention<Panorama>(Panorama.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
				(viewModelType, path, property, element, convention) => {
					if (ConventionManager
						.GetElementConvention(typeof(ItemsControl))
						.ApplyBinding(viewModelType, path, property, element, convention))
					{
						ConventionManager
							.ConfigureSelectedItem(element, Panorama.SelectedItemProperty, viewModelType, path);
						ConventionManager
							.ApplyHeaderTemplate(element, Panorama.HeaderTemplateProperty, null, viewModelType);
						return true;
					}

					return false;
				};
		}

        protected override void OnActivate(object sender, ActivatedEventArgs e)
        {
            appSession = new LocalyticsSession("742141b7ab8ccd718096ccc-884a9a9c-10ed-11e2-5989-00ef75f32667");
            appSession.open();
            appSession.upload();

            base.OnActivate(sender, e);
        }

        protected override void OnLaunch(object sender, LaunchingEventArgs e)
        {
            appSession = new LocalyticsSession("742141b7ab8ccd718096ccc-884a9a9c-10ed-11e2-5989-00ef75f32667");
            appSession.open();
            appSession.upload();

            base.OnLaunch(sender, e);
        }

        protected override void OnDeactivate(object sender, DeactivatedEventArgs e)
        {
            appSession.close();

            base.OnDeactivate(sender, e);
        }

        protected override void OnClose(object sender, ClosingEventArgs e)
        {
            appSession.close();

            base.OnClose(sender, e);
        }

		/// <summary>
		/// Check the current license information for this application
		/// </summary>
		private bool CheckLicense()
		{
			// When debugging, we want to simulate a trial mode experience. The following conditional allows us to set the _isTrial 
			// property to simulate trial mode being on or off. 
#if DEBUG
			return true;
#else
			return licenseInfo.IsTrial();
#endif
		}

	}
}
