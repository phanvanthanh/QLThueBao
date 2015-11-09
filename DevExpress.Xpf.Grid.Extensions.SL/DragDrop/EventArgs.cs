#region Copyright (c) 2000-2012 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{                                                                   }
{                                                                   }
{       Copyright (c) 2000-2012 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2000-2012 Developer Express Inc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.Editors;
namespace DevExpress.Xpf.Grid.DragDrop {
	public abstract class DragDropEventArgs : EventArgs {
		public DragDropEventArgs(IList dragRows) {
			DraggedRows = dragRows;
		}
		public DragDropEventArgs() { }
		public IList DraggedRows { get; internal set; }
		public DragDropManagerBase SourceManager { get; internal set; }
	}
	#region Drop
	abstract public class DropEventArgs : DragDropEventArgs {
		public bool Handled { get; set; }
	}
	public class ListBoxDropEventArgs : DropEventArgs {
		public ListBoxDragDropManager Manager { get; internal set; }
		public ListBoxEdit ListBoxEdit { get; internal set; }
	}
	abstract public class DataControlDropEventArgs : DropEventArgs {
		public DropTargetType DropTargetType { get; internal set; }
	}
	public class TreeListDropEventArgs : DataControlDropEventArgs {
		public TreeListNode TargetNode { get; internal set; }
		public TreeListDragDropManager Manager { get; internal set; }
		public TreeListViewHitInfo HitInfo { get; internal set; }
		public GridDataControlBase DataControl { get; internal set; }
	}
	public class GridDropEventArgs : DataControlDropEventArgs {
		public int TargetRowHandle { get; internal set; }
		public GridDragDropManager Manager { get; internal set; }
		public TableViewHitInfo HitInfo { get; internal set; }
		public GridControl GridControl { get; internal set; } 
	}
	public delegate void TreeListDropEventHandler(object sender, TreeListDropEventArgs e);
	public delegate void GridDropEventHandler(object sender, GridDropEventArgs e);
	public delegate void ListBoxDropEventHandler(object sender, ListBoxDropEventArgs e);
	#endregion
	#region Dropped
	public class TreeListDroppedEventArgs : DragDropEventArgs {
		public TreeListDroppedEventArgs() { }
		public TreeListNode TargetNode { get; internal set; }
		public TreeListDragDropManager Manager { get; internal set; }
		public TreeListViewHitInfo HitInfo { get; internal set; }
		public GridDataControlBase DataControl { get; internal set; }
		public DropTargetType DropTargetType { get; internal set; }
	}
	public class GridDroppedEventArgs : DragDropEventArgs {
		public GridDroppedEventArgs() { }
		public int TargetRowHandle { get; internal set; }
		public GridDragDropManager Manager { get; internal set; }
		public TableViewHitInfo HitInfo { get; internal set; }
		public GridControl GridControl { get; internal set; }
		public DropTargetType DropTargetType { get; internal set; }
	}
	public class ListBoxDroppedEventArgs : DragDropEventArgs {
		public ListBoxDragDropManager Manager { get; internal set; }
		public ListBoxEdit ListBoxEdit { get; internal set; }
	}
	public delegate void TreeListDroppedEventHandler(object sender, TreeListDroppedEventArgs e);
	public delegate void GridDroppedEventHandler(object sender, GridDroppedEventArgs e);
	public delegate void ListBoxDroppedEventHandler(object sender, ListBoxDroppedEventArgs e);
	#endregion
	#region DragOver
	public class DragDropDragOverEventArgs : DragDropEventArgs {
		public DragDropDragOverEventArgs(IList dragRows)
			: base(dragRows) {
			DraggedRows = dragRows;
			AllowDrop = true;
			ShowDragInfo = true;
			ShowDropMarker = true;
		}
		public bool AllowDrop { get; set; }
		public bool Handled { get; set; }
		public bool ShowDragInfo { get; set; }
		public bool ShowDropMarker { get; set; }
	}
	public class GridDragOverEventArgs : DragDropDragOverEventArgs {
		public GridDragOverEventArgs(TableViewHitInfo hitInfo, IList dragRows)
			: base(dragRows) {
			HitInfo = hitInfo;
		}
		public TableViewHitInfo HitInfo { get; internal set; }
		public GridDragDropManager Manager { get; internal set; }
	}
	public class TreeListDragOverEventArgs : DragDropDragOverEventArgs {
		public TreeListDragOverEventArgs(TreeListViewHitInfo hitInfo, IList dragRows)
			: base(dragRows) {
			HitInfo = hitInfo;
		}
		public TreeListViewHitInfo HitInfo { get; internal set; }
		public TreeListDragDropManager Manager { get; internal set; }
	}
	public class ListBoxDragOverEventArgs : DragDropDragOverEventArgs {
		public ListBoxDragOverEventArgs(IList dragRows)
			: base(dragRows) {
		}
		public ListBoxDragDropManager Manager { get; internal set; }
	}
	public delegate void TreeListDragOverEventHandler(object sender, TreeListDragOverEventArgs e);
	public delegate void GridDragOverEventHandler(object sender, GridDragOverEventArgs e);
	public delegate void ListBoxDragOverEventHandler(object sender, ListBoxDragOverEventArgs e);
	#endregion
	#region StartDragging
	public class StartDragEventArgs : EventArgs {
		public bool CanDrag { get; set; }
	}
	public class TreeListStartDragEventArgs : StartDragEventArgs  {
		public TreeListViewHitInfo HitInfo { get; internal set; }
		public TreeListDragDropManager Manager { get; internal set; }
	}
	public class GridStartDragEventArgs : StartDragEventArgs {
		public TableViewHitInfo HitInfo { get; internal set; }
		public GridDragDropManager Manager { get; internal set; }
	}
	public class ListBoxStartDragEventArgs : StartDragEventArgs {
		public ListBoxDragDropManager Manager { get; internal set; }
	}
	public delegate void TreeListStartDragEventHandler(object sender, TreeListStartDragEventArgs e);
	public delegate void GridStartDragEventHandler(object sender, GridStartDragEventArgs e);
	public delegate void ListBoxStartDragEventHandler(object sender, GridStartDragEventArgs e);
	#endregion
}
