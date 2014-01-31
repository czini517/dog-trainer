using System.Windows;
using System.Windows.Controls;

namespace DogTrainerWP8.Controls
{
	public class WhistleButton : Button
	{
		public static readonly DependencyProperty IsPlayingProperty = DependencyProperty.Register("IsPlaying", typeof(Visibility), typeof(WhistleButton), null);     
		
		public Visibility IsPlaying
		{
			get { return (Visibility)base.GetValue(IsPlayingProperty); }
			set { base.SetValue(IsPlayingProperty, value); }
		}

		public static readonly DependencyProperty IsStoppedProperty = DependencyProperty.Register("IsStopped", typeof(Visibility), typeof(WhistleButton), null);

		public Visibility IsStopped
		{
			get { return (Visibility)base.GetValue(IsPlayingProperty); }
			set { base.SetValue(IsPlayingProperty, value); }
		}
	}
}
