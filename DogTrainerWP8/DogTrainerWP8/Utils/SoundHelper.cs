using System.Windows;
using DogTrainerWP8.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace DogTrainerWP8.Utils
{
    public static class SoundHelper
    {
        private static bool initialized;

        public static void Initialize()
        {
            if (initialized)
                return;

            // Adds an Update delegate, to simulate the XNA update method.
            FrameworkDispatcher.Update();
            initialized = true;
        }

        public static SoundEffect ClickSound
        {
            get
            {
                SoundEffect clickerSound;
                var soundPath = Constants.ClickerSound1Location;
                var sound = StorageHelper.LoadSound(SoundType.Clicker);
                if (sound != null)
                    soundPath = sound.Path;
                var result = ResourceHelper.LoadSound(soundPath, out clickerSound);
                if (!result)
                    MessageBox.Show("ERROR: Clicker sound is not loaded!");
                return clickerSound;
            }
        }

        public static SoundEffect WhistleSound
        {
            get
            {
                SoundEffect whistleSound;
                var soundPath = Constants.WhistleSound12000Location;
                var sound = StorageHelper.LoadSound(SoundType.Whistle);
                if (sound != null)
                    soundPath = sound.Path;
                var result = ResourceHelper.LoadSound(soundPath, out whistleSound);
                if (result == false)
                    MessageBox.Show("ERROR: Whistle sound is not loaded!");
                return whistleSound;
            }
        }
    }
}
