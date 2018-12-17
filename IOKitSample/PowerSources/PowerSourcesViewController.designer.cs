// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace IOKitSample
{
	[Register ("PowerSourcesViewController")]
	partial class PowerSourcesViewController
	{
		[Outlet]
		AppKit.NSTableView detailsTable { get; set; }

		[Outlet]
		AppKit.NSOutlineView sourcesOutline { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (sourcesOutline != null) {
				sourcesOutline.Dispose ();
				sourcesOutline = null;
			}

			if (detailsTable != null) {
				detailsTable.Dispose ();
				detailsTable = null;
			}
		}
	}
}
