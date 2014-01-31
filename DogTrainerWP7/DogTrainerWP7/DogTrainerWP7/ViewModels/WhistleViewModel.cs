using System.Windows;
using Caliburn.Micro;
using DogTrainerWP7.Models;
using DogTrainerWP7.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace DogTrainerWP7.ViewModels
{
	public class WhistleViewModel : Screen
	{
		private SoundEffect whistleSound1;
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

        private bool isTrial;
        public bool IsTrial
        {
            get { return IoC.Get<bool>("IsTrial"); }
            set
            {
                isTrial = value;
                NotifyOfPropertyChange("IsTrial");
            }
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
				var soundPath = Constants.WhistleSound12000Location;
				var sound = StorageHelper.LoadSound(SoundType.Whistle);
				if (sound != null)
					soundPath = sound.Path;
				var result = ResourceHelper.LoadSound(soundPath, out whistleSound1);
				if (result == false)
					MessageBox.Show("ERROR: Whistle sound is not loaded!");
				else
					FrameworkDispatcher.Update();

				IsPlaying = Visibility.Collapsed;
				IsStopped = Visibility.Visible;

				sei = whistleSound1.CreateInstance();
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

			FrameworkDispatcher.Update();
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
