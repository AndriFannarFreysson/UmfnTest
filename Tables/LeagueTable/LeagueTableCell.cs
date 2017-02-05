using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AndriFannarUmfn
{
	public class LeagueTableCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("LeagueTableCell");
		public static readonly UINib Nib;

		UILabel NumberOfTeam, NameOfTeam, ManyGames, GamesWon, GamesDraw, GamesLost, GoalsScored, Points;
		UIImageView image;

		public LeagueTableCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Blue;
			ContentView.BackgroundColor = UIColor.Clear;

			NumberOfTeam = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			NameOfTeam = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			ManyGames = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			GamesWon = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			GamesDraw = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			GamesLost = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			GoalsScored = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};
			Points = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
			};

			image = new UIImageView();
			image.ContentMode = UIViewContentMode.ScaleAspectFit;
			image.BackgroundColor = UIColor.Clear;



			ContentView.AddSubviews(new UIView[] { NumberOfTeam, NameOfTeam, ManyGames, GamesWon, GamesDraw, GamesLost, GoalsScored, Points, image});
		}


		public void UpdateCell(string _numberofteam, string _nameofteam, string _manygames, string _gameswon, string _gamesdraw, string _gameslost, string _goalscored, string _points)
		{
			NumberOfTeam.Text = _numberofteam;
			NameOfTeam.Text = _nameofteam;
			ManyGames.Text = _manygames;
			GamesWon.Text = _gameswon;
			GamesDraw.Text = _gamesdraw;
			GamesLost.Text = _gameslost;
			GoalsScored.Text = _goalscored;
			Points.Text = _points;

			List<string> names = new List<string> { "Afturelding", "Augnablik", "Dalvik:Reynir", "Haukar", "HK", "Höttur", "KF", "Njarðvík", "Random", "Sindri" };


			if (names.Any(str => str.Contains(_nameofteam)))
			{
				image.Image = UIImage.FromFile("Images/" + _nameofteam + ".png");
			}
			else {
				image.Image = UIImage.FromFile("Images/Random.png");
			}

				
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();


			//Appear on the right place of the Screeen
			Points.Frame = new CGRect(this.Bounds.Width - 30, 15, 30, 25);
			GoalsScored.Frame = new CGRect(Points.Frame.Left - 30, 15, 30, 25);
			GamesLost.Frame = new CGRect(GoalsScored.Frame.Left - 30, 15, 30, 25);
			GamesDraw.Frame = new CGRect(GamesLost.Frame.Left - 30, 15, 30, 25);
			GamesWon.Frame = new CGRect(GamesDraw.Frame.Left - 30, 15, 30, 25);
			ManyGames.Frame = new CGRect(GamesWon.Frame.Left - 30, 15, 30, 25);


			// Appear on the left place of Screen
			NumberOfTeam.Frame = new CGRect(10, 15, 20, 25);
			image.Frame = new CGRect(40, 5, 40, Bounds.Height - 5);
			NameOfTeam.Frame = new CGRect(image.Frame.Right + 20, 15, 100, 25);

		}

	}
}
