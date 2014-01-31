using System;
using Caliburn.Micro;
using Microsoft.Phone.Tasks;

namespace DogTrainerWP8.ViewModels
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
										Body = String.Empty, 
										To = "linda_czinner_dev@outlook.com"
			                       	};

			emailComposeTask.Show();
		}

	}
}
