using System;
using System.Windows;
using Microsoft.Xna.Framework.Audio;

namespace DogTrainerWP7.Utils
{
	public static class ResourceHelper
	{
		public static bool LoadSound(String soundFilePath, out SoundEffect sound)
		{
			sound = null;

			try
			{
				var soundFileInfo = Application.GetResourceStream(new Uri(soundFilePath, UriKind.Relative));
				sound = SoundEffect.FromStream(soundFileInfo.Stream);
				return true;
			}
			catch (NullReferenceException)
			{
				return false;
			}
		}
	}
}
