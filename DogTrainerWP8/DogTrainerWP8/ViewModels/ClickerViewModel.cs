using DogTrainerWP8.Utils;
using Caliburn.Micro;

namespace DogTrainerWP8.ViewModels
{
	public class ClickerViewModel : Screen
	{
        public bool IsTrial 
        {
            get { return IoC.Get<bool>("IsTrial"); }
        }

		public void DoClickSound()
		{
			if (SoundHelper.ClickSound != null)
                SoundHelper.ClickSound.Play();
		}
	}
}
