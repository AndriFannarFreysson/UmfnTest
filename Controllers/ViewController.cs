using System;
using System.Collections.Generic;
using UIKit;

namespace AndriFannarUmfn
{
	public partial class ViewController : UIViewController
	{

		List<SoccerPlayers> tableItems;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.Title = "Leikmenn";
			//this.TabBarItem.Image = UIImage.FromFile("Images/Icons/SoccerBall.png");
			addingBoys();
		}

		public ViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var view = new UIView();
			view.Frame = new System.Drawing.RectangleF(0, 0, (float)UIScreen.MainScreen.Bounds.Width, (float)UIScreen.MainScreen.Bounds.Height);
			view.BackgroundColor = UIColor.FromRGB(31,133,64).ColorWithAlpha((System.nfloat)0.8);

			var imageView = new UIImageView(UIImage.FromFile("Images/Umfn.png"));
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
			//imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);
			imageView.AddSubview(view);
			this.tableView.BackgroundView = imageView;

			this.tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			tableView.Source = new MyTableViewSource(tableItems, this);
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class SoccerPlayers
		{

			public int Id { get; set; }
			public string Name { get; set; }
			public string Image { get; set; }
			public string Number { get; set; }
			public string DateOfBirth { get; set; }
			public string PlayerPosition { get; set; }
			public string ArrivedInNjardvik { get; set;}


		}

		public void addingBoys()
		{
			tableItems = new List<SoccerPlayers>
			{

				new SoccerPlayers {Name= "Andri Fannar Freysson", Image= "Images/Styrmir_Gauti.png", Number="1", DateOfBirth="1/3/1992", PlayerPosition="Midja", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Styrmir Gauti Fjeldsted", Image= "Images/Styrmir_Gauti.png", Number="2", DateOfBirth="1/2/1992", PlayerPosition="Markmaður", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Helgi Már Vilbergsson", Image= "Images/Styrmir_Gauti.png", Number="3", DateOfBirth="1/2/1992", PlayerPosition="Framherji", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Rafn Markús Vilbergsson", Image= "Images/Styrmir_Gauti.png", Number="4", DateOfBirth="1/2/1992", PlayerPosition="Miðvörður", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Óli Ragnar Alexandersson", Image= "Images/Styrmir_Gauti.png", Number="6", DateOfBirth="1/2/1992", PlayerPosition="Kanttmaður", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Ólafur Helgi Jónsson", Image= "Images/Styrmir_Gauti.png", Number="7", DateOfBirth="1/2/1992", PlayerPosition="Midja", ArrivedInNjardvik="2015"},
				new SoccerPlayers {Name= "Brynjar Freyr Garðarsson", Image= "Images/Styrmir_Gauti.png", Number="8", DateOfBirth="1/2/1992", PlayerPosition="Midja", ArrivedInNjardvik="2015"}
			};
		}
	}
}
