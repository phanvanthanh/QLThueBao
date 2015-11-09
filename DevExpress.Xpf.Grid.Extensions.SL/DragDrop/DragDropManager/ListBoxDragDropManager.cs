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

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid.DragDrop;
using System.ComponentModel;
#if !SL
#else
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid {
	public class ListBoxDragDropManager : DragDropManagerBase {
		ListBoxDropEventHandler DropEventHandler;
		ListBoxDroppedEventHandler DroppedEventHandler;
		ListBoxDragOverEventHandler DragOverEventHandler;
		ListBoxStartDragEventHandler StartDragEventHandler;
		#region inner classes
		public class ListBoxDragSource : SupportDragDropBase {
			protected override FrameworkElement Owner { get { return listBox; } }
			readonly ListBoxEdit listBox;
			public ListBoxDragSource(ListBoxDragDropManager dragDropManager, ListBoxEdit listBox)
				: base(dragDropManager) {
				this.listBox = listBox;
			}
			protected override FrameworkElement SourceElementCore {
				get { return listBox; }
			}
			protected override IList GetDraggingRows(MouseButtonEventArgs e) {
#if SL
				Point location = LayoutHelper.GetRelativeElementRect(listBox, LayoutHelper.FindRoot(listBox) as UIElement).TopLeft();
				Point mousePosition = e.GetPosition(listBox);
				PointHelper.Offset(ref location, mousePosition.X, mousePosition.Y);
				HitTestResult hitTestResult = HitTestHelper.HitTest(listBox, location);	
#else
				HitTestResult hitTestResult = VisualTreeHelper.HitTest(listBox, e.GetPosition(listBox));		
#endif
				ListBoxItem item = LayoutHelper.FindParentObject<ListBoxItem>(hitTestResult.VisualHit);
				if(item != null) {
					List<object> list = new List<object>(listBox.SelectedItems.Cast<object>());
					if(!list.Contains(item.Content))
						list.Add(item.Content);
					return list;
				}
				return null;
			}
		}
		#endregion
		public ListBoxDragDropManager() { }
		public ListBoxEdit ListBox { get { return (ListBoxEdit)AssociatedObject; } }
		#region Events
		[Category("Events")]
		public event ListBoxDragOverEventHandler DragOver {
			add { DragOverEventHandler += value; }
			remove { DragOverEventHandler -= value; }
		}
		[Category("Events")]
		public event ListBoxDropEventHandler Drop {
			add { DropEventHandler += value; }
			remove { DropEventHandler -= value; }
		}
		[Category("Events")]
		public event ListBoxDroppedEventHandler Dropped {
			add { DroppedEventHandler += value; }
			remove { DroppedEventHandler -= value; }
		}
		[Category("Events")]
		public event ListBoxStartDragEventHandler StartDrag {
			add { StartDragEventHandler += value; }
			remove { StartDragEventHandler -= value; }
		}
		#endregion
		protected internal override IList ItemsSource { get { return ListBox.ItemsSource as IList; } }
		protected internal override void OnDrop(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			ListBoxDropEventArgs e = RaiseDropEvent(sourceManager);
			if(!e.Handled) {
				if(sourceManager.DraggingRows.Count > 0 && AllowDrop && !ReferenceEquals(this, sourceManager)) {
					foreach(object obj in sourceManager.DraggingRows) {
						object rawObject = sourceManager.GetObject(obj);
						sourceManager.GetSource(obj).Remove(rawObject);
						ItemsSource.Add(rawObject);
					}
				}
			}
			RaiseDroppedEvent(sourceManager, e.DraggedRows);
		}
		void RaiseDroppedEvent(DragDropManagerBase sourceManager, IList draggedRows) {
			if(DroppedEventHandler != null) {
				ListBoxDroppedEventArgs e = new ListBoxDroppedEventArgs() {
					ListBoxEdit = ListBox,
					Manager = this,
					DraggedRows = draggedRows,
					SourceManager = sourceManager,
				};
				DroppedEventHandler(this, e);
			}
		}
		ListBoxDropEventArgs RaiseDropEvent(DragDropManagerBase sourceManager) {
			ListBoxDropEventArgs e = new ListBoxDropEventArgs() {
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
				DraggedRows = sourceManager.DraggingRows,
				ListBoxEdit = ListBox,
			};
			if(DropEventHandler != null)
				DropEventHandler(this, e);
			return e;
		}
		protected internal override void OnDragOver(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			base.OnDragOver(sourceManager, source, pt);
			ListBoxDragOverEventArgs e = RaiseDragOverEvent(sourceManager, pt);
			if(!e.Handled)
				if(sourceManager.DraggingRows.Count > 0 && AllowDrop && !ReferenceEquals(this, sourceManager)) {
					sourceManager.SetDropTargetType(DropTargetType.DataArea);
					ShowListBoxDropMarker();
				}
		}
		ListBoxDragOverEventArgs RaiseDragOverEvent(DragDropManagerBase sourceManager, Point pt) {
			ListBoxDragOverEventArgs e = new ListBoxDragOverEventArgs(sourceManager.DraggingRows) {
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
			};
			if(DragOverEventHandler != null)
				DragOverEventHandler(this, e);
			return e;
		}
		protected void ShowListBoxDropMarker() {
			ShowDropMarker(ListBox, TableDragIndicatorPosition.None);
		}
		protected override void OnAttached() {
			base.OnAttached();
			if(ListBox != null) {
				DragDropManagerBase.SetDragDropManager(ListBox, this);
				DragDropHelper = new DragDropElementHelper(new ListBoxDragSource(this, ListBox));
				DragManager.SetDropTargetFactory(ListBox, new DragDropManagerDropTargetFactory());
			}
		}
	}
}
