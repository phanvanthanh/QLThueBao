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
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.Grid.DragDrop;
using System.Windows.Data;
#if SL
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Data.Browsing;
#endif
namespace DevExpress.Xpf.Grid {
	public class TreeListDragDropManager : DataViewDragDropManager {
		#region inner classes
		public class TreeListDragSource : SupportDragDropBase {
			TreeListDragDropManager TreeListDragDropManager { get { return (TreeListDragDropManager)dragDropManager; } }
			protected override FrameworkElement Owner { get { return TreeListDragDropManager.DataControl; } }
			public TreeListDragSource(DragDropManagerBase dragDropManager)
				: base(dragDropManager) {
			}
			protected override bool CanStartDragCore(MouseButtonEventArgs e) {
				return !TreeListDragDropManager.View.IsEditing && base.CanStartDragCore(e);
			}
			protected override FrameworkElement SourceElementCore {
				get { return TreeListDragDropManager.DataControl; }
			}
			protected override IList GetDraggingRows(MouseButtonEventArgs e) {
				TreeListViewHitInfo hitInfo = TreeListDragDropManager.GetHitInfo(e) as TreeListViewHitInfo;
				if(hitInfo.InRow && hitInfo.HitTest != TreeListViewHitTest.RowIndicator)
					return TreeListDragDropManager.GetSelectedRowsCopy();
				return null;
			}
		}
		#endregion
		public TreeListDragDropManager() { }
		static readonly DependencyProperty ViewTreeDerivationModeProperty =
			DependencyProperty.Register("ViewTreeDerivationMode", typeof(TreeDerivationMode),
			typeof(TreeListDragDropManager), new PropertyMetadata((d, e) => ((TreeListDragDropManager)d).UpdateDropStrategy()));
		[Browsable(false)]
		public TreeDerivationMode ViewTreeDerivationMode {
			get { return (TreeDerivationMode)GetValue(ViewTreeDerivationModeProperty); }
			set { SetValue(ViewTreeDerivationModeProperty, value); }
		}
		public override DataViewBase View {
			get {
				if(TreeListControl != null)
					return TreeListControl.View;
				if(GridControl != null)
					return GridControl.View;
				return null;
			}
		}
		protected TreeListDropStrategy DropStrategy { get; set; }
		delegate void MoveRowsDelegate(DragDropManagerBase sourceManager, int targetRowHandle, DependencyObject hitElement);
		TreeListView TreeListView { get { return View as TreeListView; } }
		TreeListControl TreeListControl { get { return DataControl as TreeListControl; } }
		GridControl GridControl { get { return DataControl as GridControl; } }
		protected override ISupportDragDrop CreateDragSource(DataViewDragDropManager dataViewDragDropManager) {
			return new TreeListDragSource(dataViewDragDropManager);
		}
		#region Events
		TreeListDragOverEventHandler DragOverEventHandler;
		TreeListDropEventHandler DropEventHandler;
		TreeListStartDragEventHandler StartDraggingEventHandler;
		TreeListDroppedEventHandler DroppedEventHandler;
		[Category("Events")]
		public event TreeListDragOverEventHandler DragOver {
			add { DragOverEventHandler += value; }
			remove { DragOverEventHandler -= value; }
		}
		[Category("Events")]
		public event TreeListDropEventHandler Drop {
			add { DropEventHandler += value; }
			remove { DropEventHandler -= value; }
		}
		[Category("Events")]
		public event TreeListDroppedEventHandler Dropped {
			add { DroppedEventHandler += value; }
			remove { DroppedEventHandler -= value; }
		}
		[Category("Events")]
		public event TreeListStartDragEventHandler StartDrag {
			add { StartDraggingEventHandler += value; }
			remove { StartDraggingEventHandler -= value; }
		}
		#endregion
		protected override void OnAttached() {
			base.OnAttached();
			BindTreeDerivationMode();
			UpdateDropStrategy();
		}
		protected override void OnDetaching() {
#if !SL
			BindingOperations.ClearBinding(TreeListView, ViewTreeDerivationModeProperty);
#endif
			base.OnDetaching();
		}
		void BindTreeDerivationMode() {
			Binding b = new Binding("TreeDerivationMode");
			b.Source = TreeListView;
			BindingOperations.SetBinding(this, ViewTreeDerivationModeProperty, b);
		}
		void UpdateDropStrategy() {
			DropStrategy = CreateDropStrategy();
		}
		protected virtual TreeListDropStrategy CreateDropStrategy() {
			TreeListView view = this.TreeListView;
			if(view == null) return null;
			if(TreeDerivationMode.Selfreference == view.TreeDerivationMode)
				return new SelfReferenceDropStrategy(view);
			return new EmptyDropStrategy(view);
		}
		internal virtual List<object> GetSelectedRowsCopy() {
			List<object> objects = new List<object>();
			foreach(TreeListNode node in TreeListView.GetSelectedNodes())
				objects.Add(node);
			return objects;
		}
		protected internal override void OnDrop(DragDropManagerBase sourceManager, UIElement source, Point pt) {
			TreeListDropEventArgs e = RaiseDropEvent(sourceManager, pt);
			if(!e.Handled)
				PerformDropToView(sourceManager, pt, MoveSelectedRows, MoveSelectedRowsToChildrenCollection, AddRows);
			RaiseDroppedEvent(sourceManager, e);
		}
		protected override GridViewHitInfoBase GetHitInfo(DependencyObject element) {
			return TreeListView.CalcHitInfo(element);
		}
		protected override void PerformDropToView(DragDropManagerBase sourceManager) {
			if((bool)LayoutHelper.GetTopLevelVisual(View).GetValue(DragManager.IsDraggingProperty)) {
				PerformDropToView(sourceManager, LastPosition, SetReorderDropInfo, null, SetAddRowsDropInfo);
			}
		}
		protected override void AddRow(DragDropManagerBase sourceManager, object row, int insertRowHandle) {
			sourceManager.GetSource(row).Remove(sourceManager.GetObject(row));
			DropStrategy.DropObject(ItemsSource, null, DropTargetType.DataArea, sourceManager.GetObject(row));
			InsertObject(ItemsSource, null, DropTargetType.DataArea, sourceManager.GetObject(row), -1);
		}
		void PerformDropToView(DragDropManagerBase sourceManager, Point pt, MoveRowsDelegate setreorderDelegate, MoveRowsDelegate moveToGroupDelegate, MoveRowsDelegate addRowsDelegate) {
			UIElement element = GetVisibleHitTestElement(pt);
			TreeListViewHitInfo hitInfo = GetHitInfo(element) as TreeListViewHitInfo;
			int insertRowHandle = hitInfo.RowHandle;
			TreeListNode insertNode = TreeListView.GetNodeByRowHandle(insertRowHandle);
			TreeListDragOverEventArgs e = RaiseDragOverEvent(hitInfo, sourceManager);
			if(e.Handled ? !e.AllowDrop : !e.AllowDrop || InternalBanDrop(insertRowHandle, insertNode, sourceManager)) {
				ClearDragInfo(sourceManager);
				sourceManager.SetDragInfoVisibility(e.ShowDragInfo);
				SetDropMarkerVisibility(e.ShowDropMarker);
				return;
			}
			if(hitInfo.HitTest == TreeListViewHitTest.DataArea) {
				if(sourceManager.DraggingRows.Count > 0 && GetDataAreaElement(element) != null) {
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
			setreorderDelegate(sourceManager, insertRowHandle, element);
		}
		TreeListDragOverEventArgs RaiseDragOverEvent(TreeListViewHitInfo hitInfo, DragDropManagerBase sourceManager) {
			TreeListDragOverEventArgs e = new TreeListDragOverEventArgs(hitInfo, sourceManager.DraggingRows) {
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
			};
			if(DragOverEventHandler != null)
				DragOverEventHandler(this, e);
			return e;
		}
		bool InternalBanDrop(int insertRowHandle, TreeListNode insertNode, DragDropManagerBase sourceManager) {
			if(ReferenceEquals(this, sourceManager))
				foreach(TreeListNode node in sourceManager.DraggingRows) {
					if(ReferenceEquals(insertNode, node) || (insertNode!=null && insertNode.IsDescendantOf(node)))
						return true;
				}
			return false;
		}
		bool IsSorted() {
			if(TreeListControl != null)
				return TreeListControl.SortInfo.Count > 0;
			if(GridControl != null)
				return GridControl.SortInfo.Count > 0;
			return false;
		}
		void MoveSelectedRows(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			TreeListNode insertNode = TreeListView.GetNodeByRowHandle(insertRowHandle);
			object insertObject = insertNode.Content;
			if(insertObject == null || sourceManager.DraggingRows.Contains(insertObject))
				return;
			DropTargetType dropTargetType = GetDropTargetType(GetRowElement(hitElement) as DataContentPresenter);
			if(dropTargetType == DropTargetType.None)
				return;
			DataControl.BeginDataUpdate();
			IList source = GetSource(insertNode);
			int insertIndex = source.IndexOf(insertNode.Content)
				+ (dropTargetType == DropTargetType.InsertRowsAfter ? 1 : 0);
			foreach(object obj in sourceManager.DraggingRows) {
				if(ReferenceEquals(source, sourceManager.GetSource(obj))) {
					if(insertIndex > source.IndexOf(GetObject(obj)))
						insertIndex--;
					if(ReferenceEquals(insertObject, sourceManager.GetObject(obj)))
						continue;
				}
				sourceManager.GetSource(obj).Remove(sourceManager.GetObject(obj));
				DropStrategy.DropObject(source, insertNode, dropTargetType, sourceManager.GetObject(obj));
				InsertObject(source, insertNode, dropTargetType, sourceManager.GetObject(obj), insertIndex);
				insertIndex++;
			}
			DataControl.EndDataUpdate();
			if(TreeListView.MultiSelectMode == TableViewSelectMode.Row && RestoreSelection) {
				int[] selectedHandles = TreeListView.GetSelectedRowHandles();
				int startRowHandle = selectedHandles[0];
				int endRowHandle = selectedHandles[selectedHandles.Length - 1];
				TreeListView.SelectRange(startRowHandle, endRowHandle);
			} else TreeListView.ClearSelection();
			TreeListView.FocusedRow = GetObject(sourceManager.DraggingRows[0]);
		}
		TreeListDropEventArgs RaiseDropEvent(DragDropManagerBase sourceManager, Point pt) {
			UIElement hitElement = GetVisibleHitTestElement(pt);
			TreeListViewHitInfo hitInfo = GetHitInfo(hitElement) as TreeListViewHitInfo;
			TreeListNode insertNode = TreeListView.GetNodeByRowHandle(hitInfo.RowHandle);
			DropTargetType dropTargetType = GetDropTargetType(GetRowElement(hitElement) as DataContentPresenter);
			return RaiseDropEvent(sourceManager, hitInfo, insertNode, sourceManager.DraggingRows,
				hitInfo.HitTest == TreeListViewHitTest.DataArea ? DropTargetType.DataArea : dropTargetType);
		}
		TreeListDropEventArgs RaiseDropEvent(DragDropManagerBase sourceManager, TreeListViewHitInfo hitInfo, TreeListNode insertNode, IList rows, DropTargetType dropTargetType) {
			TreeListDropEventArgs e = new TreeListDropEventArgs() {
				HitInfo = hitInfo,
				TargetNode = insertNode,
				DraggedRows = rows,
				DropTargetType = dropTargetType,
				Handled = false,
				Manager = this,
				SourceManager = sourceManager,
				DataControl = DataControl as GridDataControlBase,
			};
			if(DropEventHandler != null)
				DropEventHandler(this, e);
			return e;
		}
		void RaiseDroppedEvent(DragDropManagerBase sourceManager, TreeListDropEventArgs dropEventArgs) {
			if(DroppedEventHandler != null) {
				TreeListDroppedEventArgs e = new TreeListDroppedEventArgs() {
					DataControl = DataControl as GridDataControlBase,
					TargetNode = dropEventArgs.TargetNode,
					HitInfo = dropEventArgs.HitInfo,
					Manager = this,
					DraggedRows = dropEventArgs.DraggedRows,
					SourceManager = sourceManager,
					DropTargetType = dropEventArgs.DropTargetType,
				};
				DroppedEventHandler(this, e);
			}
		}
		void InsertObject(IList ItemsSource, TreeListNode node, DropTargetType dropTargetType, object obj, int index) {
			switch(dropTargetType) {
				case DropTargetType.InsertRowsBefore:
					GetParentItemsSource(node).Insert(index, obj);
					break;
				case DropTargetType.InsertRowsAfter:
					GetParentItemsSource(node).Insert(index, obj);
					break;
				case DropTargetType.DataArea:
				case DropTargetType.InsertRowsIntoNode:
					GetItemsSource(node).Add(obj);
					break;
				default:
					break;
			}
		}
		object GetObjectByRowHandle(int insertRowHandle) {
			GridRow row = View.GetRowElementByRowHandle(insertRowHandle) as GridRow;
			if(row != null) {
				RowData rowData = row.DataContext as RowData;
				if(rowData != null)
					return rowData.Row;
			}
			return null;
		}
		void SetReorderDropInfo(DragDropManagerBase sourceManager, int insertRowHandle, DependencyObject hitElement) {
			FrameworkElement rowElement = GetRowElement(hitElement);
			TableDragIndicatorPosition dragIndicatorPosition = GetDragIndicatorPositionForRowElement(rowElement);
			if(dragIndicatorPosition != TableDragIndicatorPosition.None) {
				DropTargetType dropTargetType;
				switch(dragIndicatorPosition) {
					case TableDragIndicatorPosition.Top:
						dropTargetType = DropTargetType.InsertRowsBefore;
						break;
					case TableDragIndicatorPosition.Bottom:
						dropTargetType = DropTargetType.InsertRowsAfter;
						break;
					case TableDragIndicatorPosition.InRow:
						dropTargetType = DropTargetType.InsertRowsIntoNode;
						break;
					default:
						dropTargetType = DropTargetType.None;
						break;
				}
				sourceManager.SetDropTargetType(dropTargetType);
				sourceManager.ViewInfo.DropTargetRow = GetObjectByRowHandle(insertRowHandle);
				sourceManager.ShowDropMarker(rowElement, dragIndicatorPosition);
			} else {
				ClearDragInfo(sourceManager);
			}
		}
		void MoveSelectedRowsToChildrenCollection(DragDropManagerBase sourceManager, int groupRowHandle, DependencyObject hitElement) {
		}
		protected override TableDragIndicatorPosition GetDragIndicatorPositionForRowElement(FrameworkElement rowElement) {
			if(rowElement == null)
				return TableDragIndicatorPosition.None;
			if(IsSorted())
				return TableDragIndicatorPosition.InRow;
#if SL
			double point = LastPosition.Y - LayoutHelper.GetRelativeElementRect(rowElement, View).Top;
#else
			double point = Mouse.GetPosition(rowElement).Y;
#endif
			if(point < rowElement.ActualHeight / 4.0f)
				return TableDragIndicatorPosition.Top;
			else if(point > rowElement.ActualHeight * .75f)
				return TableDragIndicatorPosition.Bottom;
			return TableDragIndicatorPosition.InRow;
		}
		internal override FrameworkElement GetElementAcceptVisitor(DependencyObject hitElement, DataViewHitTestVisitorBase visitor) {
			TreeListView.CalcHitInfo(hitElement).Accept(visitor);
			FindTreeListViewElementHitTestVisitorBase tlVisitor = visitor as FindTreeListViewElementHitTestVisitorBase;
			if(tlVisitor.Row != null)
				return LayoutHelper.FindElement(tlVisitor.Row, (e) => e is DataContentPresenter);
			if(tlVisitor.DataArea != null)
				return tlVisitor.DataArea;
			return null;
		}
		protected override DataViewHitTestVisitorBase CreateFindDataAreaElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return new FindTreeListViewDataAreaElementHitTestVisitor(dataViewDragDropManager);
		}
		protected override DataViewHitTestVisitorBase CreateFindRowElementHitTestVisitor(DataViewDragDropManager dataViewDragDropManager) {
			return new FindTreeListViewRowElementHitTestVisitor(dataViewDragDropManager);
		}
		public override object GetObject(object obj) {
			TreeListNode node = obj as TreeListNode;
			if(node!=null)
				return node.Content;
			return obj;
		}
		protected internal override IList GetSource(object row) {
			if(TreeListView.TreeDerivationMode == TreeDerivationMode.Selfreference)
				return ItemsSource;
			TreeListNode node = row as TreeListNode;
			if(node == null) return null;
			return GetParentItemsSource(node);
		}
		IList GetParentItemsSource(TreeListNode node) {
			return (node.ParentNode == null) ? ItemsSource : GetItemsSource(node.ParentNode);
		}
		IList GetItemsSource(TreeListNode node) {
			if(TreeListView.TreeDerivationMode == TreeDerivationMode.Selfreference || node == null)
				return ItemsSource;
			else if(TreeListView.TreeDerivationMode == TreeDerivationMode.ChildNodesSelector
				|| TreeListView.TreeDerivationMode == TreeDerivationMode.HierarchicalDataTemplate)
				return node.ItemsSource;
			return null;
		}
		protected internal override bool CustomAllowDrag(MouseButtonEventArgs e) {
			TreeListStartDragEventArgs startDragArgs = new TreeListStartDragEventArgs() {
				HitInfo = GetHitInfo(e) as TreeListViewHitInfo,
				CanDrag = true,
				Manager = this,
			};
			if(StartDraggingEventHandler != null)
				StartDraggingEventHandler(this, startDragArgs);
			return startDragArgs.CanDrag;
		}
		internal override int GetOverRowHandle(UIElement source, Point pt) {
			UIElement element = GetVisibleHitTestElement(pt);
			return GetHitInfo(element).RowHandle;
		}
		internal override bool IsExpandable {
			get {
				TreeListNode node = TreeListView.GetNodeByRowHandle(HoverRowHandle);
				if(node != null && !node.IsExpanded && node.HasVisibleChildren && 
					GetDragIndicatorPositionForRowElement(TreeListView.GetRowElementByRowHandle(HoverRowHandle)) == TableDragIndicatorPosition.InRow)
					return true;
				else
					return false;
			}
		}
		protected override void PerformAutoExpand() {
			TreeListView.ExpandNode(HoverRowHandle);
		}
	}
}
