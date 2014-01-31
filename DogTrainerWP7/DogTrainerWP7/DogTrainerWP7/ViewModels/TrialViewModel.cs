

using Microsoft.Phone.Tasks;

namespace DogTrainerWP7.ViewModels
{
	public class TrialViewModel
	{
		public void Buy()
		{
			var marketPlaceDetailTask = new MarketplaceDetailTask();
			marketPlaceDetailTask.Show();
		}
	}
}
