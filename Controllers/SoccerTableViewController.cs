using Foundation;
using System;
using UIKit;
using AndriFannarUmfn.ksiRefrence;


namespace AndriFannarUmfn
{
    public partial class SoccerTableViewController : UIViewController
    {
        protected SoccerTableViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			//this.Title = "Leikir";
			//this.TabBarItem.Image = UIImage.FromFile("Images/Icons/SoccerBall.png");
		}

		public SoccerTableViewController()
		{
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.View.BackgroundColor = UIColor.Red;
			CallWebService();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void CallWebService()
		{

			mot mot = new mot();


			mot.MotStadaAsync("36431");

			mot.MotStadaCompleted += (object sender, MotStadaCompletedEventArgs e) =>
			{

				Console.WriteLine(e.Result.ArrayMotStada);
			};

		}
    }
}