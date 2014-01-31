using Caliburn.Micro;
using Microsoft.Phone.Tasks;

namespace DogTrainerWP8.ViewModels
{
	public class TrialViewModel : Screen
	{
		public void Buy()
		{
			var marketPlaceDetailTask = new MarketplaceDetailTask();
			marketPlaceDetailTask.Show();
		}
	}
}
