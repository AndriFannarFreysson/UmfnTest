using System;
using System.Collections.Generic;
using UIKit;
using System.Net.NetworkInformation;
using AndriFannarUmfn.ksiRefrence;

namespace AndriFannarUmfn
{
	public partial class SoccerGamesViewController : UIViewController
	{
		List<FelogOgLeikirClass> gettingGames = new List<FelogOgLeikirClass>();
		FelogOgLeikirClass game = new FelogOgLeikirClass();

		protected SoccerGamesViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.Title = "Games";
			CallWebService();

		}

		public SoccerGamesViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.

			table = new SoccerGamesTable(gettingGames, this);
		}

		public static void CallWebService()
		{

			System.DateTime fra = new System.DateTime(2015, 5, 5);
			System.DateTime til = new System.DateTime(2015, 10, 10);

			mot mot = new mot();


			mot.FelogLeikirAsync("260", "", "111", "1", fra, til);
			mot.FelogLeikir("260", "", "111", "1", fra, til);

			List<FelogOgLeikirClass> gettingGames = new List<FelogOgLeikirClass>();
			FelogOgLeikirClass game = new FelogOgLeikirClass();

			mot.FelogLeikirCompleted += (object sender, FelogLeikirCompletedEventArgs e) =>
			{
				

				for (int i = 0; i < e.Result.ArrayFelogLeikir.Length; i++)
				{
					game.FelagHeimaNafn = e.Result.ArrayFelogLeikir[i].FelagHeimaNafn;
					game.FelagUtiNafn = e.Result.ArrayFelogLeikir[i].FelagUtiNafn;
					game.VollurNafn = e.Result.ArrayFelogLeikir[i].VollurNafn;
					game.MotNafn = e.Result.ArrayFelogLeikir[i].MotNafn;
					game.Flokkur = e.Result.ArrayFelogLeikir[i].Flokkur;
					game.date = e.Result.ArrayFelogLeikir[i].LeikDagur;
					gettingGames.Add(game);

				}

			};

		}
	}
}

