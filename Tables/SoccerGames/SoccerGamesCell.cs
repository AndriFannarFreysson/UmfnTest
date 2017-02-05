using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;


namespace AndriFannarUmfn
{
	public class SoccerGamesCell :  UITableViewCell
	{
		public static readonly NSString Key = new NSString("SoccerGameCell");
		public static readonly UINib Nib;

		UILabel HomeTeam, AwayTeam, MotNafn, HomeTeamScore, AwayTeamScore, comma, place, dateText, timeOfGame;

		UIImageView HomeImage, AwayImage;


		public SoccerGamesCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Blue;
			ContentView.BackgroundColor = UIColor.Clear;

			HomeTeam = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			AwayTeam = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Right

			};
			MotNafn = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 10f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left

			};
			HomeTeamScore = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 18f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center

			};
			AwayTeamScore = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 18f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center

			};
			comma = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 18f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center

			};
			place = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 10f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Right
			};

			dateText = new UILabel()
			{ 
				Font = UIFont.FromName("Helvetica", 10f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center
			};

			timeOfGame = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 18f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center
			};


			HomeImage = new UIImageView();
			HomeImage.ContentMode = UIViewContentMode.ScaleAspectFit;
			HomeImage.BackgroundColor = UIColor.Clear;

			AwayImage = new UIImageView();
			AwayImage.ContentMode = UIViewContentMode.ScaleAspectFit;
			AwayImage.BackgroundColor = UIColor.Clear;


			ContentView.AddSubviews(new UIView[] { HomeTeam, AwayTeam, MotNafn, HomeTeamScore, AwayTeamScore, comma, place, HomeImage, AwayImage, dateText, timeOfGame});
		}

		public void UpdateCell(string _homeTeam, string _awayTeam, string _motNafn, string _homeTeamScore, string _awayTeamScore, string _place, UIImage homeimage, UIImage awayimage, DateTime _date)
		{
			HomeTeam.Text = _homeTeam;
			AwayTeam.Text = _awayTeam;
			MotNafn.Text = _motNafn;
			place.Text = _place;
			dateText.Text = _date.Day.ToString() + "/" + _date.Month.ToString() + "/" + _date.Year.ToString();


			if (_homeTeamScore != "")
			{
				HomeTeamScore.Text = _homeTeamScore;
				AwayTeamScore.Text = _awayTeamScore;
				comma.Text = "-";
			}
			else {
				timeOfGame.Text = _date.TimeOfDay.ToString().Substring(0,5);
			}

			List<string> names = new List<string> { "Afturelding", "Augnablik", "Dalvik:Reynir", "Haukar", "HK", "Höttur", "KF", "Njarðvík", "Random", "Sindri"};


			if (names.Any(str => str.Contains(_homeTeam)))
			{
				HomeImage.Image = UIImage.FromFile("Images/" + _homeTeam + ".png");
			}
			else { 
				HomeImage.Image = UIImage.FromFile("Images/Random.png");
			}


			if (names.Any(str => str.Contains(_awayTeam)))
			{
				AwayImage.Image = UIImage.FromFile("Images/" + _awayTeam + ".png");
			}
			else {
				AwayImage.Image = UIImage.FromFile("Images/Random.png");
			}

		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();


			HomeTeam.Frame = new CGRect(20, 30, 80, 25);
			AwayTeam.Frame = new CGRect(20, 30, this.Frame.Width - 40, 25);
			MotNafn.Frame = new CGRect(10, 2, 100, 20);
			comma.Frame = new CGRect(this.Frame.Width / 2 - 10, 30, 20, 25);
			HomeTeamScore.Frame = new CGRect(comma.Frame.Left - 15, 30, 15, 25);
			AwayTeamScore.Frame = new CGRect(comma.Frame.Right, 30, 15, 25);
			place.Frame = new CGRect(2, 2, this.Frame.Width - 10, 25);
			HomeImage.Frame = new CGRect(HomeTeam.Frame.Right + 10, 10, 40, ContentView.Bounds.Height - 10);
			AwayImage.Frame = new CGRect(AwayTeamScore.Frame.Right + 10, 10, 40, ContentView.Bounds.Height - 10);
			dateText.Frame = new CGRect(this.Frame.Width / 2 - 50, 2, 100, 20);
			timeOfGame.Frame = new CGRect(this.Frame.Width / 2 - 40, 30, 80, 25);

		}

	}
}
