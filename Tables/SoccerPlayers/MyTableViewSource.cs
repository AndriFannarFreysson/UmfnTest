using System;
using System.Collections.Generic;
using UIKit;

namespace AndriFannarUmfn
{
	public class MyTableViewSource : UITableViewSource
	{

		List<ViewController.SoccerPlayers> tableItems;

		ViewController owner;

		//UINavigationController owner;

		public MyTableViewSource(List<ViewController.SoccerPlayers> _tableItems, ViewController owner)
		{
			tableItems = _tableItems;
			this.owner = owner;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("tableViewCell") as MyCustomCell;

			if (cell == null)
			{
				cell = new MyCustomCell(new Foundation.NSString("tableViewCell"));
			}
			cell.BackgroundColor = UIColor.Clear;
			cell.UpdateCell(tableItems[indexPath.Row].Name,
			                tableItems[indexPath.Row].Number, 
			                UIImage.FromFile(tableItems[indexPath.Row].Image));
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{


			SoccerPlayersDetailView soccerView = new SoccerPlayersDetailView(tableItems[indexPath.Row].Name,
			                                                                 tableItems[indexPath.Row].Image,
			                                                                 tableItems[indexPath.Row].DateOfBirth,
			                                                                 tableItems[indexPath.Row].PlayerPosition,
																			tableItems[indexPath.Row].ArrivedInNjardvik);

			//owner.PresentViewController(soccerView, true, null);
			owner.NavigationController.PushViewController(soccerView, true);
			tableView.DeselectRow(indexPath, true);
		}

		public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 60f;
		}
	}
}
