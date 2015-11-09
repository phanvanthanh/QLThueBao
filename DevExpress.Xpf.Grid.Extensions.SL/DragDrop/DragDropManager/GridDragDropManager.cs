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
using System.ComponentModel;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;
using System.Collections;
using DevExpress.Xpf.Grid.DragDrop;
using DevExpress.Data.Access;
#if SL
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid {
	public class GridDragDropManager : DataViewDragDropManager {
		#region inner classes
		public class GridDragSource : SupportDragDropBase {
			GridDragDropManager GridDragDropManager { get { return (GridDragDropManager)dragDropManager; } }
			protected override FrameworkElement Owner { get { return GridDragDropManager.DataControl; } }
			public GridDragSource(DragDropManagerBase dragDropManager)
				: base(dragDropManager) {
			}
			protected override bool CanStartDragCore(MouseButtonEventArgs e) {
				return !GridDragDropManager.View.IsEditing && base.CanStartDragCore(e);
			}
			protected override FrameworkElement SourceElementCore {
				get { return GridDragDropManager.DataControl; }
			}
			protected override IList GetDraggingRows(MouseButtonEventArgs e) {
				TableViewHitInfo hitInfo = GridDragDropManager.GetHitInfo(e) as TableViewHitInfo;
				if(GridDragDropManager.IsInDataRow(hitInfo)) {
					return GridDragDropManager.GetSelectedRowsCopy();
				}
				if(GridDragDropManager.IsInGroupRow(hitInfo)) {
					return GridDragDropManager.GetChildRows(hitInfo.RowHandle);
				}
				return null;
			}
		}
		delegate void MoveRowsDelegate(DragDropManagerBase sourceManager, int targetRowHandle, DependencyObject hitElement);
		#endregion
		public GridDragDropManager() { }
		#region Events
		GridStartDragEventHandler StartDraggingEventHandler;
		GridDragOverEventHandler DragOverEventHandler;
		GridDropEventHandler DropEventHandler;
		GridDroppedEventHandler DroppedEventHandler;
		[Category("Events")]
		public event GridStartDragEventHandler StartDrag {
			add { StartDraggingEventHandler += value; }
			remove { StartDraggingEventHandler -= value; }
		}
		[Category("Events")]
		public event GridDragOverEventHandler DragOver {
			add { DragOverEventHandler += value; }
			remove { DragOverEventHandler -= value; }
		}
		[Category("Events")]
		public event GridDropEventHandler Drop {
			add { DropEventHandler += value; }
			remove { DropEventHandler -= value; }
		}
		[Category("Events")]
		public event GridDroppedEventHandler Dropped {
			add { DroppedEventHandler += value; }
			remove { DroppedEventHandler -= value; }
		}
		#endregion
		GridControl GridControl { get { return DataControl as GridControl; } }
		TableView TableView { get { return View as TableView; } }
		protected override ISupportDragDrop CreateDragSource(DataViewDragDropManager dataViewDragDropManager) {
			return new GridDragSource(dataViewDragDropManager);
		}
		public override DataViewBase View {
			get {
				if(GridControl != null)
					return GridControl.View;
				return null;
			}
		}
		internal List<object> GetSelectedRowsCopy() {
			return new List<object>(TableView.SelectedRows.Cast<object>());
		}
		internal bool IsInDataRow(TableViewHitInfo info) {
			return IsInRowCore(info) && !GridControl.IsGroupRowHandle(info.RowHandle);
		}
		internal bool IsInGroupRow(TableViewHitInfo info) {
			return IsInRowCore(info) && GridControl.IsGroupRowHandle(info.RowHandle);
		}
		bool IsInRowCore(TableViewHitInfo info) {
			return info.InRow && info.HitTest != TableViewHitTest.RowIndicator;
		}
		protected internal override void OnDrop(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			GridDropEventArgs e = RaiseDropEvent(sourceManager, pt);
			if(!e.Handled)
				PerformDropToView(sourceManager, pt, MoveSelectedRows, MoveSelectedRowsToGroup, AddRows);
			RaiseDroppedEvent(sourceManager, e);
		}
		protected override GridViewHitInfoBase GetHitInfo(DependencyObject element) {
			return TableView.CalcHitInfo(element);
		}
		internal List<object> GetChildRows(int groupRowHandle) {
			List<object> list = new List<object>();
			CollectGroupRowChildren(groupRowHandle, list);
			return list;
		}
		protected override void PerformDropToView(DragDropManagerBase sourceManager) {
			if((bool)LayoutHelper.GetTopLevelVisual(View).GetValue(DragManager.IsDraggingProperty))
				PerformDropToView(sourceManager, LastPosition, SetReorderDropInfo, SetMoveToGroupRowDropInfo, SetAddRowsDropInfo);
		}
		void PerformDropToView(DragDropManagerBase sourceManager, Point pt, MoveRowsDelegate reorderDelegate, MoveRowsDelegate moveToGroupDelegate, MoveRowsDelegate addRowsDelegate) {
			UIElement element = GetVisibleHitTestElement(pt);
			TableViewHitInfo hitInfo = TableView.CalcHitInfo(element);
			int insertRowHandle = hitInfo.RowHandle;
			if(BanDrop(insertRowHandle, hitInfo, sourceManager)) {
				ClearDragInfo(sourceManager);
				return;
			}
			if(GridControl.IsGroupRowHandle(insertRowHandle)) {
				moveToGroupDelegate(sourceManager, insertRowHandle, element);
				return;
			}
			if(IsSortedButNotGrouped() || hitInfo.HitTest == TableViewHitTest.DataArea) {
				if(sourceManager.DraggingRows.Count > 0 && GetDataAreaElement(element) != null && !ReferenceEquals(sourceManager, this)) {
					addRowsDelegate(sourceManager, insertRowHandle, element);
				} else {
					ClearDragInfo(sourceManager);
				}
				return;
			}
			if(insertRowHandle == GridControl.InvalidRowHandle) {
				ClearDragInfo(sourceManager);
				return;
			}
			if(GridControl.GroupCount > 0) {
				int groupRowHandle = GridControl.GetParentRowHandle(insertRowHandle);
				moveToGroupDelegate(sourceManager, groupRowHandle, element);
			} else {
				reorderDelegate(sourceManager, insertRowHandle, element);
			}
		}
		bool BanDrop(int insertRowHandle, TableViewHitInfo hitInfo, DragDropManagerBase sourceManager) {
			GridDragOverEventArgs e = RaiseDragOverEvent(hitInfo, sourceManager);
			return e.Handled ? !e.AllowDrop : !e.AllowDrop || InternalBanDrop(insertRowHandle, sourceManager);
		}
		bool InternalBanDrop(int insertRowHandle, DragDropManagerBase sourceManager) {
			return false;
		}
		GridDragOverEventArgs RaiseDragOverEvent(TableViewHitInfo hitInfo, DragDropManagerBase sourceManager) {
			GridDragOverEventArgs e = new GridDragOverEventArgs(hitInfo, sourceManager.DraggingRows) {
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
			};
			if(DragOverEventHandler != null)
				DragOverEventHandler(this, e);
			return e;
		}
		protected override void AddRow(DragDropManagerBase sourceManager, object row, int insertRowHandle) {
			sourceManager.ItemsSource.Remove(row);
			ItemsSource.Add(row);
		}
		void SetMoveToGroupRowDropInfo(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			GroupInfo[] groupInfo = GetGroupInfos(insertRowHandle);
			if(CanMoveSelectedRowsToGroup(sourceManager, groupInfo, hitElement)) {
				sourceManager.SetDropTargetType(DropTargetType.InsertRowsIntoGroup);
				sourceManager.ViewInfo.GroupInfo = groupInfo;
				sourceManager.ShowDropMarker(GetRowElement(hitElement), TableDragIndicatorPosition.None);
			} else {
				ClearDragInfo(sourceManager);
			}
		}
		void CollectGroupRowChildren(int groupRowHandle, IList list) {
			int childCount = GridControl.GetChildRowCount(groupRowHandle);
			for(int i = 0; i < childCount; i++) {
				int childRowHandle = GridControl.GetChildRowHandle(groupRowHandle, i);
				if(GridControl.IsGroupRowHandle(childRowHandle))
					CollectGroupRowChildren(childRowHandle, list);
				else
					list.Add(GridControl.GetRow(childRowHandle));
			}
		}
		bool IsSortedButNotGrouped() {
			return IsSorted() && !IsGrouped();
		}
		bool IsGrouped() {
			return GridControl.GroupCount > 0;
		}
		bool IsSorted() {
			return GridControl.SortInfo.Count > 0;
		}
		void MoveSelectedRows(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			object insertObject = GridControl.GetRow(insertRowHandle);
			if(insertObject == null || sourceManager.DraggingRows.Contains(GridControl.GetRow(insertRowHandle)))
				return;
			FrameworkElement row = GetRowElement(hitElement);
			DropTargetType dropTargetType = GetDropTargetType(row);
			if(dropTargetType == DropTargetType.None)
				return;
			int index = ItemsSource.IndexOf(insertObject);
			if(dropTargetType == DropTargetType.InsertRowsAfter)
				index++;
			GridControl.BeginDataUpdate();
			foreach(object obj in sourceManager.DraggingRows) {
				object sourceObject = sourceManager.GetObject(obj);
				if(ReferenceEquals(ItemsSource, sourceManager.GetSource(obj))) {
					if(index > ItemsSource.IndexOf(sourceObject))
						index--;
				}
				sourceManager.ItemsSource.Remove(sourceObject);
				ItemsSource.Insert(index, sourceObject);
				index++;
			}
			GridControl.EndDataUpdate();
			if(RestoreSelection) {
				int startRowHandle = GridControl.GetRowHandleByListIndex(ItemsSource.IndexOf(sourceManager.DraggingRows[0]));
				int endRowHandle = GridControl.GetRowHandleByListIndex(ItemsSource.IndexOf(sourceManager.DraggingRows[sourceManager.DraggingRows.Count - 1]));
				TableView.SelectRange(startRowHandle, endRowHandle);
			} else
				TableView.ClearSelection();
			TableView.FocusedRow = sourceManager.DraggingRows[0];
		}
		GridDropEventArgs RaiseDropEvent(DragDropManagerBase sourceManager, Point pt) {
			UIElement hitElement = GetVisibleHitTestElement(pt);
			TableViewHitInfo hitInfo = GetHitInfo(hitElement) as TableViewHitInfo;
			DropTargetType dropTargetType = GridControl.GroupCount > 0 ? DropTargetType.InsertRowsIntoGroup : GetDropTargetType(GetRowElement(hitElement));	
			return RaiseDropEvent(sourceManager, hitInfo, sourceManager.DraggingRows,
				hitInfo.HitTest == TableViewHitTest.DataArea ? DropTargetType.DataArea : dropTargetType);
		}
		GridDropEventArgs RaiseDropEvent(DragDropManagerBase sourceManager, TableViewHitInfo hitInfo, IList rows, DropTargetType dropTargetType) {
			GridDropEventArgs e = new GridDropEventArgs() {
				HitInfo = hitInfo,
				DraggedRows = rows,
				DropTargetType = dropTargetType,
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
				GridControl = GridControl,
			};
			if(DropEventHandler != null)
				DropEventHandler(this, e);
			return e;
		}
		void RaiseDroppedEvent(DragDropManagerBase sourceManager, GridDropEventArgs dropEventArgs){
			if(DroppedEventHandler != null) {
				GridDroppedEventArgs e = new GridDroppedEventArgs() {
					GridControl = GridControl,
					TargetRowHandle = dropEventArgs.TargetRowHandle,
					HitInfo = dropEventArgs.HitInfo,
					Manager = this,
					DraggedRows = dropEventArgs.DraggedRows,
					SourceManager = sourceManager,
					DropTargetType = dropEventArgs.DropTargetType,
				};
				DroppedEventHandler(this, e);
			}
		}
		void SetReorderDropInfo(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			FrameworkElement rowElement = GetRowElement(hitElement);
			TableDragIndicatorPosition dragIndicatorPosition = GetDragIndicatorPositionForRowElement(rowElement);
			if(dragIndicatorPosition != TableDragIndicatorPosition.None) {
				DropTargetType dropTargetType = dragIndicatorPosition == TableDragIndicatorPosition.Bottom ? DropTargetType.InsertRowsAfter : DropTargetType.InsertRowsBefore;
				sourceManager.SetDropTargetType(dropTargetType);
				sourceManager.ViewInfo.DropTargetRow = GridControl.GetRow(insertRowHandle);
				sourceManager.ShowDropMarker(rowElement, dragIndicatorPosition);
			} else {
				ClearDragInfo(sourceManager);
			}
		}
		void MoveSelectedRowsToGroup(DragDropManagerBase sourceManager, int groupRowHandle, DependencyObject hitElement) {
			GroupInfo[] groupInfo = GetGroupInfos(groupRowHandle);
			if(!CanMoveSelectedRowsToGroup(sourceManager, groupInfo, hitElement))
				return;
			foreach(object obj in sourceManager.DraggingRows) {
				foreach(GroupInfo item in groupInfo) {
					SetPropertyValue(sourceManager.GetObject(obj), item.FieldName, item.Value);
				}
				if(!ItemsSource.Contains(obj)) {
					sourceManager.ItemsSource.Remove(sourceManager.GetObject(obj));
					ItemsSource.Add(sourceManager.GetObject(obj));
				}
			}
		}
		protected override TableDragIndicatorPosition GetDragIndicatorPositionForRowElement(FrameworkElement rowElement) {
			if(rowElement == null)
				return TableDragIndicatorPosition.None;
#if !SL
			double point = Mouse.GetPosition(rowElement).Y;
#else
			double point = LastPosition.Y - LayoutHelper.GetRelativeElementRect(rowElement, View).Top;
#endif
			return point > rowElement.ActualHeight / 2 ?
							TableDragIndicatorPosition.Bottom :
							TableDragIndicatorPosition.Top;
		}
		bool CanMoveSelectedRowsToGroup(DragDropManagerBase sourceManager, GroupInfo[] groupInfos, DependencyObject hitElement) {
			if(GetRowElement(hitElement) == null)
				return false;
			foreach(object obj in sourceManager.DraggingRows) {
				if(!ItemsSource.Contains(obj))
					return true;
				foreach(GroupInfo groupInfo in groupInfos) {
					object value;
					if(groupInfo.FieldName.Contains(".")) {
						ComplexPropertyDescriptor complexDescr = new ComplexPropertyDescriptor(obj, groupInfo.FieldName);
						value = complexDescr.GetValue(obj);
					} else
						value = TypeDescriptor.GetProperties(obj)[groupInfo.FieldName].GetValue(obj);
					if(!object.Equals(value, groupInfo.Value))
						return true;
				}
			}
			return false;
		}
		GroupInfo[] GetGroupInfos(int rowHandle) {
			int rowLevel = GridControl.GetRowLevelByRowHandle(rowHandle);
			GroupInfo[] groupInfo = new GroupInfo[rowLevel + 1];
			int currentGroupRowHandle = rowHandle;
			for(int i = rowLevel; i >= 0; i--) {
				groupInfo[i] = new GroupInfo() {
					Value = GridControl.GetGroupRowValue(currentGroupRowHandle),
					FieldName = GridControl.SortInfo[i].FieldName
				};
				currentGroupRowHandle = GridControl.GetParentRowHandle(currentGroupRowHandle);
			}
			return groupInfo;
		}
		internal override FrameworkElement GetElementAcceptVisitor(DependencyObject hitElement, DataViewHitTestVisitorBase visitor) {
			TableView.CalcHitInfo(hitElement).Accept(visitor);
			return (visitor as FindTableElementHitTestVisitorBase).StoredHitElement;
		}
		protected override DataViewHitTestVisitorBase CreateFindDataAreaElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return new FindTableViewDataAreaElementHitTestVisitor(dataViewDragDropManager);
		}
		protected override DataViewHitTestVisitorBase CreateFindRowElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return new FindTableViewRowElementHitTestVisitor(dataViewDragDropManager);
		}
		protected internal override bool CustomAllowDrag(MouseButtonEventArgs e) {
			GridStartDragEventArgs startDragArgs = new GridStartDragEventArgs() {
				HitInfo = GetHitInfo(e) as TableViewHitInfo,
				CanDrag = true,
				Manager = this,
			};
			if(StartDraggingEventHandler != null)
				StartDraggingEventHandler(this, startDragArgs);
			return startDragArgs.CanDrag;
		}
		internal override int GetOverRowHandle(UIElement source, Point pt) {
			UIElement element = GetVisibleHitTestElement(pt);
			GridViewHitInfoBase hitInfo = GetHitInfo(element);
			return hitInfo.RowHandle;
		}
		internal override bool IsExpandable {
			get {
				if(HoverRowHandle != GridControl.InvalidRowHandle &&
					HoverRowHandle <= 0 &&
					HoverRowHandle != GridControl.NewItemRowHandle &&
					HoverRowHandle != GridControl.AutoFilterRowHandle)
					return !GridControl.IsGroupRowExpanded(HoverRowHandle);
				else
					return false;
			}
		}
		protected override void PerformAutoExpand() {
			GridControl.ExpandGroupRow(HoverRowHandle);
		}
	}
}
