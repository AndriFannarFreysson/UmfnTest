using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace AndriFannarUmfn
{
    public partial class SoccerGamesTable : UITableViewSource
    {
     	List<FelogOgLeikirClass> tableItems;


		public SoccerGamesTable(List<FelogOgLeikirClass> _tableItems)
		{
			tableItems = _tableItems;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("GamesCell") as SoccerGamesCell;

			if (cell == null)
			{
				cell = new SoccerGamesCell(new Foundation.NSString("GamesCell"));
			}
			cell.BackgroundColor = UIColor.Clear;
			cell.UpdateCell(tableItems[indexPath.Row].FelagHeimaNafn,
							tableItems[indexPath.Row].FelagUtiNafn,
			               	tableItems[indexPath.Row].MotNafn,
			                tableItems[indexPath.Row].UrslitHeima,
			               	tableItems[indexPath.Row].UrslitUti,
			               	tableItems[indexPath.Row].place,
			                UIImage.FromFile("Images/" + tableItems[indexPath.Row].FelagUtiNafn),
			                UIImage.FromFile("Images/" + tableItems[indexPath.Row].FelagHeimaNafn),
			               	tableItems[indexPath.Row].date);

			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
		}

		public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 70f;
		}
    }
}