using System;
using System.Collections.Generic;
using AppKit;
using CoreFoundation;
using Foundation;
using IOKit;

namespace IOKitSample
{
	public partial class PowerSourcesViewController : NSViewController, INSOutlineViewDelegate, INSOutlineViewDataSource, INSTableViewDataSource, INSTableViewDelegate
	{
		private IOPowerSourcesInfo powerSourcesInfo;
		private IOPowerSourcesExternalPowerAdapterDetails adapterDetails;
		private CFRunLoopSource powerSourceNotification;
		private readonly List<PowerSourceGroup> data = new List<PowerSourceGroup>();
		private readonly List<(string Name, string Value)> details = new List<(string, string)>();

		public PowerSourcesViewController(IntPtr handle)
			: base(handle)
		{
		}

		public override void ViewDidAppear()
		{
			base.ViewDidAppear();

			powerSourceNotification = IOPowerSources.CreatePowerSourceNotification(_ =>
			{
				UpdateInformation();
			});

			CFRunLoop.Current.AddSource(powerSourceNotification, CFRunLoop.ModeDefault);

			UpdateInformation();
		}

		public override void ViewWillDisappear()
		{
			CFRunLoop.Current.RemoveSource(powerSourceNotification, CFRunLoop.ModeDefault);

			base.ViewWillDisappear();
		}

		private void UpdateInformation()
		{
			powerSourcesInfo = IOPowerSources.GetPowerSourcesInfo();
			adapterDetails = IOPowerSources.GetExternalPowerAdapterDetails();

			data.Clear();
			data.AddRange(new[]
			{
				new PowerSourceGroup(powerSourcesInfo),
				new PowerSourceGroup(adapterDetails),
				new PowerSourceGroup(powerSourcesInfo.PowerSources)
			});

			sourcesOutline.ReloadData();
			sourcesOutline.ExpandItem(null, true);
			sourcesOutline.SelectRow(1, false);
		}

		// Power Sources - Data Source

		[Export("outlineView:numberOfChildrenOfItem:")]
		private nint GetChildrenCount(NSOutlineView outlineView, NSObject item)
		{
			if (item is PowerSourceGroup psg)
				return psg.Items.Count;

			return data.Count;
		}

		[Export("outlineView:isItemExpandable:")]
		private bool ItemExpandable(NSOutlineView outlineView, NSObject item)
		{
			if (item is PowerSourceGroup psg)
				return psg.Items.Count > 0;

			return false;
		}

		[Export("outlineView:child:ofItem:")]
		private NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item)
		{
			if (item is PowerSourceGroup psg)
				return psg.Items[(int)childIndex];

			return data[(int)childIndex];
		}

		[Export("outlineView:objectValueForTableColumn:byItem:")]
		private NSObject GetObjectValue(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item) =>
			item as PowerSourceItem;

		[Export("outlineView:viewForTableColumn:item:")]
		private NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
		{
			var id = item is PowerSourceGroup ? "HeaderCell" : "DataCell";

			var view = outlineView.MakeView(id, null) as NSTableCellView;
			view.TextField.StringValue = ((PowerSourceItem)item).Name;

			return view;
		}

		// Power Sources - Delegate

		[Export("outlineView:shouldCollapseItem:")]
		private bool ShouldCollapseItem(NSOutlineView outlineView, NSObject item) =>
			!(item is PowerSourceGroup);

		[Export("outlineView:shouldSelectItem:")]
		private bool ShouldSelectItem(NSOutlineView outlineView, NSObject item) =>
			!(item is PowerSourceGroup);

		[Export("outlineViewSelectionDidChange:")]
		private void SelectionDidChange(NSNotification notification)
		{
			if (!(notification.Object is NSOutlineView outlineView))
				return;

			var sel = outlineView.SelectedRow;
			var item = (PowerSourceItem)outlineView.ItemAtRow(sel);

			details.Clear();
			details.AddRange(item.GetDetails() ?? new (string, string)[0]);
			detailsTable.ReloadData();
		}

		// Details - Data Source

		[Export("tableView:objectValueForTableColumn:row:")]
		private NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, nint row) =>
			(NSString)details[(int)row].Name;

		[Export("numberOfRowsInTableView:")]
		private nint GetRowCount(NSTableView tableView) =>
			details.Count;

		// Details - Delegate

		[Export("tableView:viewForTableColumn:row:")]
		private NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			NSTableCellView view = null;

			var (Name, Value) = details[(int)row];

			if (tableColumn.Identifier == "NameColumn")
			{
				view = tableView.MakeView("NameCell", null) as NSTableCellView;
				view.TextField.StringValue = Name;
			}
			else if (tableColumn.Identifier == "ValueColumn")
			{
				view = tableView.MakeView("ValueCell", null) as NSTableCellView;
				view.TextField.StringValue = Value;
			}

			if (string.IsNullOrEmpty(Value))
				view.TextField.AttributedStringValue = new NSAttributedString(
					view.TextField.StringValue,
					foregroundColor: NSColor.Gray);

			return view;
		}

		[Export("tableView:shouldSelectRow:")]
		private bool ShouldSelectRow(NSTableView tableView, nint row) =>
			!string.IsNullOrEmpty(details[(int)row].Value);
	}
}
