using Caliburn.Micro;
using Microsoft.Phone.Tasks;

namespace DogTrainerWP7.ViewModels
{
	public class AboutViewModel : Screen
	{
		public void CreateReview()
		{
			var task = new MarketplaceReviewTask();
			task.Show();
		}

		public void SendMail()
		{
			var emailComposeTask = new EmailComposeTask
			                       	{
			                       		Subject = "Dog Trainer", 
										Body = string.Empty, 
										To = "dogtrainerWP7@gmail.com"
			                       	};

			emailComposeTask.Show();
		}

	}
}
