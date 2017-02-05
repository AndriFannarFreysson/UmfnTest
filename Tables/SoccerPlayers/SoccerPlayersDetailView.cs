using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;

namespace AndriFannarUmfn
{
	public class SoccerPlayersDetailView : UIViewController
	{

		ViewController.SoccerPlayers currentTask { get; set; }

		string name;
		string image;
		string dateOfBirth;
		string position;
		string arrived;

		/*public SoccerPlayersDetailView(IntPtr handle) : base (handle)
    	{

		}*/

		public SoccerPlayersDetailView(string _name, string _image, string _dateOfBirth, string _position, string _arrived)
		{
			name = _name;
			this.Title = name;
			image = _image;
			position = _position;
			dateOfBirth = _dateOfBirth;
			arrived = _arrived;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var view = new UIView();
			//view.Frame = new System.Drawing.RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width, (float)UIScreen.MainScreen.Bounds.Height);
			view.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
			view.BackgroundColor = UIColor.FromRGB(31, 133, 64).ColorWithAlpha((System.nfloat)0.8);

			var imageView = new UIImageView(UIImage.FromFile("Images/Umfn.png"));
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			//imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);

			imageView.AddSubview(view);
			imageView.SendSubviewToBack(view);

			this.View = imageView;

			addingDetailElements();


		}


		public void addingDetailElements() 
		{

			UIView line = new UIView();
			line.BackgroundColor = UIColor.White;

			UIView line1 = new UIView();
			line1.BackgroundColor = UIColor.White;

			UIView line2 = new UIView();
			line2.BackgroundColor = UIColor.White;

			UIView line3 = new UIView();
			line3.BackgroundColor = UIColor.White;


			UILabel Name = new UILabel();
			Name.TextColor = UIColor.White;
			Name.Font = UIFont.SystemFontOfSize(17);
			Name.Text = name;

			UILabel Name2 = new UILabel();
			Name2.TextColor = UIColor.White;
			Name2.Font = UIFont.SystemFontOfSize(12);
			Name2.Text = "Nafn:";

			UILabel Position = new UILabel();
			Position.TextColor = UIColor.White;
			Position.Font = UIFont.SystemFontOfSize(17);
			Position.Text = position;

			UILabel Position2 = new UILabel();
			Position2.TextColor = UIColor.White;
			Position2.Font = UIFont.SystemFontOfSize(12);
			Position2.Text = "Staða:";

			UILabel DateOfBirth = new UILabel();
			DateOfBirth.TextColor = UIColor.White;
			DateOfBirth.Font = UIFont.SystemFontOfSize(17);
			DateOfBirth.Text = dateOfBirth;

			UILabel DateOfBirth2 = new UILabel();
			DateOfBirth2.TextColor = UIColor.White;
			DateOfBirth2.Font = UIFont.SystemFontOfSize(12);
			DateOfBirth2.Text = "Fæðingarár:";

			UILabel Arrived = new UILabel();
			Arrived.TextColor = UIColor.White;
			Arrived.Font = UIFont.SystemFontOfSize(17);
			Arrived.Text = arrived;

			UILabel Arrived2 = new UILabel();
			Arrived2.TextColor = UIColor.White;
			Arrived2.Font = UIFont.SystemFontOfSize(12);
			Arrived2.Text = "Kom  í félag:";

			UIImageView Image = new UIImageView();
			Image.ContentMode = UIViewContentMode.ScaleAspectFit;
			//Image.BackgroundColor = UIColor.Purple;
			Image.Image = UIImage.FromFile(image);


			Image.Frame = new CGRect(0, 100, UIScreen.MainScreen.Bounds.Width, 250);
			Name.Frame = new CGRect(20, Image.Frame.Bottom + 25, 200, 25);
			Name2.Frame = new CGRect(20, Image.Frame.Bottom + 5, 100, 25);
			line.Frame = new CGRect(0, Name.Frame.Bottom + 5, 300, 2);
			Position.Frame = new CGRect(20, Name.Frame.Bottom + 25, 200, 25);
			Position2.Frame = new CGRect(20, Name.Frame.Bottom + 5, 100, 25);
			line1.Frame = new CGRect(0, Position.Frame.Bottom + 5, 300, 2);
			DateOfBirth.Frame = new CGRect(20, Position.Frame.Bottom + 25, 200, 25);
			DateOfBirth2.Frame = new CGRect(20, Position.Frame.Bottom + 5, 100, 25);
			line2.Frame = new CGRect(0, DateOfBirth.Frame.Bottom + 5, 300, 2);
			Arrived.Frame = new CGRect(20, DateOfBirth.Frame.Bottom + 25, 200, 25);
			Arrived2.Frame = new CGRect(20, DateOfBirth.Frame.Bottom + 5, 100, 25);
			line3.Frame = new CGRect(0, Arrived.Frame.Bottom + 5, 300, 2);


			View.AddSubview(Name);
			View.AddSubview(Image);
			View.AddSubview(Position);
			View.AddSubview(DateOfBirth);
			View.AddSubview(Arrived);

			View.AddSubview(Name2);
			View.AddSubview(Position2);
			View.AddSubview(DateOfBirth2);
			View.AddSubview(Arrived2);

			View.AddSubview(line);
			View.AddSubview(line1);
			View.AddSubview(line2);
			View.AddSubview(line3);
		
		}


	}
}
