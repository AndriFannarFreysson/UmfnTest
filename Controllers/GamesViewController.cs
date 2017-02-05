using System;
using System.Collections.Generic;
using UIKit;
using System.Net.NetworkInformation;
using AndriFannarUmfn.ksiRefrence;

namespace AndriFannarUmfn
{
	public partial class GamesViewController : UIViewController
	{
		List<FelogOgLeikirClass> gettingGames;
		FelogOgLeikirClass game;

		protected GamesViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			//this.Title = "Leikir";
			//this.TabBarItem.Image = UIImage.FromFile("Images/Icons/SoccerBall.png");
		}

		public GamesViewController()
		{
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
		}

		public override void ViewDidLoad()
		{
			
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);

			var view = new UIView();
			view.Frame = new System.Drawing.RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width, (float)UIScreen.MainScreen.Bounds.Height);
			view.BackgroundColor = UIColor.FromRGB(31, 133, 64).ColorWithAlpha((System.nfloat)0.8);

			var imageView = new UIImageView(UIImage.FromFile("Images/Umfn.png"));
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			//imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);
			imageView.AddSubview(view);
			this.tableSoccer.BackgroundView = imageView;
			this.tableSoccer.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

			//tableSoccer.Source = new SoccerGamesTable(gettingGames);

			CallWebService();

			tableSoccer.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


		public void CallWebService()
		{

			System.DateTime fra = new System.DateTime(2016, 9, 10);
			System.DateTime til = new System.DateTime(2017, 3, 10);

			mot mot = new mot();


			mot.FelogLeikirAsync("260", "", "111", "1", fra, til);
			//mot.FelogLeikir("260", "", "111", "1", fra, til);

			gettingGames = new List<FelogOgLeikirClass>();

			mot.FelogLeikirCompleted += (object sender, FelogLeikirCompletedEventArgs e) =>
			{

					for (int i = 0; i < e.Result.ArrayFelogLeikir.Length; i++)
					{
						game = new FelogOgLeikirClass();
						game.FelagHeimaNafn = e.Result.ArrayFelogLeikir[i].FelagHeimaNafn;
						game.FelagUtiNafn = e.Result.ArrayFelogLeikir[i].FelagUtiNafn;
						game.VollurNafn = e.Result.ArrayFelogLeikir[i].VollurNafn;
						game.MotNafn = e.Result.ArrayFelogLeikir[i].MotNafn;
						game.Flokkur = e.Result.ArrayFelogLeikir[i].Flokkur;
						game.date = e.Result.ArrayFelogLeikir[i].LeikDagur;
						game.UrslitUti = e.Result.ArrayFelogLeikir[i].UrslitUti;
						game.UrslitHeima = e.Result.ArrayFelogLeikir[i].UrslitHeima;
						game.place = e.Result.ArrayFelogLeikir[i].VollurNafn;
						gettingGames.Add(game);

					}
				tableSoccer.Source = new SoccerGamesTable(gettingGames);
				tableSoccer.ReloadData();
			};

		}
	}
}

