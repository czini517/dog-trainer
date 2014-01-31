using System.Windows;
using Caliburn.Micro;
using DogTrainerWP8.Utils;
using Microsoft.Xna.Framework.Audio;

namespace DogTrainerWP8.ViewModels
{
	public class WhistleViewModel : Screen
	{
		private SoundEffectInstance sei;

		private Visibility isPlaying;
		public Visibility IsPlaying
		{
			get { return isPlaying; }
			set
			{
				isPlaying = value;
				NotifyOfPropertyChange(() => IsPlaying);
			}
		}

		private Visibility isStopped;
		public Visibility IsStopped
		{
			get { return isStopped; }
			set
			{
				isStopped = value;
				NotifyOfPropertyChange(() => IsStopped);
			}
		}

        public bool IsTrial
        {
            get { return IoC.Get<bool>("IsTrial"); }
        }

		public WhistleViewModel()
		{
			IsPlaying = Visibility.Visible;
			IsStopped = Visibility.Collapsed;
		}

		public void DoWhistleSound()
		{
			if (IsPlaying == Visibility.Visible)
			{
			    if (SoundHelper.WhistleSound == null)
			        return;

				IsPlaying = Visibility.Collapsed;
				IsStopped = Visibility.Visible;

                sei = SoundHelper.WhistleSound.CreateInstance();
				sei.IsLooped = true;
				sei.Play();
			}
			else
			{
				if (sei != null)
					sei.Stop();

				IsPlaying = Visibility.Visible;
				IsStopped = Visibility.Collapsed;
			}
		}

		public void DisposeResources()
		{
			if (sei != null)
			{
				sei.Stop();
			}

			IsPlaying = Visibility.Visible;
			IsStopped = Visibility.Collapsed;
		}
	}
}
