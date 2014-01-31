using System.Linq;
using System.Windows;
using Caliburn.Micro;
using DogTrainerWP8.Models;
using System.Collections.Generic;
using DogTrainerWP8.Utils;
using Microsoft.Xna.Framework.Audio;

namespace DogTrainerWP8.ViewModels
{
	public class SettingsViewModel : Screen
	{
		private SoundEffect clickerSound;
		private SoundEffect whistleSound;
		private bool clickerSoundChanged;
		private bool whistleSoundChanged;

		public List<Sound> ClickerSounds { get; set; }

		public List<Sound> WhistleSounds { get; set; }

		private Sound selectedClickerSound;
		private Sound oldClickerSound;
		public Sound SelectedClickerSound
		{
			get { return selectedClickerSound; }
			set
			{
				oldClickerSound = selectedClickerSound;
				selectedClickerSound = value;
				NotifyOfPropertyChange(() => SelectedClickerSound);

				clickerSoundChanged = true;
			}
		}

		private Sound selectedWhistleSound;
		private Sound oldWhistleSound;
		public Sound SelectedWhistleSound
		{
			get { return selectedWhistleSound; }
			set
			{
				oldWhistleSound = selectedWhistleSound;
				selectedWhistleSound = value;
				NotifyOfPropertyChange(() => SelectedWhistleSound);

				whistleSoundChanged = true;
			}
		}

		public SettingsViewModel()
		{
			ClickerSounds = new List<Sound>
			                	{
			                		new Sound {Name = "Clicker 1", Path = Constants.ClickerSound1Location},
			                		new Sound {Name = "Clicker 2", Path = Constants.ClickerSound2Location}
			                	};

			WhistleSounds = new List<Sound>
			                	{
			                		new Sound {Name = "12000 Hz", Path = Constants.WhistleSound12000Location},
			                		new Sound {Name = "13000 Hz", Path = Constants.WhistleSound13000Location},
									new Sound {Name = "16000 Hz", Path = Constants.WhistleSound16000Location},
									new Sound {Name = "18000 Hz", Path = Constants.WhistleSound18000Location},
									new Sound {Name = "20000 Hz", Path = Constants.WhistleSound20000Location},
			                	};

			var savedClickerSound = StorageHelper.LoadSound(SoundType.Clicker);
			SelectedClickerSound = savedClickerSound != null ? ClickerSounds.FirstOrDefault(p => p.Path == savedClickerSound.Path) : ClickerSounds.First();

			var savedWhistleSound = StorageHelper.LoadSound(SoundType.Whistle);
			SelectedWhistleSound = savedWhistleSound != null ? WhistleSounds.FirstOrDefault(p => p.Path == savedWhistleSound.Path) : WhistleSounds.First();
		}

		public void ClickerSoundSelection()
		{
			StorageHelper.SaveSound(SoundType.Clicker, SelectedClickerSound);
			clickerSoundChanged = false;
		}

		public void ClickerSoundPlay()
		{
			var result = ResourceHelper.LoadSound(SelectedClickerSound.Path, out clickerSound);
			if (result == false)
				MessageBox.Show("ERROR: Clicker sound is not loaded!");
			else
				clickerSound.Play();

			if (oldClickerSound != null && oldClickerSound != selectedClickerSound && clickerSoundChanged)
				selectedClickerSound = oldClickerSound;
			NotifyOfPropertyChange(() => SelectedClickerSound);

			clickerSoundChanged = false;
		}

		public void WhistleSoundSelection()
		{
			StorageHelper.SaveSound(SoundType.Whistle, SelectedWhistleSound);
			whistleSoundChanged = false;
		}

		public void WhistleSoundPlay()
		{
			var result = ResourceHelper.LoadSound(SelectedWhistleSound.Path, out whistleSound);
			if (result == false)
				MessageBox.Show("ERROR: Whistle sound is not loaded!");
			else
				whistleSound.Play();

			if (oldWhistleSound != null && oldWhistleSound != selectedWhistleSound && whistleSoundChanged)
				selectedWhistleSound = oldWhistleSound;
			NotifyOfPropertyChange(() => SelectedWhistleSound);

			whistleSoundChanged = false;
		}

		public void DisposeResources()
		{
			if (clickerSound != null)
				clickerSound.Dispose();
			if (whistleSound != null)
				whistleSound.Dispose();
		}
	}
}
