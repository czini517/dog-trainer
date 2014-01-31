using DogTrainerWP7.Models;
using DogTrainerWP7.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Phone.Marketplace;

namespace DogTrainerWP7.ViewModels
{
	public class ClickerViewModel : Screen
	{
		private SoundEffect clickerSound1;

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

		public void DoClickSound()
		{
			var soundPath = Constants.ClickerSound1Location;
			var sound = StorageHelper.LoadSound(SoundType.Clicker);
			if (sound != null)
				soundPath = sound.Path;
			var result = ResourceHelper.LoadSound(soundPath, out clickerSound1);
			if (result == false)
				MessageBox.Show("ERROR: Clicker sound is not loaded!");
			else
			{
				FrameworkDispatcher.Update();
				clickerSound1.Play();
			}

		}
	}
}
