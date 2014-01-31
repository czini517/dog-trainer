using System.IO.IsolatedStorage;
using DogTrainerWP8.Models;
using System;

namespace DogTrainerWP8.Utils
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

		public static bool SaveAppUsageNumber(uint count)
		{
			try
			{
				var settings = IsolatedStorageSettings.ApplicationSettings;
				if (settings.Contains(Constants.UsageNumber))
					settings[Constants.UsageNumber] = count;
				else
					settings.Add(Constants.UsageNumber, count);
				settings.Save();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static uint GetAppUsageNumber()
		{
			uint count;
			var settings = IsolatedStorageSettings.ApplicationSettings;
			settings.TryGetValue(Constants.UsageNumber, out count);
			return count;
		}
	}
}
