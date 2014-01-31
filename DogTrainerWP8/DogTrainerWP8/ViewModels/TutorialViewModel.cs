using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using DogTrainerWP8.Models;
using Microsoft.Phone.Shell;
using MyToolkit.Multimedia;

namespace DogTrainerWP8.ViewModels
{
	public class TutorialViewModel : Screen
	{
		public ObservableCollection<Training> Trainings { get; set; }

		public bool IsTrial
		{
			get { return IoC.Get<bool>("IsTrial"); }
		}

		public TutorialViewModel()
		{
			Trainings = new ObservableCollection<Training>
			{
				new Training { TrainingName = "What is clicker training?", TrainingLink = "_wv1uvvqaSw" },
				new Training { TrainingName = "Teaching the name", TrainingLink = "bNObVSQk8K4" },
				new Training { TrainingName = "Touch", TrainingLink = "LjWfXi43WSk" },
				new Training { TrainingName = "Come", TrainingLink = "PL9Rk-8KF9I" },
				new Training { TrainingName = "Sit", TrainingLink = "ESZozdpmQMs" },
				new Training { TrainingName = "Stay", TrainingLink = "Vk4PPcE1CqY" },
				new Training { TrainingName = "Down", TrainingLink = "WmwJWAAv6so" },
				new Training { TrainingName = "Go back", TrainingLink = "GD3nGIjonsY" },
				new Training { TrainingName = "Fetch", TrainingLink = "Ccw1uwvbx00" },
				new Training { TrainingName = "Drop", TrainingLink = "1lQ8umLaTpI" },
				new Training { TrainingName = "Building eye contact", TrainingLink = "9oo6tcSxWWg" },
				new Training { TrainingName = "Stop jumping up", TrainingLink = "lC_OKgQFgzw" },
				new Training { TrainingName = "Loose leash walking", TrainingLink = "sFgtqgiAKoQ" },
				new Training { TrainingName = "Take food nicely", TrainingLink = "-s63pJAvLPM" },
				new Training { TrainingName = "Stop biting", TrainingLink = "ZKjk84OkzcI" },
			};
		}

		public void VideoSelectionChanged(SelectionChangedEventArgs e)
		{
			var videoId = ((Training) e.AddedItems[0]).TrainingLink;
			IoC.Get<INavigationService>().UriFor<VideoViewModel>().WithParam(p => p.YoutubeId, videoId).Navigate();
		}
	}
}
