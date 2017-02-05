using Foundation;
using System;
using UIKit;
using AndriFannarUmfn.ksiRefrence;
using System.Collections.Generic;

namespace AndriFannarUmfn
{
	public partial class TableStatusViewController : UIViewController
	{
		List<LeagueClass> leaguTable;
		LeagueClass leagu;

		public TableStatusViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			// Setting Background photo
			var view = new UIView();
			view.Frame = new System.Drawing.RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width, (float)UIScreen.MainScreen.Bounds.Height);
			view.BackgroundColor = UIColor.FromRGB(31, 133, 64).ColorWithAlpha((System.nfloat)0.8);

			var imageView = new UIImageView(UIImage.FromFile("Images/Umfn.png"));
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;;
			imageView.AddSubview(view);

			this.leaguetable.BackgroundView = imageView;
			this.leaguetable.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;


			//Adding Header to tabel
			var headerView = new UIView();
			headerView.BackgroundColor = UIColor.FromRGB(31, 133, 64);
			headerView.Frame = new CoreGraphics.CGRect(0, 0, this.View.Bounds.Width, 50);

			var points = new UILabel();
			points.Text = "Stig";
			points.Frame = new CoreGraphics.CGRect(this.View.Bounds.Width - 30, 15, 30, 25);
			points.TextColor = UIColor.White;
			points.TextAlignment = UITextAlignment.Left;

			var mork = new UILabel();
			mork.Text = "+/-";
			mork.Frame = new CoreGraphics.CGRect(points.Frame.Left - 30, 15, 30, 25);
			mork.TextColor = UIColor.White;
			mork.TextAlignment = UITextAlignment.Left;

			var lostGames = new UILabel();
			lostGames.Text = "T";
			lostGames.Frame = new CoreGraphics.CGRect(mork.Frame.Left - 30, 15, 30, 25);
			lostGames.TextColor = UIColor.White;
			lostGames.TextAlignment = UITextAlignment.Left;

			var DrawGames = new UILabel();
			DrawGames.Text = "J";
			DrawGames.Frame = new CoreGraphics.CGRect(lostGames.Frame.Left - 30, 15, 30, 25);
			DrawGames.TextColor = UIColor.White;
			DrawGames.TextAlignment = UITextAlignment.Left;

			var WonGames = new UILabel();
			WonGames.Text = "S";
			WonGames.Frame = new CoreGraphics.CGRect(DrawGames.Frame.Left - 30, 15, 30, 25);
			WonGames.TextColor = UIColor.White;
			WonGames.TextAlignment = UITextAlignment.Left;

			var ManyGames = new UILabel();
			ManyGames.Text = "L";
			ManyGames.Frame = new CoreGraphics.CGRect(WonGames.Frame.Left - 30, 15, 30, 25);
			ManyGames.TextColor = UIColor.White;
			ManyGames.TextAlignment = UITextAlignment.Left;

			var Table = new UILabel();
			Table.Text = "Stöðutafla";
			Table.Frame = new CoreGraphics.CGRect(10, 15, 100, 25);
			Table.TextColor = UIColor.White;
			Table.TextAlignment = UITextAlignment.Left;


			headerView.AddSubview(points);
			headerView.AddSubview(mork);
			headerView.AddSubview(lostGames);
			headerView.AddSubview(DrawGames);
			headerView.AddSubview(WonGames);
			headerView.AddSubview(ManyGames);
			headerView.AddSubview(Table);

			this.leaguetable.TableHeaderView = headerView;



			//Adding to table
			CallWebService();
			leaguetable.ReloadData();
		}

		public void CallWebService()
		{

			mot mot = new mot();

			leaguTable = new List<LeagueClass>();

			mot.MotStadaAsync("35584");
			mot.MotStadaCompleted += (sender, e) =>
			{
				for (int i = 0; i < e.Result.ArrayMotStada.Length; i++)
				{
					leagu = new LeagueClass();
					leagu.FelagNumer = i + 1;
					leagu.NafnFelags = e.Result.ArrayMotStada[i].FelagNafn;
					leagu.LeikirAlls = e.Result.ArrayMotStada[i].LeikirAlls;
					leagu.LeikirUnnir = e.Result.ArrayMotStada[i].LeikirUnnir;
					leagu.LeikirJafnt = e.Result.ArrayMotStada[i].LeikirJafnt;
					leagu.LeikirTap = e.Result.ArrayMotStada[i].LeikirTap;
					leagu.MorkMismunur = e.Result.ArrayMotStada[i].MorkMisMunur;
					leagu.Stig = e.Result.ArrayMotStada[i].Stig;
					leaguTable.Add(leagu);
				}
				leaguetable.Source = new LeagueTableSource(leaguTable);
				leaguetable.ReloadData();
				           
			};

		}

	}
}