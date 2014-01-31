using System.Windows;
using Caliburn.Micro;
using Microsoft.Phone.Shell;
using MyToolkit.Multimedia;

namespace DogTrainerWP8.ViewModels
{
	public class VideoViewModel : Screen
	{
		private string youtubeId;

		public string YoutubeId
		{
			get { return youtubeId; }
			set
			{
				if (value == youtubeId) return;
				youtubeId = value;
				NotifyOfPropertyChange(() => YoutubeId);
			}
		}

		protected override void OnDeactivate(bool close)
		{
			YouTube.CancelPlay();
			IoC.Get<INavigationService>().GoBack();
			base.OnDeactivate(close);
		}

		public void Loaded()
		{
			YouTube.Play(YoutubeId, true, YouTubeQuality.Quality480P, (ex) =>
			{
				if (ex != null)
				{
					SystemTray.ProgressIndicator.IsVisible = false;
					MessageBox.Show(ex.Message);
				}
			});

		}
	}
}
