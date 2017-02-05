using System;

using Foundation;
using UIKit;
using CoreGraphics;

namespace AndriFannarUmfn
{
	public partial class MyCustomCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("MyCustomCell");
		public static readonly UINib Nib;

		UILabel number, name;
		UIImageView myImages;

		public MyCustomCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Blue;
			ContentView.BackgroundColor = UIColor.Clear;

			number = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center
			};
			name = new UILabel()
			{
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left
				                                           
			};

			myImages = new UIImageView();
			myImages.ContentMode = UIViewContentMode.ScaleAspectFit;

			ContentView.AddSubviews(new UIView[] { name, number, myImages });
		}

		public void UpdateCell(string _name, string _number, UIImage image) 
		{
			number.Text = _number;
			name.Text = _name;
			myImages.Image = image;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			myImages.Frame = new CGRect(35, 5, 50, ContentView.Bounds.Height - 5);
			name.Frame = new CGRect(100, 15, 230, 25);
			number.Frame = new CGRect(5, 15, 20, 25);

		}


	}
}
