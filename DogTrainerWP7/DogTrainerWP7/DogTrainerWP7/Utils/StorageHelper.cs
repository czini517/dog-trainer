using System.IO.IsolatedStorage;
using DogTrainerWP7.Models;
using System;

namespace DogTrainerWP7.Utils
{
	public static class StorageHelper
	{
		public static bool SaveSound(SoundType soundType, Sound sound)
		{
			try
			{
				var settings = IsolatedStorageSettings.ApplicationSettings;
				var key = soundType == SoundType.Clicker ? Constants.StoredClickerSound : Constants.StoredWhistleSound;
				if (settings.Contains(key))
					settings[key] = sound;
				else
					settings.Add(key, sound);
				settings.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static Sound LoadSound(SoundType soundType)
		{
			Sound sound;
			var settings = IsolatedStorageSettings.ApplicationSettings;
			if (soundType == SoundType.Clicker)
				settings.TryGetValue(Constants.StoredClickerSound, out sound);
			else
				settings.TryGetValue(Constants.StoredWhistleSound, out sound);
			return sound;
		}
	}
}
