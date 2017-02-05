using System;
using System.Collections.Generic;
using UIKit;

namespace AndriFannarUmfn
{
	public class LeagueTableSource : UITableViewSource
	{
		List<LeagueClass> tableItems;


		public LeagueTableSource(List<LeagueClass> _tableItems)
		{
			tableItems = _tableItems;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell("leagueTable") as LeagueTableCell;

			if (cell == null)
			{
				cell = new LeagueTableCell(new Foundation.NSString("leagueTable"));
			}
			cell.BackgroundColor = UIColor.Clear;
			cell.UpdateCell(tableItems[indexPath.Row].FelagNumer.ToString(),
							tableItems[indexPath.Row].NafnFelags,
							tableItems[indexPath.Row].LeikirAlls.ToString(),
			                tableItems[indexPath.Row].LeikirUnnir.ToString(),
			               tableItems[indexPath.Row].LeikirJafnt.ToString(),
			               tableItems[indexPath.Row].LeikirTap.ToString(),
			               tableItems[indexPath.Row].MorkMismunur.ToString(),
			               tableItems[indexPath.Row].Stig.ToString()); 

			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
		}

		public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 45f;
		}
	}
}
